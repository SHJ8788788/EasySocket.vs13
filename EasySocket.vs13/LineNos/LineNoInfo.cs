using EasySocket.vs13.Telegram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.LineNos
{
    /// <summary>
    /// 回线明细
    /// 每个会话对象都需要初始化一个LineNoInfo实例
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class LineNoInfo
    {
        /// <summary>
        /// 会话端ip
        /// </summary>
        public string IpAddress { get; set; }
        /// <summary>
        /// 会话端端口
        /// </summary>
        public ushort Port { get; set; }
        /// <summary>
        /// 回线号
        /// </summary>
        public string LineNo { get; set; }
        /// <summary>
        /// 电文协议号
        /// </summary>
        public string HeadType { get; set; }
        /// <summary>
        /// 电文头长度
        /// </summary>
        public int HeaderLength { get { return Telegram.HeaderLength; } }
        /// <summary>
        /// 电文配置内容
        /// </summary>
        public TelegramInfo Telegram { get; set; }
        ///// <summary>
        ///// 电文体长度
        ///// </summary>
        //public string BodyLength { get; set; }
        /// <summary>
        /// 电文头
        /// </summary>
        //public IHeader Header { get; set; }
        ///// <summary>
        ///// 电文体
        ///// </summary>
        //public IBody Body { get; set; }

        /// <summary>
        /// 包区分信息
        /// </summary>
        //public PkgInfo PkgInfo { get; set; }
    }
}
