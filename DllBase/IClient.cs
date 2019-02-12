using EasySocket.vs13.Telegram.Easy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllBase
{
    /// <summary>
    /// 对客户端远程调用，必须通过实现此接口
    /// </summary>
    public interface IClient
    {
        IEnumerable<EasySession> OtherSessions { get; }
        IEnumerable<EasySession> ClientSessions { get; }
    }
}
