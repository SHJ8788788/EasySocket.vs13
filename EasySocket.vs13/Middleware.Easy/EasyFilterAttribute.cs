using EasySocket.vs13.Core;
using EasySocket.vs13.Telegram.Easy.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.Telegram.Easy
{
    /// <summary>
    /// 表示Easy协议过滤器
    /// </summary>
    public abstract class EasyFilterAttribute : FilterAttribute
    {
        /// <summary>
        /// 在执行Api行为前触发       
        /// </summary>
        /// <param name="filterContext">上下文</param>       
        /// <returns></returns>
        protected sealed override void OnExecuting(IActionContext filterContext)
        {
            this.OnExecuting(filterContext as ActionContext);
        }

        /// <summary>
        /// 在执行Api行为后触发
        /// </summary>
        /// <param name="filterContext">上下文</param>      
        protected sealed override void OnExecuted(IActionContext filterContext)
        {
            this.OnExecuted(filterContext as ActionContext);
        }

        /// <summary>
        /// 在Api执行中异常时触发
        /// </summary>
        /// <param name="filterContext">上下文</param>
        protected sealed override void OnException(IExceptionContext filterContext)
        {
            this.OnException(filterContext as ExceptionContext);
        }



        /// <summary>
        /// 在执行Api行为前触发       
        /// </summary>
        /// <param name="filterContext">上下文</param>       
        /// <returns></returns>
        protected virtual void OnExecuting(ActionContext filterContext)
        {
        }

        /// <summary>
        /// 在执行Api行为后触发
        /// </summary>
        /// <param name="filterContext">上下文</param>      
        protected virtual void OnExecuted(ActionContext filterContext)
        {
        }

        /// <summary>
        /// 在Api执行中异常时触发
        /// </summary>
        /// <param name="filterContext">上下文</param>
        protected virtual void OnException(ExceptionContext filterContext)
        {
        }
    }
}
