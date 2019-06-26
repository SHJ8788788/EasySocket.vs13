using EasySocket.vs13.Core;
using EasySocket.vs13.Telegram.Easy.Context;
using Log4Ex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.Telegram.Easy
{
    /// <summary>
    /// 日志过滤器
    /// </summary>
    public class EasyLogFilter : EasyFilterAttribute
    {
        private string message;
        public string Action { get;private set; }
        public string UniqueIdentifier { get; private set; }
        public EasyLogFilter(string message)
        {
            this.message = message;
        }

        protected override void OnExecuting(ActionContext filterContext)
        {
            Action = filterContext.Action.ToString();
            UniqueIdentifier = filterContext.Action.UniqueIdentifier;
            var log = string.Format("Time:{0} Client:{1} Action:{2} Message:{3}", DateTime.Now.ToString("mm:ss"), filterContext.Packet, filterContext.Action, this.message);
            LogHelper.MethodBegin(Action.ToString());
            //Console.WriteLine(log);
        }

        protected override void OnExecuted(ActionContext filterContext)
        {
            //var log = string.Format("Time:{0} Client:{1} Action:{2} Message:{3}", DateTime.Now.ToString("mm:ss"), filterContext.Packet, filterContext.Action, this.message);
            LogHelper.MethodEnd(Action.ToString());
            //Console.WriteLine(log);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            //var log = string.Format("Time:{0} Client:{1} Action:{2} Message:{3}", DateTime.Now.ToString("mm:ss"), filterContext.Packet, filterContext.Exception.Message, this.message);
            var log = filterContext.Exception.Message;
            LogHelper.MethodException(Action.ToString(),log);
            //Console.WriteLine(log);
        }

    }
}
