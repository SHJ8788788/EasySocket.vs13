using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13
{
    /// <summary>
    /// 会话附加信息
    /// </summary>
    public interface ISessionExtra
    {
        /// <summary>
        /// 获取会话数据字典
        /// </summary>
        ITag Tag { get; }

        /// <summary>
        /// 获取会话的协议名
        /// </summary>
        Protocol Protocol { get;set; }
    }
}
