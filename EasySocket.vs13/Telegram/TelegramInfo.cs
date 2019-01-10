using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.Telegram
{
    /// <summary>
    /// 电文协议
    /// </summary>
    public class TelegramInfo
    {
        public int HeaderLength { get; set; }
        public int BodyLength { get; set; }
        public string MiddlewareName { get; set; }
    }
}
