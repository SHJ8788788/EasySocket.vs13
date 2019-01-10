using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13
{
    /// <summary>
    /// 定义监听服务的行为
    /// </summary>
    public interface IListener : IDisposable
    {
        /// <summary>
        /// 使用中间件
        /// </summary>
        /// <param name="middleware">协议中间件</param>
        void Use(IMiddleware middleware);

        /// <summary>
        /// 使用插件
        /// </summary>
        /// <param name="plug">插件</param>
        void UsePlug(IPlug plug);

        /// <summary>
        /// 开始启动监听        
        /// </summary>
        void Start();

        /// <summary>
        /// 服务停止
        /// </summary>
        void Stop(); 
        #region IDisposable

        #endregion
    }
}
