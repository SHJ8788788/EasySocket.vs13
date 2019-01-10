using EasySocket.vs13.Telegram.Easy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllOpc
{
    public interface IOpc
    {
        EasySession OpcSession { get; }
    }
}
