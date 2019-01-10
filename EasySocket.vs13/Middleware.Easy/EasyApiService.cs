using EasySocket.vs13.Core;
using EasySocket.vs13.Exceptions;
using EasySocket.vs13.Telegram.Easy.Context;
using EasySocket.vs13.Telegram.Easy.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.Telegram.Easy
{
    /// <summary>
    /// 表示Easy协议的Api服务基类
    /// </summary>
    public abstract class EasyApiService : EasyFilterAttribute, IEasyApiService
    {
        /// <summary>
        /// 获取关联的服务器实例
        /// </summary>
        protected EasyMiddleware Middleware { get; private set; }

        /// <summary>
        /// 获取当前Api行为上下文
        /// </summary>
        protected ActionContext CurrentContext { get; private set; }


        /// <summary>
        /// Easy协议的Api服务基类
        /// </summary>
        public EasyApiService()
        {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="middleware">关联的中间件</param>
        /// <returns></returns>
        internal EasyApiService Init(EasyMiddleware middleware)
        {
            this.Middleware = middleware;
            return this;
        }

        /// <summary>
        /// 执行Api行为
        /// </summary>   
        /// <param name="actionContext">上下文</param>      
        /// <returns></returns>
        async Task IEasyApiService.ExecuteAsync(ActionContext actionContext)
        {
            var filters = Enumerable.Empty<IFilter>();
            try
            {
                this.CurrentContext = actionContext;
                filters = this.Middleware.FilterAttributeProvider.GetActionFilters(actionContext.Action);
                await this.ExecuteActionAsync(actionContext, filters);
            }
            catch (Exception ex)
            {
                this.ProcessExecutingException(actionContext, filters, ex);
            }
        }

        /// <summary>
        /// 处理Api行为执行过程中产生的异常
        /// </summary>
        /// <param name="actionContext">上下文</param>
        /// <param name="filters">过滤器</param>
        /// <param name="exception">异常项</param>      
        private void ProcessExecutingException(ActionContext actionContext, IEnumerable<IFilter> filters, Exception exception)
        {
            var exceptionContext = new ExceptionContext(actionContext, new ApiExecuteException(exception));
            this.ExecAllExceptionFilters(filters, exceptionContext);
            Common.SendRemoteException(actionContext.Session, exceptionContext);
        }

        /// <summary>
        /// 调用自身实现的Api行为            
        /// </summary>       
        /// <param name="actionContext">上下文</param>       
        /// <param name="filters">过滤器</param>
        /// <returns></returns>
        private async Task ExecuteActionAsync(ActionContext actionContext, IEnumerable<IFilter> filters)
        {
            Common.GetAndUpdateParameterValues(this.Middleware.Serializer, actionContext);
            this.ExecFiltersBeforeAction(filters, actionContext);

            if (actionContext.Result == null)
            {
                await this.ExecutingActionAsync(actionContext, filters);
            }
            else
            {
                var exceptionContext = new ExceptionContext(actionContext, actionContext.Result);
                Common.SendRemoteException(actionContext.Session, exceptionContext);
            }
        }

        /// <summary>
        /// 异步执行Api
        /// </summary>
        /// <param name="actionContext">上下文</param>
        /// <param name="filters">过滤器</param>
        /// <returns></returns>
        private async Task ExecutingActionAsync(ActionContext actionContext, IEnumerable<IFilter> filters)
        {
            var paramters = actionContext.Action.Parameters.Select(p => p.Value).ToArray();
            var result = await actionContext.Action.ExecuteAsync(this, paramters);
       
           

            this.ExecFiltersAfterAction(filters, actionContext);
            if (actionContext.Result != null)
            {
                var exceptionContext = new ExceptionContext(actionContext, actionContext.Result);
                Common.SendRemoteException(actionContext.Session, exceptionContext);
            }
            else if (actionContext.Action.IsVoidReturn == false && actionContext.Session.IsConnected)  // 返回数据
            {
                actionContext.Packet.Body = this.Middleware.Serializer.Serialize(result);
                
                //if (actionContext.Session.UnWrap().SendData(actionContext.Packet.ToArraySegment())==false)
                //{
                //    Console.WriteLine(string.Format(" > [{0},OnSend_Error])",actionContext.Session.ToString()));
                //}
                Common.SendRemoteData(actionContext);
                //actionContext.Session.UnWrap().SendData(actionContext.Packet.ToBytes());
            }
        }

        /// <summary>
        /// 在Api行为前 执行过滤器
        /// </summary>       
        /// <param name="filters">Api行为过滤器</param>
        /// <param name="actionContext">上下文</param>   
        private void ExecFiltersBeforeAction(IEnumerable<IFilter> filters, ActionContext actionContext)
        {
            var totalFilters = this.GetTotalFilters(filters);
            foreach (var filter in totalFilters)
            {
                filter.OnExecuting(actionContext);
                if (actionContext.Result != null) break;
            }
        }

        /// <summary>
        /// 在Api行为后执行过滤器
        /// </summary>       
        /// <param name="filters">Api行为过滤器</param>
        /// <param name="actionContext">上下文</param>       
        private void ExecFiltersAfterAction(IEnumerable<IFilter> filters, ActionContext actionContext)
        {
            var totalFilters = this.GetTotalFilters(filters);
            foreach (var filter in totalFilters)
            {
                filter.OnExecuted(actionContext);
                if (actionContext.Result != null) break;
            }
        }

        /// <summary>
        /// 执行异常过滤器
        /// </summary>       
        /// <param name="filters">Api行为过滤器</param>
        /// <param name="exceptionContext">上下文</param>       
        private void ExecAllExceptionFilters(IEnumerable<IFilter> filters, ExceptionContext exceptionContext)
        {
            var totalFilters = this.GetTotalFilters(filters);
            foreach (var filter in totalFilters)
            {
                filter.OnException(exceptionContext);
                if (exceptionContext.ExceptionHandled == true) break;
            }
        }


        /// <summary>
        /// 获取全部的过滤器
        /// </summary>
        /// <param name="filters">行为过滤器</param>
        /// <returns></returns>
        private IEnumerable<IFilter> GetTotalFilters(IEnumerable<IFilter> filters)
        {
            return this.Middleware
                .GlobalFilters
                .Cast<IFilter>()
                .Concat(new[] { this })
                .Concat(filters);
        }

        #region IDisponse
        /// <summary>
        /// 获取对象是否已释放
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// 关闭和释放所有相关资源
        /// </summary>
        public void Dispose()
        {
            if (this.IsDisposed == false)
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
            this.IsDisposed = true;
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~EasyApiService()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">是否也释放托管资源</param>
        protected virtual void Dispose(bool disposing)
        {
        }
        #endregion
    }
}
