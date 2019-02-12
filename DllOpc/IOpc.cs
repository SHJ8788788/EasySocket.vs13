using DllBase;
using EasySocket.vs13.Telegram.Easy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllOpc
{
    /// <summary>
    /// 对opc远程调用，必须通过实现此接口
    /// </summary>
    public interface IOpc: IClient
    {
        EasySession OpcSession { get; }
    }
}
