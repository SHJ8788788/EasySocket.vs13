using HPSocketCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasySocket.vs13.Session
{
    /// <summary>
    /// 客户端专用session，实现基本的发送，接收功能
    /// 继承此类后可对接收的数据进一步的拆包处理
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class TcpSessionClient : TcpSessionBase
    {
        /// <summary>
        /// 使用HPSocketCS
        /// </summary>
        protected HPSocketCS.TcpClient client = new HPSocketCS.TcpClient();
        public String Ip { get; set; }
        protected ushort Port { get; set; }
        /// <summary>
        /// 允许断线重连
        /// </summary>
        public bool ReconnectEnable { get; set; }


        /// <summary>
        /// true:异步 false:同步
        /// </summary>
        public bool Async { get; set; }
        /// <summary>
        /// 监听通讯的委托
        /// </summary>
        public Action<string> MsgHandle = default(Action<string>);

        /// <summary>
        /// 重新连接成功后触发
        /// </summary>
        public Action ReconnectCompleteHandle { get; set; }
        /// <summary>
        /// 重连接时触发
        /// </summary>
        public Action ReconnectStartingHandle { get; set; }
        /// <summary>
        /// 成功连接或断开之后触发
        /// </summary>
        public Action ConnectCompleteHandle { get; set; }
        /// <summary>
        /// 监听通讯关闭的委托
        /// </summary>
        public Action CloseHandle = default(Action);
        public TcpSessionClient()
            : base()
        {
            #region Client初始化
            // 设置client事件
            client.OnPrepareConnect += new TcpClientEvent.OnPrepareConnectEventHandler(OnPrepareConnect);
            client.OnConnect += new TcpClientEvent.OnConnectEventHandler(OnConnect);
            client.OnSend += new TcpClientEvent.OnSendEventHandler(OnSend);
            client.OnReceive += new TcpClientEvent.OnReceiveEventHandler(OnReceive);
            client.OnClose += new TcpClientEvent.OnCloseEventHandler(OnClose);
            client.KeepAliveInterval = 3000;
            client.KeepAliveTime = 1000;
            #endregion
            //客户端创建（绑定）session时，会话状态为未连接
            base.IsConnected = false;
        }
        /// <summary>
        /// 启动客户端
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public virtual bool Connect(String ip, ushort port)
        {
            if (client.Connect(ip, port, Async))
            {
                this.Ip = ip;
                this.Port = port;
                if (Async == false)
                {
                    //正在运行
                    return client.IsStarted;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 断线重连
        /// </summary>
        /// <returns></returns>
        public virtual bool ReConnectAsync()
        {
            while (true)
            {
                if (client.State == ServiceState.Stoped)
                {
                    if (this.ReconnectStartingHandle != null)
                    {
                        Task.Run(() => this.ReconnectStartingHandle());
                    }
                    if (this.Connect(Ip, Port))
                    {
                        base.IsConnected = true;
                        if (this.ReconnectCompleteHandle != null)
                        {
                            Task.Run(() => this.ReconnectCompleteHandle());
                        }
                        return true;
                    }
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }
        /// <summary>
        /// 停止客户端
        /// </summary>
        public virtual bool Stop()
        {
            if (client.Stop())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #region FuncForOverrde
        /// <summary>
        /// 接收数据
        /// 调用接收数据后委托
        /// </summary>
        /// <param name="bytes">接收的数据</param>
        /// <returns></returns>
        public override TcpSessionBase ReceiveData(byte[] bytes)
        {
            base.StreamReader.WriteBytes(bytes);
            this.OnReceiveAsync(this);
            return this;
        }
        /// <summary>
        /// 发送字节流数据数据
        /// </summary>
        /// <param name="byteRange"></param>
        public override bool SendData(ArraySegment<byte> byteRange)
        {
            if (byteRange.Count == 0)
            {
                return false;
            }

            // 发送
            if (client.Send(byteRange.Array, byteRange.Count))
            {
                //AddMsg(string.Format("$ ({0}) Send OK --> {1}", connId, send));
                return true;
            }
            else
            {
                //AddMsg(string.Format("$ ({0}) Send Fail --> {1} ({2})", connId, send, bytes.Length));
                return false;
            }
        }
        #endregion
        #region Func
        /// <summary>
        /// 当接收到远程端的数据时，将触发此方法   
        /// </summary>       
        /// <param name="streamReader">接收到的数据读取器</param>
        /// <returns></returns>
        protected abstract Task OnReceiveAsync(ISession session);
        #endregion
        #region Event
        private HandleResult OnPrepareConnect(TcpClient sender, IntPtr socket)
        {
            return HandleResult.Ok;
        }
        private HandleResult OnConnect(TcpClient sender)
        {
            // 已连接 到达一次

            // 如果是异步联接,更新界面状态
            //this.Invoke(new ConnectUpdateUiDelegate(ConnectUpdateUi));
            var msg = string.Format(" > [{0},OnConnected]", sender.ConnectionId);
            //异常通知，在网络发生变化时触发，可用时消息显示
            if (this.ConnectCompleteHandle!=null)
            {
                Task.Run(() => this.ConnectCompleteHandle());
            }
            if (this.MsgHandle!=null)
            {
                Task.Run(() => this.MsgHandle(msg));
            }
            base.IsConnected = true;
            return HandleResult.Ok;
        }
        private HandleResult OnSend(TcpClient sender, byte[] bytes)
        {
            // 客户端发数据了
            //AddMsg(string.Format(" > [{0},OnSend] -> ({1} bytes)", sender.ConnectionId, bytes.Length));
            var msg = string.Format(" > [{0},OnSend] -> ({1} bytes)", sender.ConnectionId, bytes.Length);
            //this.MsgHandle(msg);
            // 数据到达了
            return HandleResult.Ok;
        }
        private HandleResult OnReceive(TcpClient sender, byte[] bytes)
        {
            try
            {   //一个connId会单独绑定一个OnReceive事件，所以不同的会话之间不会相互产生影响。
                //而同一个会话将会产生堵塞，必需等HandleResult返回后才进行下一次OnReceive事件触发。
                this.ReceiveData(bytes);
                var msg = string.Format(" > [{0},OnReceiveEnd] ->Time({1}) Length({2})", sender.ConnectionId, DateTime.Now, bytes.Length.ToString());
                //this.MsgHandle(msg);
                return HandleResult.Ok;
            }
            catch
            {
                return HandleResult.Error;
            }
        }
        private HandleResult OnClose(TcpClient sender, SocketOperation enOperation, int errorCode)
        {
            //if (errorCode == 0)
            //    // 连接关闭了
            //    AddMsg(string.Format(" > [{0},OnClose]", sender.ConnectionId));
            //else
            //    // 出错了
            //    AddMsg(string.Format(" > [{0},OnError] -> OP:{1},CODE:{2}", sender.ConnectionId, enOperation, errorCode));

            //// 通知界面,只处理了连接错误,也没进行是不是连接错误的判断,所以有错误就会设置界面
            //// 生产环境请自己控制
            //this.Invoke(new SetAppStateDelegate(SetAppState), AppState.Stoped);
            base.IsConnected = false;
            var msg = string.Format(" > [{0},OnError] -> OP:{1},CODE:{2}", sender.ConnectionId, enOperation, errorCode);
            //异常通知，在网络发生变化时触发，可用时消息显示
            if (this.MsgHandle != null)
            {
                Task.Run(() => this.MsgHandle(msg));
            }            
            //异步执行断线通知,在用户断开后可进行操作
            if (this.CloseHandle != null)
            {
                Task.Run(() => this.CloseHandle());
            }
            //根据错误代码判断连接是正常断开还是异常断开
            //errorCode:0正常断开
            if (errorCode !=0)
            {
                //断线重连判断
                Task.Run(() =>
                {
                    if (ReconnectEnable == true)
                        this.ReConnectAsync();
                }); 
            }
            return HandleResult.Ok;
        }
        #endregion
    }
}
