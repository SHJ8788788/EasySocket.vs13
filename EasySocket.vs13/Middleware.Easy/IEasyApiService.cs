using EasySocket.vs13.Telegram.Easy.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.Telegram.Easy
{
    /// <summary>
    /// 定义Easy协议的Api服务
    /// </summary>
    public interface IEasyApiService : IDisposable
    {
        /// <summary>
        /// 异步执行Api行为
        /// </summary>              
        /// <param name="actionContext">Api行为上下文</param>     
        /// <returns></returns>
        Task ExecuteAsync(ActionContext actionContext);
    }
}
