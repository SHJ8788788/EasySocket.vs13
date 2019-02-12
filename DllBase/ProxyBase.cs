using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllBase
{
    /// <summary>
    /// 代理方法类，需要使用的基础远程调用方法在此处描述
    /// </summary>
    public static class ProxyBase
    {

        /// <summary>
        /// 上线通知
        /// </summary>
        /// <param name="client"></param>
        /// <param name="account">帐号</param>
        public static void LoginNotify(this IClient client,string account)
        {          
            foreach (var session in client.ClientSessions)
            {
                session.InvokeApi("LoginNotify",account);
            }
        }

        /// <summary>
        /// 下线通知
        /// </summary>
        /// <param name="client"></param>
        /// <param name="account">帐号</param>
        public static void LogoffNotify(this IClient client, string account)
        {
            foreach (var session in client.ClientSessions)
            {
                session.InvokeApi("LogoffNotify", account);
            }
        }
    }
}
