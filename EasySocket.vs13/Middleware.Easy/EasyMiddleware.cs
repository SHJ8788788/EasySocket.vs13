using EasySocket.vs13.Core;
using EasySocket.vs13.Core.Internal;
using EasySocket.vs13.Exceptions;
using EasySocket.vs13.Serializers;
using EasySocket.vs13.Stream;
using EasySocket.vs13.Tasks;
using EasySocket.vs13.Telegram.Easy.Context;
using EasySocket.vs13.Telegram.Easy.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasySocket.vs13.Telegram.Easy
{
    /// <summary>
    /// Easy协议中间件
    /// </summary>
    public class EasyMiddleware:IMiddleware
    {
        /// <summary>
        /// 所有Api行为
        /// </summary>
        private ApiActionTable apiActionTable;

        /// <summary>
        /// 获取数据包id提供者
        /// </summary>
        internal PacketIdProvider PacketIdProvider { get; private set; }

        /// <summary>
        /// 获取任务行为记录表
        /// </summary>
        internal TaskSetterTable<long> TaskSetterTable { get; private set; }

        /// <summary>
        /// 获取或设置请求等待超时时间(毫秒)    
        /// 默认30秒
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public TimeSpan TimeOut { get; set; }

        /// <summary>
        /// 下一个中间件
        /// </summary>
        public IMiddleware Next { get; set; }

        /// <summary>
        /// 获取或设置序列化工具
        /// 默认提供者是Json序列化
        /// </summary>
        public ISerializer Serializer { get; set; }

        /// <summary>
        /// 获取全局过滤器管理者
        /// </summary>
        public IGlobalFilters GlobalFilters { get; private set; }

        /// <summary>
        /// 获取或设置依赖关系解析提供者
        /// 默认提供者解析为单例模式
        /// </summary>
        public IDependencyResolver DependencyResolver { get; set; }

        /// <summary>
        /// 获取或设置Api行为特性过滤器提供者
        /// </summary>
        public IFilterAttributeProvider FilterAttributeProvider { get; set; }

          /// <summary>
        /// Easy协议中间件
        /// </summary>
        public EasyMiddleware()
        {
            this.apiActionTable = new ApiActionTable();
            this.PacketIdProvider = new PacketIdProvider();
            this.TaskSetterTable = new TaskSetterTable<long>();

            this.TimeOut = TimeSpan.FromSeconds(30);
            //this.Serializer = new DefaultSerializer();
            this.Serializer = new ProtoBufSerializer();
            this.GlobalFilters = new EasyGlobalFilters();
            this.DependencyResolver = new DefaultDependencyResolver();
            this.FilterAttributeProvider = new DefaultFilterAttributeProvider();

            DomainAssembly.GetAssemblies().ForEach(item => this.BindService(item));//绑定映射程序集
        }

        /// <summary>
        /// 绑定程序集下所有实现IEasyApiService的服务
        /// </summary>
        /// <param name="assembly">程序集</param>
        private void BindService(Assembly assembly)
        {
            try
            {
            var EasyApiServices = assembly.GetTypes().Where(item =>
                item.IsAbstract == false
                && item.IsInterface == false
                    //判断IEasyApiService是否是item的父类或接口
                && typeof(IEasyApiService).IsAssignableFrom(item));

                foreach (var type in EasyApiServices)
                {
                    var actions = Common.GetServiceApiActions(type);
                    this.apiActionTable.AddRange(actions);
                }
            }
            catch (Exception ex)
            {
                Log4Ex.LogHelper.MiddlewareException("EasyMiddleware",ex.Message);
            }
           
        }

        /// <summary>
        /// 执行中间件
        /// </summary>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        public Task Invoke(IContext context)
        {
            var protocal = context.Session.Extra.Protocol;
            if (protocal != Protocol.None && protocal != Protocol.Easy)
            {
                return this.Next.Invoke(context);
            }
            return this.OnEasyRequestAsync(context);
        }

        /// <summary>
        /// 收到Easy数据请求
        /// </summary>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        private Task OnEasyRequestAsync(IContext context)
        {            
            var easyPackets = default(List<EasyPacket>);
            //生成EasyPacket,生成失败(不符合解析规则)则调用下一个middleware?????            
            if (EasyPacket.GenerateEasyPackets(context, out easyPackets) == false)
            {
                return this.Next.Invoke(context);
            }

            // 数据未完整
            if (easyPackets.Count == 0)
            {
                var wrapper = new EasySession(context.Session, this);
                context.Session.SetProtocolWrapper(Protocol.Easy, wrapper);
                return TaskExtend.CompletedTask;
            }

            //数据完整，但协议不明的情况，将session与可解析的中间件协议相互绑定
            if (context.Session.Extra.Protocol == Protocol.None)
            {
                var wrapper = new EasySession(context.Session, this);
                context.Session.SetProtocolWrapper(Protocol.Easy, wrapper);
            }
            var easySession = (EasySession)context.Session.Wrapper;
            //循环使用已解析的数据包集合
            foreach (var packet in easyPackets)
            {
                var requestContext = new RequestContext(easySession, packet, context.AllSessions);
                this.OnRecvEasyPacketAsync(requestContext);
            }
            return TaskExtend.CompletedTask;
        }

        /// <summary>
        /// 接收到会话对象的数据包
        /// </summary>
        /// <param name="requestContext">请求上下文</param>
        private async void OnRecvEasyPacketAsync(RequestContext requestContext)
        {
            //中间件调用别的远程服务后返回结果判断，如果是IsException则结束TaskSetterTable中的对应任务
            if (requestContext.Packet.IsException == true)
            {
                Common.SetApiActionTaskException(this.TaskSetterTable, requestContext);
            }
            else
            {
                await this.ProcessRequestAsync(requestContext);
            }
        }

        /// <summary>
        /// 处理正常的数据请求
        /// </summary>
        /// <param name="requestContext">请求上下文</param>
        /// <returns></returns>
        private async Task ProcessRequestAsync(RequestContext requestContext)
        {
            //IsFromClient==false代表中间件调用别的远程服务后返回结果
            if (requestContext.Packet.IsFromClient == false)
            {
                Common.SetApiActionTaskResult(requestContext, this.TaskSetterTable, this.Serializer);
            }
            else
            {
                await this.TryExecuteRequestAsync(requestContext);
            }
        }

        /// <summary>
        /// 执行请求
        /// </summary>
        /// <param name="requestContext">上下文</param>
        /// <returns></returns>
        private async Task TryExecuteRequestAsync(RequestContext requestContext)
        {
            try
            {
                var action = this.GetApiAction(requestContext);
                var actionContext = new ActionContext(requestContext, action);
                var EasyApiService = this.GetEasyApiService(actionContext);
                await EasyApiService.ExecuteAsync(actionContext);
                this.DependencyResolver.TerminateService(EasyApiService);
            }
            catch (Exception ex)
            {
                var context = new ExceptionContext(requestContext, ex);
                this.OnException(requestContext.Session, context);
            }
        }

        /// <summary>
        /// 获取Api行为
        /// </summary>
        /// <param name="requestContext">请求上下文</param>
        /// <exception cref="ApiNotExistException"></exception>
        /// <returns></returns>
        private ApiAction GetApiAction(RequestContext requestContext)
        {
            var apiKey = new ApiKey(requestContext.Packet.ApiName, requestContext.Packet.parametersNames);
            var action = this.apiActionTable.TryGetAndClone(apiKey);
            if (action == null)
            {
                throw new ApiNotExistException(apiKey);
            }
            return action;
        }

        /// <summary>
        /// 获取EasyApiService实例
        /// </summary>
        /// <param name="actionContext">Api行为上下文</param>
        /// <exception cref="ResolveException"></exception>
        /// <returns></returns>
        private IEasyApiService GetEasyApiService(ActionContext actionContext)
        {
            try
            {
                var serviceType = actionContext.Action.DeclaringService;
                var EasyApiService = this.DependencyResolver.GetService(serviceType) as EasyApiService;
                return EasyApiService.Init(this);
            }
            catch (Exception ex)
            {
                throw new ResolveException(actionContext.Action.DeclaringService, ex);
            }
        }

        /// <summary>
        /// 异常时
        /// </summary>
        /// <param name="sessionWrapper">产生异常的会话</param>
        /// <param name="context">上下文</param>
        protected virtual void OnException(IWrapper sessionWrapper, ExceptionContext context)
        {
            Common.SendRemoteException(sessionWrapper, context);
        }
    }
}
