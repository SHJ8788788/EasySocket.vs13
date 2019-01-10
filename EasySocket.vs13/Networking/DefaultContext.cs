using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasySocket.vs13
{
    public class DefaultContext: IContext
    {
        /// <summary>
        /// 获取当前会话对象
        /// </summary>
        public ISession Session { get; set; }
        //<summary>
        //获取当前会话收到的数据读取器     
        //</summary>
        public ISessionStreamReader StreamReader { get; set; }
        /// <summary>
        /// 获取所有会话对象
        /// </summary>
       public ISessionManager AllSessions { get; set; }
     
    }
}
