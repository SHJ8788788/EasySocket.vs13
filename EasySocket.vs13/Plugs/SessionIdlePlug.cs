using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasySocket.vs13.Plugs
{
    /// <summary>
    /// 表示空闲会话检测与关闭插件
    /// </summary>
    public class SessionIdlePlug : PlugBase
    {
        /// <summary>
        /// 空闲时间超时检测timer
        /// </summary>123123
        private static readonly string IdleTimer = "NetworkSocket.IdleTimer";

        /// <summary>
        /// 获取最大空闲时间
        /// </summary>
        protected TimeSpan MaxIdleTime { get; private set; }

        /// <summary>
        /// 空闲会话检测与处理插件       
        /// </summary>
        public SessionIdlePlug()
            : this(TimeSpan.FromMinutes(30))
        {          
        }

        /// <summary>
        /// 空闲会话检测与处理插件       
        /// </summary>
        /// <param name="maxIdleTime">最大空闲时间</param>
        public SessionIdlePlug(TimeSpan maxIdleTime)
        {
            this.MaxIdleTime = maxIdleTime;
        }

        /// <summary>
        /// 设置最大空闲时间
        /// </summary>
        /// <param name="maxIdleTime"></param>
        /// <returns></returns>
        public SessionIdlePlug IdleTime(TimeSpan maxIdleTime)
        {
            this.MaxIdleTime = maxIdleTime;
            return this;
        }

        /// <summary>
        /// 会话连接成功后触发
        /// </summary>
        /// <param name="sender">发生者</param>
        /// <param name="context">上下文</param>
        protected sealed override void OnConnected(object sender, IContext context)
        {
            this.ApplyContextIdle(context);
        }

        /// <summary>
        /// 收到请求后触发
        /// 此方法在先于协议中间件的Invoke方法调用
        /// </summary>
        /// <param name="sender">发生者</param>
        /// <param name="context">上下文</param>
        protected sealed override void OnRequested(object sender, IContext context)
        {
            this.ApplyContextIdle(context);
        }


        /// <summary>
        /// 发送数据后触发
        /// 此方法在先于协议中间件的Invoke方法调用
        /// </summary>
        /// <param name="sender">发生者</param>
        /// <param name="context">上下文</param>
        protected sealed override void OnSended(object sender, IContext context)
        {
            this.ApplyContextIdle(context);
        }

        /// <summary>
        /// 会话断开后触发
        /// </summary>
        /// <param name="sender">发生者</param>
        /// <param name="context">上下文</param>
        protected sealed override void OnDisconnected(object sender, IContext context)
        {
        }

        /// <summary>
        /// 服务异常事件
        /// </summary>
        /// <param name="sender">发生者</param>
        /// <param name="exception">异常</param>
        protected sealed override void OnException(object sender, Exception exception)
        {
        }

        /// <summary>
        /// 过滤上下文
        /// 返回true的上下文将被idle计时检测
        /// </summary>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        protected virtual bool FilterContext(IContext context)
        {
            var tag =  context.Session.Extra.Tag.Get("category");              
            //此处可以根据context中的客户端信息区分，对一般用户设定超时时间，对中间件\OPC则不需要
            if (tag.IsNull)
            {
                 return true;
            }
            else if (tag.Value.ToString()=="opc")
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }


        /// <summary>
        /// idle计时
        /// </summary>
        /// <param name="context">上下文</param>
        private void ApplyContextIdle(IContext context)
        {
            if (this.FilterContext(context) == true)
            {
                context.Session.Extra.Tag
                    .Get(IdleTimer, () => new Timer(this.OnIdleTimeout, context, Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan))
                    .As<Timer>()
                    .Change(this.MaxIdleTime, Timeout.InfiniteTimeSpan);
            }
            else
            {
                context.Session.Extra.Tag.Get(IdleTimer).As<Timer>().Dispose();
            }
        }

        /// <summary>
        /// 会话空闲超时后
        /// </summary>
        /// <param name="contextState">上下文</param>
        private void OnIdleTimeout(object contextState)
        {
            var context = contextState as IContext;
            context.Session.Extra.Tag.Get(IdleTimer).As<Timer>().Dispose();
            context.Session.Disconnect();
            context.StreamReader.Clear();
        }
    }
}
