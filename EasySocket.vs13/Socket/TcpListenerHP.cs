using HPSocketCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13
{
    /// <summary>
    /// 表示Tcp监听服务
    /// 此处使用通用的Tcp框架 HPSocket
    /// 泛型作为指定会话的唯一id类型，此处使用HPSocket框架使用指针
    /// </summary>
    public class TcpListenerHP : TcpListenerBase<IntPtr>
    {
        //通讯服务
        private TcpServer server  = new TcpServer();
        ///// <summary>
        ///// 唯一实例
        ///// </summary>
        //private static readonly Lazy<TcpListenerHP> instance = new Lazy<TcpListenerHP>(() => new TcpListenerHP("",11));

        ///// <summary>
        ///// 获取唯一实例
        ///// </summary>
        //public static TcpListenerHP Instance
        //{
        //    get { return instance.Value; }
        //}

        /// <summary>
        /// 初始化
        /// 默认最大连接数128
        /// </summary>
        /// <param name="ip">ip</param>
        /// <param name="port">端口</param>
        public TcpListenerHP(string ip, ushort port)
            : this(ip, port, 128)
        { }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="ip">ip</param>
        /// <param name="port">端口</param>
        /// <param name="maxConnectionCount">最大连接数</param>
        public TcpListenerHP(string ip, ushort port, uint maxConnectionCount)
            : base(ip, port, maxConnectionCount)
        { }
        #region Override
        /// <summary>
        /// 初始化方法
        /// 通过重写此方法新增Tcp相关内容
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="maxConnectionCount"></param>
        public override void Init(string ip, ushort port, uint maxConnectionCount)
        {
            server.IpAddress = ip;
            server.Port = port;
            server.MaxConnectionCount = maxConnectionCount;

            server.KeepAliveInterval = 3000;
            server.KeepAliveTime = 1000;

            // 设置服务器事件
            server.OnPrepareListen += new TcpServerEvent.OnPrepareListenEventHandler(OnPrepareListenHP);
            server.OnAccept += new TcpServerEvent.OnAcceptEventHandler(OnAcceptHP);
            server.OnSend += new TcpServerEvent.OnSendEventHandler(OnSendHP);
            server.OnReceive += new TcpServerEvent.OnReceiveEventHandler(OnReceiveHP);
            server.OnClose += new TcpServerEvent.OnCloseEventHandler(OnCloseHP);
            server.OnShutdown += new TcpServerEvent.OnShutdownEventHandler(OnShutdownHP);
        }
        /// <summary>
        /// Tcp监听服务启动
        /// </summary>
        public override void Start()
        {
            server.Start();
            base.Start();
        }
        /// <summary>
        /// Tcp监听服务停止
        /// </summary>
        public override void Stop()
        {
            server.Stop();
            base.Stop();
        }
        /// <summary>
        /// 断开指定的会话
        /// </summary>
        /// <param name="connId"></param>
        public override void Disconnect(IntPtr connId)
        {
            server.Disconnect(connId);            
        }
        public override bool SendBuffer(IntPtr connId, ArraySegment<byte> byteRange)
        {
            return server.Send(connId, byteRange.Array, byteRange.Count);
        }
        #endregion
        #region Event
        HandleResult OnPrepareListenHP(IntPtr soListen)
        {
            // 监听事件到达了,一般没什么用吧?可以添加Filter使用
            base.OnPrepareListen(soListen);
            return HandleResult.Ok;
        }
        HandleResult OnAcceptHP(IntPtr connId, IntPtr pClient)
        {

            // 客户进入了
            // 获取客户端ip和端口
            string ip = string.Empty;
            ushort port = 0;
            if (server.GetRemoteAddress(connId, ref ip, ref port))
            {                
                var result = base.OnAcceptAsync(connId, ip, port);
                Console.WriteLine(string.Format(" > [{0},OnAccept] -> PASS({1}:{2}) ->Result({3})", connId, ip.ToString(), port,result.ToString()));
                return result == true ? HandleResult.Ok : HandleResult.Error;
            }
            else
            {
                Console.WriteLine(string.Format(" > [{0},OnAccept] -> Server_GetClientAddress() Error", connId));
                return HandleResult.Error;
            }
        }
        HandleResult OnSendHP(IntPtr connId, byte[] bytes)
        {
            // 服务器发数据了
            base.OnSend(connId, bytes);
            return HandleResult.Ok;
        }
        HandleResult OnReceiveHP(IntPtr connId, byte[] bytes)
        {
            if (base.OnReceive(connId, bytes))
            {
                return HandleResult.Ok;
            }
            else
            {
                return HandleResult.Error;
            }
        }
        HandleResult OnCloseHP(IntPtr connId, SocketOperation enOperation, int errorCode)
        {
            base.OnClose(connId, enOperation, errorCode);
            return HandleResult.Ok;
        }
        HandleResult OnShutdownHP()
        {
            base.OnShutdown();
            return HandleResult.Ok;
        }
        #endregion
        #region Setting
        #endregion
        #region IDisposable
        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">是否也释放托管资源</param>
        protected override void Dispose(bool disposing)
        {
            if (this.server.IsStarted == true)
            {
                this.server.Stop();
                this.server.Destroy();
            }

            if (disposing == true)
            {
                this.server = null;
            }
        }
        #endregion
    }
}
