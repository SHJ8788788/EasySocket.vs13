using DllBase;
using DllOpc;
using EasySocket.vs13.Core;
using EasySocket.vs13.Telegram.Easy;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllClient
{
    /// <summary>
    /// /为远程客户端提供可执行的Opc执行方法
    /// </summary>
    public class ApiForClientFromOpc : EasyApiService, IOpc     
    {
        EasySession IOpc.OpcSession
        {
            get
            {
                return this.CurrentContext.EasySessionByFilter("Category", "opc");
            }
        }

        /// <summary>
        /// 获取其它已登录的会话
        /// </summary>
        IEnumerable<EasySession> IClient.OtherSessions
        {
            get
            {
                return this
                    .CurrentContext
                    .EasySessions
                    .Where(item => item != this.CurrentContext.Session);
            }
        }

        /// <summary>
        /// 获取来至客户端已登录的会话
        /// </summary>
        IEnumerable<EasySession> IClient.ClientSessions
        {
            get
            {
                return this
                    .CurrentContext
                    .EasySessions
                    .Where(item =>
                    //item != this.CurrentContext.Session &&
                    item.Tag.ContainsKey("category") &&
                    item.Tag.Get("category").Value.ToString() == "client");
            }
        }

        [Api]
        [EasyLogFilter("取信号点值")]
        public string GetTriggerValue(string tagName)
        {
            bool result = this.GetTriggerValueFromOPC(tagName).ToBool();
            string value = "";
            if (result == true)
            {
                value = "1";
            }
            else
            {
                value = "0";
            }
            return value;
        }

        [Api]
        [EasyLogFilter("批量取值")]
        public List<TagSimple> GetTags(List<string> list)
        {
          return  this.OpLinkTags(list);
        }
    }
}
