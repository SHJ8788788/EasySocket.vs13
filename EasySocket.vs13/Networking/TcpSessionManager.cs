using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13
{
    class TcpSessionManager<T> : ISessionManager, IEnumerable<TcpSessionBase<T>>, IDisposable
    {
        /// <summary>
        /// 已释放的会话   不用的会话直接close掉，别回收使用了
        /// </summary>
        //private readonly ConcurrentQueue<TcpSessionBase> freeSessions = new ConcurrentQueue<TcpSessionBase>();
        /// <summary>
        /// 工作中的会话
        /// </summary>
        private readonly ConcurrentDictionary<T, TcpSessionBase<T>> workSessions = new ConcurrentDictionary<T, TcpSessionBase<T>>();
        /// <summary>
        /// 获取元素个数
        /// </summary>
        /// <returns></returns>
        public int Count
        {
            get
            {
                return workSessions.Count();
            }
           
        }     
        /// <summary>
        /// 添加一个新的会话
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool Add(TcpSessionBase<T> session)
        {
            return this.workSessions.TryAdd(session.ConnId, session);
        }

        /// <summary>
        /// 移除一个会话
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool Remove(T connId)
        {
            TcpSessionBase<T> session = default(TcpSessionBase<T>);
           if(this.workSessions.TryRemove(connId,out session) == true)
            {
                // 不用的会话直接close掉，别回收使用了
                //this.freeSessions.Enqueue(session);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 移除一个会话
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public bool Remove(TcpSessionBase<T> session)
        {
            if (session == null)
            {
                return false;
            }
            else if(this.workSessions.TryRemove(session.ConnId,out session) == true)
            {
                // 不用的会话直接close掉，别回收使用了
                //this.freeSessions.Enqueue(session);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 移除并清空所有会话
        /// </summary>
        public void Clear()
        {
            foreach (var item in this)
            {
                item.Dispose();
            }
            this.workSessions.Clear();
        }
        /// <summary>
        /// 返回指定的会话对象
        /// 不存在则返回null
        /// </summary>
        /// <param name="connId"></param>
        /// <returns></returns>
        public TcpSessionBase<T> SelectSession(T connId)
        {
            TcpSessionBase<T> session;            
            if ( this.workSessions.TryGetValue(connId,out session) == true)
            {
                return session;
            }
            else
            {
                return null;
            }            
        }

        /// <summary>
        /// 获取会话的包装对象
        /// </summary>
        /// <typeparam name="TWapper">包装类型</typeparam>
        /// <returns></returns>
        IEnumerable<TWapper> ISessionManager.FilterWrappers<TWapper>()
        {
            return this.Select(item => item.Wrapper).OfType<TWapper>();
        }

        /// <summary>
        /// 获取过滤了协议类型的会话对象
        /// </summary>
        /// <param name="protocol">协议类型</param>
        /// <returns></returns>
        IEnumerable<ISession> ISessionManager.FilterProtocol(Protocol protocol)
        {
            return this.Where(item => item.Extra.Protocol == protocol);
        }
        /// <summary>
        /// 获取枚举器
        /// </summary>
        /// <returns></returns>
        public IEnumerator<TcpSessionBase<T>> GetEnumerator()
        {
            return this.workSessions.Values.GetEnumerator();
        }
        /// <summary>
        /// 获取枚举器
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.workSessions.Values.GetEnumerator();
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            foreach (var item in this)
            {
                item.Dispose();
            }
            this.workSessions.Clear();

            //TcpSessionBase session;
            //while (this.freeSessions.TryDequeue(out session))
            //{
            //    session.Dispose();
            //}
        }
    }

    #region unused

    /// <summary>
    /// 申请一个会话
    /// </summary>
    /// <returns></returns>
    //public TcpSessionBase Alloc()
    //{
    //TcpSessionBase session;
    //if (this.freeSessions.TryDequeue(out session)==true)
    //{
    //    return session;
    //}
    //else
    //{
    //    return new TelegramTcpSession();
    //}
    //    return new TelegramTcpSession();
    //}
    #endregion
}
