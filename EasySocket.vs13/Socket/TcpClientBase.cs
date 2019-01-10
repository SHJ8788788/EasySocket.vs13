using EasySocket.vs13.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13
{
    public abstract class TcpClientBase<T> : IWrapper,IDisposable
    {
        /// <summary>
        /// 会话对象
        /// </summary>
        public TcpSessionClient<T> Session { get; private set; }

        /// <summary>
        /// Tcp客户端抽象类
        /// </summary>
        public TcpClientBase(T connId, int headerLength)
        {
            this.Session = new TcpSessionClient<T>(connId);
            this.BindHandler(this.Session);            
        }

        /// <summary>
        /// 绑定会话的处理方法
        /// </summary>
        /// <param name="session">会话</param>
        private void BindHandler(TcpSessionBase<T> session)
        {
            session.ReceiveAsyncHandler = this.ReceiveHandler;
            session.SendBufferHandler = this.SendHandler;
            session.DisconnectHandler = this.DisconnectHandler;
        }

        /// <summary>
        /// 接收处理
        /// </summary>
        /// <param name="session">会话</param>
        private Task ReceiveHandler(TcpSessionBase<T> session)
        {
            var context = this.CreateContext(session);
            return this.OnReceiveAsync(context);
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="session">会话</param>
        private bool SendHandler(T connId, ArraySegment<byte> byteRange)
        {
            return this.SendBuffer(byteRange);
        }

        /// <summary>
        /// 关闭连接处理
        /// </summary>
        /// <param name="session">会话</param>
        private void DisconnectHandler(T connId)
        {
            this.OnDisconnected();
        }

        /// <summary>
        /// 发送数据
        /// 在其中添加server发送数据相关代码
        /// </summary>
        /// <param name="connId">会话对象指针</param>
        /// <param name="bytes">数据字节流</param>
        /// <returns></returns>
        protected abstract bool SendBuffer(ArraySegment<byte> byteRange);

        /// <summary>
        /// 当接收到远程端的数据时，将触发此方法   
        /// </summary>       
        /// <param name="streamReader">接收到的数据上下文</param>
        /// <returns></returns>
        protected abstract Task OnReceiveAsync(IContext context);

        /// <summary>
        /// 连接断开时
        /// </summary>
        protected abstract void OnDisconnected();

        /// <summary>
        /// 创建上下文对象
        /// </summary>
        /// <param name="session">当前会话</param>
        /// <returns></returns>
        private IContext CreateContext(ISession<T> session)
        {
            return new DefaultContext
            {
                Session = session,
                StreamReader = session.StreamReader
            };
        }

        /// <summary>     
        /// 等待缓冲区数据发送完成
        /// 然后断开和远程端的连接   
        /// </summary>     
        public virtual void Close()
        {
            this.Session.Disconnect();
        }

        /// <summary>
        /// 还原到包装前
        /// </summary>
        /// <returns></returns>
        public ISession UnWrap()
        {
            return this.Session;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public virtual void Dispose()
        {
            this.Session.Dispose();
        }

    }
}
