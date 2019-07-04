using DllBase;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllClient
{
    /// <summary>
    /// 代理方法类，需要使用的客户端远程调用方法在此处描述
    /// </summary>
    public static class ProxyClient
    {
        /// <summary>
        /// 炉内支数发生变化
        /// </summary>
        /// <returns></returns>
        public static void FurnChanged(this IClient client, List<FurnInfo> furnInfos)
        {          
            foreach (var session in client.ClientSessions)
            {
                session.InvokeApi("FurnChanged", furnInfos);
            }
        }

        /// <summary>
        /// 轧线辊道发生变化
        /// </summary>
        /// <returns></returns>
        public static void MillChanged(this IClient client, string message)
        {
            foreach (var session in client.ClientSessions)
            {
                session.InvokeApi("MillChanged", message);
            }
        }
    }
}
