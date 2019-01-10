using EasySocket.vs13.LineNos;
using HPSocketCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13
{
    /// <summary>
    /// 采用电文回线方式，进一步配置生成会话
    /// 配置文档中已配置的会话(ip\port)明细将会加载
    /// 不存在的会话将使用默认会话配置加载
    /// </summary>
   public class TelegramTcpSession<T>:TcpSessionBase<T>
    {
        /// <summary>
        /// 会话本地监听IP
        /// </summary>
        public string LocalIP { get; private set; }
        /// <summary>
        /// 会话监听端口
        /// </summary>
        public ushort LocalPort { get; private set; }
        /// <summary>
        /// 会话远程连接IP
        /// </summary>
        public string RemoteIP { get; private set; }
        /// <summary>
        /// 会话远程连接端口
        /// </summary>
        public ushort RemotePort { get; private set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="server">HPSocket组件</param>
        /// <param name="connId">会话对象指针或唯一ID</param>
        /// <param name="remoteIP"></param>
        /// <param name="remotePort"></param>
        public TelegramTcpSession(string localIP, ushort localPort, string remoteIP, ushort remotePort, T connId, LineNoInfo lineNoInfo)
            : base(connId, lineNoInfo)
        {
            //会话IP端口设定
            this.LocalIP = localIP;
            this.LocalPort = localPort;
            this.RemoteIP = remoteIP;
            this.RemotePort = remotePort;

            this.IsConnected = true;
        }
       /// <summary>
       /// 初始化
       /// </summary>
       /// <param name="server">HPSocket组件</param>
       /// <param name="connId"></param>
       /// <param name="remoteIP"></param>
       /// <param name="remotePort"></param>
       public TelegramTcpSession(TcpServer server,T connId,string remoteIP,ushort remotePort)
            : this(server.IpAddress, server.Port, remoteIP, remotePort, connId) 
       {
       }

       /// <summary>
       /// 初始化
       /// </summary>
       /// <param name="server">HPSocket组件</param>
       /// <param name="connId"></param>
       /// <param name="remoteIP"></param>
       /// <param name="remotePort"></param>
       public TelegramTcpSession(string localIP,ushort localPort,string remoteIP, ushort remotePort,T connId)
           :base(connId)
       {
           //会话IP端口设定
           this.LocalIP = localIP;
           this.LocalPort = localPort;
           this.RemoteIP = remoteIP;
           this.RemotePort = remotePort;
       }    
    }
}
