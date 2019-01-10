using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.Plugs
{
    /// <summary>
    /// 表示服务器插件基础类
    /// </summary>
    public abstract class PlugBase:IPlug
    {
        /// <summary>
        /// 会话连接成功后触发    
        /// 如果关闭了会话，将停止传递给下个插件的OnConnected
        /// </summary>
        /// <param name="sender">发生者</param>
        /// <param name="context">上下文</param>
        protected virtual void OnConnected(object sender, IContext context)
        {
        }


        /// <summary>
        /// 收到请求后触发
        /// 如果关闭了会话或清空了数据，将停止传递给下个插件的OnRequested
        /// </summary>
        /// <param name="sender">发生者</param>
        /// <param name="context">上下文</param>
        protected virtual void OnRequested(object sender, IContext context)
        {
        }

        /// <summary>
        /// 发送数据后后触发
        /// 如果关闭了会话或清空了数据，将停止传递给下个插件的OnSended
        /// </summary>
        /// <param name="sender">发生者</param>
        /// <param name="context">上下文</param>
        protected virtual void OnSended(object sender, IContext context)
        {
        }

        /// <summary>
        /// 会话断开后触发
        /// </summary>
        /// <param name="sender">发生者</param>
        /// <param name="context">上下文</param>
        protected virtual void OnDisconnected(object sender, IContext context)
        {
        }

        /// <summary>
        /// 服务异常后触发
        /// </summary>
        /// <param name="sender">发生者</param>
        /// <param name="exception">异常</param>
        protected virtual void OnException(object sender, Exception exception)
        {
        }


        #region IPlug
        /// <summary>
        /// 会话连接成功后触发    
        /// 如果关闭了会话，将停止传递给下个插件的OnConnected
        /// </summary>
        /// <param name="sender">发生者</param>
        void IPlug.OnConnected(object sender, IContext context)
        {
            this.OnConnected(sender, context);
        }


        /// <summary>
        /// 收到请求后触发
        /// 如果关闭了会话，将停止传递给下个插件的OnRequested
        /// </summary>
        /// <param name="sender">发生者</param>
        /// <param name="context">上下文</param>
        /// </summary>
        /// <param name="sender">发生者</param>
        /// <param name="context">上下文</param>
        void IPlug.OnRequested(object sender, IContext context)
        {
            this.OnRequested(sender, context);
        }


        /// <summary>
        /// 发送数据后触发
        /// 如果关闭了会话，将停止传递给下个插件的OnSended
        /// </summary>
        /// <param name="sender">发生者</param>
        /// <param name="context">上下文</param>
        /// </summary>
        /// <param name="sender">发生者</param>
        /// <param name="context">上下文</param>
        void IPlug.OnSended(object sender, IContext context)
        {
            this.OnSended(sender, context);
        }


        /// <summary>
        /// 会话断开后触发
        /// </summary>
        /// <param name="sender">发生者</param>
        /// <param name="context">上下文</param>
        void IPlug.OnDisconnected(object sender, IContext context)
        {
            this.OnDisconnected(sender, context);
        }


        /// <summary>
        /// 服务异常后触发
        /// </summary>
        /// <param name="sender">发生者</param>
        /// <param name="exception">异常</param>
        void IPlug.OnException(object sender, Exception exception)
        {
            this.OnException(sender, exception);
        }
        #endregion
    }
}
