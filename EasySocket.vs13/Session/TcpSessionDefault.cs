using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13
{
    public class TcpSessionDefault<T> :TcpSessionBase<T> 
    {
        public TcpSessionDefault(T connId)
            : base(connId)
        {
            //服务端创建session时，会话状态为已连接
            base.IsConnected = true;
        }
    }
}
