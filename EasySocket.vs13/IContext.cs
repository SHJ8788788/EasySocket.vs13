using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasySocket.vs13
{
    /// <summary>
    /// 会话请求的上下文
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// 获取当前会话对象
        /// </summary>
        ISession Session { get; }
        //<summary>
        //获取当前会话收到的数据读取器     
        //</summary>
        ISessionStreamReader StreamReader { get;}

        /// <summary>
        /// 获取所有会话对象
        /// </summary>
        ISessionManager AllSessions { get; }
    }
}
