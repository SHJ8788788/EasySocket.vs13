using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM00
{
    partial class ClientProxy
    {
        /// <summary>
        /// OPC校验注册
        /// </summary>
        /// <returns></returns>
        public static Task<bool> Verification(string msg)
        {
            return Instance.InvokeApi<bool>("Verification", msg);
        }
        /// <summary>
        /// Tag信号发生变化
        /// </summary>
        /// <returns></returns>
        public static Task<bool> TagEventChange(TagSimple tag)
        {
            return Instance.InvokeApi<bool>("TagEventChange", tag);
        }
    }
}
