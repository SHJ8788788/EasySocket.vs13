using EasySocket.vs13.Telegram;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13
{ 
    /// <summary>
    /// 为会话设置额外的信息
    /// </summary>
    public class SessionExtra:ISessionExtra
    {
        /// <summary>
        /// 获取会话数据字典
        /// </summary>
        public ITag Tag { get; set; }
        /// <summary>
        /// 获取会话的协议名
        /// </summary>
        public Protocol Protocol { get; set; }

        public SessionExtra(ITag tag)
        {
            this.Tag = tag;
        }
    }
}
