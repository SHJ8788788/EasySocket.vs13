using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.Telegram.Easy.Context
{
    /// <summary>
    /// 表示Easy协议请求上下文
    /// </summary>
    [DebuggerDisplay("Packet = {Packet}")]
    public class RequestContext
    {
        /// <summary>
        /// 获取当前会话对象
        /// </summary>
        public EasySession Session { get; private set; }

        /// <summary>
        /// 获取协议数据包对象
        /// </summary>
        public EasyPacket Packet { get; private set; }

        /// <summary>
        /// 获取所有会话对象
        /// </summary>
        public ISessionManager AllSessions { get; private set; }

        /// <summary>
        /// 获取所有Easy协议会话对象
        /// </summary>
        public IEnumerable<EasySession> EasySessions
        {
            get
            {
                return this
                    .AllSessions
                    .FilterWrappers<EasySession>();
            }
        }

        /// <summary>
        /// 获取所有Easy协议会话对象中指定key的Session
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public EasySession EasySessionByFilter(string key)
        {
            return this
                .AllSessions
                .FilterWrappers<EasySession>()
                .Where(p => p.Tag.ContainsKey(key)).FirstOrDefault();
        }

        /// <summary>
        /// 获取所有Easy协议会话对象中指定key value的Session
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public EasySession EasySessionByFilter(string key,string value)
        {
            return this
                .AllSessions
                .FilterWrappers<EasySession>()
                .Where(p => p.Tag.Get(key).AsString()==value).FirstOrDefault();
        }

        /// <summary>
        /// 请求上下文
        /// </summary>
        /// <param name="session">当前会话对象</param>
        /// <param name="packet">数据包对象</param>
        /// <param name="allSessions">所有会话对象</param>
        internal RequestContext(EasySession session, EasyPacket packet, ISessionManager allSessions)
        {
            this.Session = session;
            this.Packet = packet;
            this.AllSessions = allSessions;
        }

        /// <summary>
        /// 字符串显示
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Packet.ToString();
        }
    }
}
