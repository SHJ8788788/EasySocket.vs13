using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPSocketCS;
using System.Runtime.InteropServices;

namespace EasySocket.vs13
{
    
    public abstract class TcpListenerBase<T> : IListener
    {
        //中间件管理器
        private MiddlewareManager middlewareManager = new MiddlewareManager();
        //会话管理器
        private TcpSessionManager<T> sessionManager = new TcpSessionManager<T>();
        /*回线解析器
        private LineNoReaderBase lineNoReader = new LineNoXmlReader("please write path！");*/

        //插件管理器
        private PlugManager plugManager = new PlugManager();
        //服务端IP
        public string LocalIP { get; private set; }
        //服务端Port
        public ushort LocalPort { get; private set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="ip">ip</param>
        /// <param name="port">端口</param>
        /// <param name="maxConnectionCount">最大连接数</param>
        public TcpListenerBase(string ip, ushort port, uint maxConnectionCount)
        {
            LocalIP = ip;
            LocalPort = port;
            Init(ip,port,maxConnectionCount);
        }

        /// <summary>
        /// 使用协议中间件
        /// </summary>
        /// <typeparam name="TMiddleware">中间件类型</typeparam>
        /// <returns></returns>
        public TMiddleware Use<TMiddleware>() where TMiddleware : IMiddleware
        {
            var middleware = Activator.CreateInstance<TMiddleware>();
            middlewareManager.Use(middleware);
            return middleware;
        }
        /// <summary>
        /// 加载中间件
        /// </summary>
        /// <param name="middleware"></param>
        public void Use(IMiddleware middleware)
        {
            middlewareManager.Use(middleware);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TPlug"></typeparam>
        /// <returns></returns>
        public TPlug UsePlug<TPlug>() where TPlug : IPlug
        {
            //var plug = (TPlug)Activator.CreateInstance(typeof(TPlug));
            var plug = Activator.CreateInstance<TPlug>();
            this.plugManager.Use(plug);
            return plug;
        }
        /// <summary>
        /// 加载插件
        /// </summary>
        /// <param name="plug"></param>
        public void UsePlug(IPlug plug)
        {
            plugManager.Use(plug);
        }
        #region Abstract
        /// <summary>
        /// 提供通讯基础方法，需要重写
        /// </summary>
        public abstract void Init(string ip, ushort port, uint maxConnectionCount);
        /// <summary>
        /// Tcp监听服务启动
        /// </summary>
        public virtual void Start() 
        { 
        }

        /// <summary>
        /// Tcp监听服务停止
        /// </summary>
        public virtual void Stop()
        {
            this.sessionManager.Clear();
        }

        /// <summary>
        /// 断开指定的会话
        /// </summary>
        /// <param name="connId"></param>
        public abstract void Disconnect(T connId);

        /// <summary>
        /// 发送数据
        /// 在其中添加server发送数据相关代码
        /// </summary>
        /// <param name="connId">会话对象指针</param>
        /// <param name="bytes">数据字节流</param>
        /// <returns></returns>
        public abstract bool SendBuffer(T connId, ArraySegment<byte> byteRange);
        #endregion
        #region FuncForPrivate
        /// <summary>
        /// 生成一个新的会话对象
        /// </summary>
        /// <returns></returns>
        private TcpSessionBase<T> GenerateSession(T connId, string remoteIP, ushort remotePort, int headerLength)
        {
            var session = new TcpSessionDefault<T>(connId);
            //绑定委托发送数据、拉取数据委托
            session.ReceiveAsyncHandler = this.OnRequestAsync;
            session.SendBufferHandler = this.SendBuffer;
            session.CloseHandler = this.Disconnect;
            session.DisconnectHandler = this.Disconnect;
            return session;
        }
        /// <summary>
        /// 生成一个新的会话对象
        /// </summary>
        /// <returns></returns>
        private TcpSessionBase<T> GenerateSession(T connId, string remoteIP, ushort remotePort)
        {
            var session = new TcpSessionDefault<T>(connId);
            //绑定委托发送数据、拉取数据委托
            session.ReceiveAsyncHandler = this.OnRequestAsync;
            session.SendBufferHandler = this.SendBuffer;
            session.CloseHandler = this.Disconnect;
            session.DisconnectHandler = this.Disconnect;
            return session;
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
                StreamReader = session.StreamReader,
                AllSessions = this.sessionManager
            };
        }
        /// <summary>
        /// 会话在收到请求数据后调用此方法
        /// 执行中间件
        /// </summary>
        /// <param name="session">会话对象</param>
        /// <returns></returns>
        private async Task OnRequestAsync(ISession session)
        {
            try
            {
                var context = this.CreateContext(session);
                if (this.plugManager.RaiseRequested(this, context))
                {
                    await middlewareManager.RaiseInvoke(context);
                }
                else
                {
                    session.StreamReader.Restore();
                }
            }
            catch (Exception ex)
            {
                this.plugManager.RaiseException(this, ex);
            }
           
        }   
        #endregion
        #region FuncForEvent
        protected bool OnPrepareListen(T soListen)
        {
            // 监听事件到达了,一般没什么用吧?可以添加Filter使用
            return true;
        }
        /// <summary>
        /// 连接请求通知
        /// 接收到连接客户端请求时调用此方法
        /// 在收到连接请求时应该调用会话管理器新增一个会话
        /// </summary>
        /// <param name="ip">客户端地址</param>
        /// <param name="port">客户端端口</param>
        /// <param name="connId">会话对象指针</param>
        /// <returns></returns>
        protected bool OnAcceptAsync(T connId, string ip, ushort port)
        {
            try
            {
                //var lineNoInfo = lineNoReader.GetLineNoInfo(ip, port);
                var session = GenerateSession(connId, ip, port);
                var context = this.CreateContext(session);
                //是否允许此会话
                if (this.plugManager.RaiseConnected(this, context))
                {
                    return sessionManager.Add(session);
                }
                else
                {
                    return false;
                }                
            }
            catch (Exception ex)
            {
                this.plugManager.RaiseException(this, ex);
                this.sessionManager.Remove(connId);                
                return false;
            }        
        }
        /// <summary>
        /// 数据接收通知
        /// 接收到连接客户端数据时调用此方法
        /// </summary>
        /// <param name="connId"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        protected bool OnReceive(T connId, byte[] bytes)
        {
          
            try
            {   //一个connId会单独绑定一个OnReceive事件，所以不同的会话之间不会相互产生影响。
                //而同一个会话将会产生堵塞，必需等HandleResult返回后才进行下一次OnReceive事件触发。
                var session = sessionManager.SelectSession(connId);             
                session.ReceiveData(bytes);    
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 数据发送通知
        /// </summary>
        /// <param name="connId"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        protected void OnSend(T connId, byte[] bytes)
        {
            var session = sessionManager.SelectSession(connId);
            var context = this.CreateContext(session);
            this.plugManager.RaiseSended(this, context);
            //一般没什么用吧?可以添加Filter使用
            // 服务器正在发数据了
            //Console.WriteLine(string.Format(" > [{0},OnSend] -> ({1} bytes)", connId, bytes.Length));
        }
        /// <summary>
        /// 连接关闭通知
        /// </summary>
        /// <param name="connId"></param>
        /// <param name="enOperation"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        protected bool OnClose(T connId, SocketOperation enOperation, int errorCode)
        {
            if (errorCode == 0)
            { 
                //Console.WriteLine(string.Format(" > [{0},OnClose]", connId));                
            }                
            else
            {
                string message = string.Format(" > [{0},OnError] -> OP:{1},CODE:{2}", connId, enOperation, errorCode);
                Log4Ex.LogHelper.MiddlewareException("TcpListenerBase", message);
                //Console.WriteLine(message);
            }
            var session = sessionManager.SelectSession(connId);
            session.IsConnected = false;
            session.errorCode = errorCode;
            var context = this.CreateContext(session);
            //移除已断开的会话连接
            sessionManager.Remove(session);
            //插件触发
            this.plugManager.RaiseDisconnected(this, context);
            return true;            
        }
        /// <summary>
        /// Tcp监听服务关闭通知，服务关闭后触发
        /// </summary>
        /// <returns></returns>
        protected void OnShutdown()
        {
            // 服务关闭了
            string message = " > [OnShutdown]";
            Log4Ex.LogHelper.MiddlewareException("TcpListenerBase", message);
            //Console.WriteLine(" > [OnShutdown]");
        }
        #endregion
        #region IDisposable
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
        ~TcpListenerBase()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">是否也释放托管资源</param>
        protected virtual void Dispose(bool disposing)
        {   
            //this.acceptArg.Dispose();
            this.sessionManager.Dispose();
            this.plugManager.Clear();
            this.middlewareManager.Clear();

            if (disposing == true)
            {
                this.sessionManager = null;
                this.plugManager = null;
                this.middlewareManager = null;
                this.sessionManager = null;  
            }
        }
        #endregion
    }
}
