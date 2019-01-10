using EasySocket.vs13.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.Exceptions
{
    /// <summary>
    /// 表示Api不存在引发的异常
    /// </summary>
    [DebuggerDisplay("Message = {Message}")]
    public class ApiNotExistException : Exception
    {
        /// <summary>
        /// 获取Api信息
        /// </summary>
        public string Msg { get; private set; }

        /// <summary>
        /// Api不存在引发的异常
        /// </summary>
        /// <param name="apiKey">Api信息</param>
        public ApiNotExistException(ApiKey apiKey)
            : base(string.Format("请求的{0}不存在", apiKey.ToString()))
        {
            this.Msg = apiKey.ToString();
        }

        /// <summary>
        /// Api不存在引发的异常
        /// </summary>
        /// <param name="name">Api名称</param>
        public ApiNotExistException(string name)
            : base(string.Format("请求的{0}不存在", name.ToString()))
        {
            this.Msg = name.ToString();
        }
    }
}
