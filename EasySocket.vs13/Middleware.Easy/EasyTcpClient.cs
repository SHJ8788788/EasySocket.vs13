using EasySocket.vs13.Core;
using EasySocket.vs13.Core.Internal;
using EasySocket.vs13.Exceptions;
using EasySocket.vs13.Serializers;
using EasySocket.vs13.Session;
using EasySocket.vs13.Tasks;
using EasySocket.vs13.Telegram.Easy.Context;
using HPSocketCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.Telegram.Easy
{
    public class EasyTcpClient : TcpSessionClient, IWrapper
    {
        /// <summary>
        /// 唯一实例
        /// </summary>
        private static readonly Lazy<EasyTcpClient> instance = new Lazy<EasyTcpClient>(() => new EasyTcpClient());

        /// <summary>
        /// 获取唯一实例
        /// </summary>
        public static EasyTcpClient Instance
        {
            get { return instance.Value; }
        }

        static int connId = 0 ;
        /// <summary>
        /// 所有Api行为
        /// </summary>
        private ApiActionTable apiActionTable;
        /// <summary>
        /// 数据包id提供者
        /// </summary>
        private PacketIdProvider packetIdProvider;
        /// <summary>
        /// 任务行为表
        /// </summary>
        private TaskSetterTable<long> taskSetterTable;
        /// <summary>
        /// 获取或设置序列化工具
        /// 默认是Json序列化
        /// </summary>
        public ISerializer Serializer { get; set; }
        /// <summary>
        /// 获取或设置请求等待超时时间(毫秒) 
        /// 默认30秒
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public TimeSpan TimeOut { get; set; }

        /// <summary>
        /// 获取或设置依赖关系解析提供者
        /// 默认提供者解析为单例模式
        /// </summary>
        public IDependencyResolver DependencyResolver { get; set; }

        public EasyTcpClient()
            : this(connId)
        {            
        }
        public EasyTcpClient(int connId):base()
        {
            this.Init();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            //this.apiActionTable = new ApiActionTable(Internal.Common.GetServiceApiActions(this.GetType()));
            this.apiActionTable = new ApiActionTable();
            this.packetIdProvider = new PacketIdProvider();
            this.taskSetterTable = new TaskSetterTable<long>();
            //this.Serializer = new DefaultSerializer();
            this.Serializer = new ProtoBufSerializer();
            this.TimeOut = TimeSpan.FromSeconds(30);
                        this.DependencyResolver = new DefaultDependencyResolver();
            BindService();
        }

        #region FuncForOverride
        /// <summary>
        /// 连接指定服务端
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public override bool Connect(string ip, ushort port)
        {
            return base.Connect(ip, port);
        }
        /// <summary>
        /// 断开服务端连接
        /// </summary>
        /// <returns></returns>
        public override bool Stop()
        {
            return base.Stop();
        }
        /// <summary>
        /// 当接收到远程端的数据时，将触发此方法   
        /// </summary>       
        /// <param name="streamReader">接收到的数据读取器</param>
        /// <returns></returns>
        protected override Task OnReceiveAsync(ISession session)
        {
            var context = this.CreateContext(this);
            var packages = this.GenerateEasyPackets(context);
            foreach (var package in packages)
            {
                this.ProcessPacketAsync(package);
            }
            return TaskExtend.CompletedTask;
        }
        /// <summary>
        /// 创建上下文对象
        /// </summary>
        /// <param name="session">当前会话</param>
        /// <returns></returns>
        private IContext CreateContext(ISession session)
        {
            return new DefaultContext
            {
                Session = session,
                StreamReader = session.StreamReader
            };
        }
        #endregion
        #region FuncForPrivate
        /// <summary>
        /// 生成数据包
        /// </summary>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        private IList<EasyPacket> GenerateEasyPackets(IContext context)
        {
            var easyPackets = new List<EasyPacket>();
            //生成EasyPacket,生成失败则直接返回
            if (EasyPacket.GenerateEasyPackets(context, out easyPackets) == false)
            {
                return easyPackets;
            }
            else if (easyPackets == null)
            {
                return easyPackets;
            }
            else
            {
                return easyPackets;
            }
        }
        /// <summary>
        /// 处理接收到服务发来的数据包
        /// </summary>
        /// <param name="packet">数据包</param>
        private async void ProcessPacketAsync(EasyPacket packet)
        {
            var requestContext = new RequestContext(null, packet, null);
            if (packet.IsException == true)
            {
                Internal.Common.SetApiActionTaskException(this.taskSetterTable, requestContext);
            }
            else if (packet.IsFromClient == true)
            {
                Internal.Common.SetApiActionTaskResult(requestContext, this.taskSetterTable, this.Serializer);
            }
            else
            {
                await TryProcessRequestPackageAsync(requestContext);
            }
        }
        /// <summary>
        /// 处理服务器请求的数据包
        /// </summary>
        /// <param name="requestContext">上下文</param>
        /// <returns></returns>
        private async Task TryProcessRequestPackageAsync(RequestContext requestContext)
        {
            try
            {
                var action = this.GetApiAction(requestContext);
                var actionContext = new ActionContext(requestContext, action);
                await this.ExecuteActionAsync(actionContext);
            }
            catch (Exception ex)
            {
                var exceptionContext = new ExceptionContext(requestContext, ex);
                Internal.Common.SendRemoteException(this, exceptionContext);
                this.OnException(requestContext.Packet, ex);
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
            if (action != null)
            {
                return action;
            }
            throw new ApiNotExistException(apiKey);
        }
        /// <summary>
        /// 执行Api行为
        /// </summary>
        /// <param name="actionContext">上下文</param>  
        /// <returns></returns>
        private async Task ExecuteActionAsync(ActionContext actionContext)
        {
            var action = actionContext.Action;
            var parameters = Internal.Common.GetAndUpdateParameterValues(this.Serializer, actionContext);

            var easyApiService = this.GetEasyApiService(actionContext);
            //await EasyApiService.ExecuteAsync(actionContext);

            var result = await action.ExecuteAsync(easyApiService, parameters);

            if (action.IsVoidReturn == false && this.client.IsStarted == true)
            {
                actionContext.Packet.Body = this.Serializer.Serialize(result);
                this.TrySendPackage(actionContext.Packet);
            }
        }

        /// <summary>
        /// 获取EasyApiService实例
        /// </summary>
        /// <param name="actionContext">Api行为上下文</param>
        /// <exception cref="ResolveException"></exception>
        /// <returns></returns>
        private EasyTcpClient GetEasyApiService(ActionContext actionContext)
        {
            try
            {
                var serviceType = actionContext.Action.DeclaringService;
                return (this.DependencyResolver.GetService(serviceType) as EasyTcpClient);               
            }
            catch (Exception ex)
            {
                throw new ResolveException(actionContext.Action.DeclaringService, ex);
            }
        }

        /// <summary>
        /// 发送数据包
        /// </summary>
        /// <param name="package">数据包</param>
        /// <returns></returns>
        private bool TrySendPackage(EasyPacket package)
        {
            try
            {
                return base.SendData(package.ToArraySegment());
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 绑定程序集下所有实现EasyTcpClient的服务
        /// 默认入口程序集
        /// </summary>
        //private void BindService(Assembly assembly = null)
        //{
        //    //未指定加载程序集，默认使用入口程序集
        //    if (assembly == null)
        //    {
        //        //程序入口程序集
        //        var current = Assembly.GetEntryAssembly();
        //        assembly = current;
        //    }

        //    var EasyApiServices = assembly.GetTypes().Where(item =>
        //        item.IsAbstract == false
        //        && item.IsInterface == false
        //            //判断EasyTcpClient是否是item的父类或接口
        //        && this.GetType().IsAssignableFrom(item));

        //    foreach (var type in EasyApiServices)
        //    {
        //        var actions = Internal.Common.GetServiceApiActions(type);
        //        apiActionTable.AddRange(actions);
        //    }
        //}

        /// <summary>
        /// 绑定程序集下所有实现EasyTcpClient的服务
        /// 默认入口程序集
        public void BindService(Assembly assembly = null)
        {
            //未指定加载程序集，默认使用入口程序集
            if (assembly == null)
            {
                //程序入口程序集
                //var current = Assembly.GetAssembly(typeof(DomainAssembly));
                var current = Assembly.GetEntryAssembly();               
                assembly = current;
            }

            var EasyApiServices = assembly.GetTypes().Where(item =>
                item.IsAbstract == false
                && item.IsInterface == false
                    //判断EasyTcpClient是否是item的父类或接口
               );

            foreach (var type in EasyApiServices)
            {
                var actions = Internal.Common.GetServiceApiActions(type);
                apiActionTable.AddRange(actions);
            }
        }
        #endregion      

        /// <summary>
        ///  当操作中遇到处理异常时，将触发此方法
        /// </summary>
        /// <param name="packet">数据包对象</param>
        /// <param name="exception">异常对象</param> 
        protected virtual void OnException(EasyPacket packet, Exception exception)
        {
        }

        /// <summary>
        /// 调用服务端实现的Api        
        /// </summary>       
        /// <param name="api">Api行为的api</param>
        /// <param name="parameters">参数列表</param>          
        /// <exception cref="SocketException"></exception> 
        /// <exception cref="SerializerException"></exception> 
        public void InvokeApi(string api, params object[] parameters)
        {
            var packet = new EasyPacket(api, this.packetIdProvider.NewId(), true);
            packet.SetBodyParameters(this.Serializer, parameters);
            base.SendData(packet.ToArraySegment());
        }

        /// <summary>
        /// 调用服务端实现的Api   
        /// 并返回结果数据任务
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="api">Api行为的api</param>
        /// <param name="parameters">参数</param>
        /// <exception cref="SocketException"></exception>        
        /// <exception cref="SerializerException"></exception>
        /// <returns>远程数据任务</returns>    
        public ApiResult<TResult> InvokeApi<TResult>(string api, params object[] parameters)
        {
            var id = this.packetIdProvider.NewId();
            var packet = new EasyPacket(api, id, true);
            packet.SetBodyParameters(this.Serializer, parameters);

            return Internal.Common.InvokeApi<TResult>(this.UnWrap(), this.taskSetterTable, this.Serializer, packet, this.TimeOut);
        }

        /// <summary>
        /// 还原到包装前
        /// </summary>
        /// <returns></returns>
        public ISession UnWrap()
        {
            return (ISession)this;
        }
    }
}
