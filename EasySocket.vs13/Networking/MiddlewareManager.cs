using EasySocket.vs13.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13
{
    /// <summary>
    /// 表示中间件管理器
    /// </summary>
    public class MiddlewareManager
    {
        /// <summary>
        /// 所有中间件
        /// </summary>
        private readonly LinkedList<IMiddleware> middlewares = new LinkedList<IMiddleware>();
        /// <summary>
        /// Tcp中间件管理器
        /// </summary>
        public MiddlewareManager()
        {
            //默认中间件
            this.middlewares.AddLast(new DefaultMiddleware());
        }
        /// <summary>
        /// 使用协议中间件
        /// </summary>
        /// <param name="middleware">协议中间件</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Use(IMiddleware middleware)
        {
            if (middleware == null)
            {
                throw new ArgumentNullException();
            }

            this.middlewares.AddBefore(this.middlewares.Last, middleware);
            var node = this.middlewares.First;
            while (node.Next != null)
            {
                node.Value.Next = node.Next.Value;
                node = node.Next;
            }
        }
        /// <summary>
        /// 清除所有协议中间件
        /// </summary>
        public void Clear()
        {
            this.middlewares.Clear();
        }

        /// <summary>
        /// 触发并执行中间件
        /// </summary>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        public Task RaiseInvoke(IContext context)
        {
            return this.middlewares.First.Value.Invoke(context);
        }
    }
}
