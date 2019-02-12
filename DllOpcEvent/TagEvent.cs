using DllBase;
using DllFurn;
using DllMill;
using DllOpc;
using EasySocket.vs13.Core;
using EasySocket.vs13.Telegram.Easy;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllOpcEvent
{
    /// <summary>
    /// 接收并分发OPC发出的信号
    /// 关键函数TagEventChange
    /// </summary>
    public class TagEvent : EasyApiService, IOpc
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
                    item != this.CurrentContext.Session &&
                    item.Tag.ContainsKey("category")&&
                    item.Tag.Get("category").Value.ToString() == "client");
            }
        }

        [Api]
        [EasyLogFilter("事件发生变化")]
        public bool TagEventChange(TagSimple tag)
        {
            Console.WriteLine("事件:" + tag.TagName + "值:" + tag.TagValue.ToString());
            if (tag.TagName== "PL_RULU"&& tag.ValueCast<bool>()==true)
            {
               this.FurnIn();
            }
            else if (tag.TagName == "JRL_CHUGANG" && tag.ValueCast<bool>() == true)
            {
               this.FurnOut();
            }
            //粗轧开始
            else if (tag.TagName == "H1YAOGANG" && tag.ValueCast<bool>() == true)
            {
                this.Mill1ActionPaoGang();
            }
            //中轧轧开始7号机架咬钢信号
            else if (tag.TagName == "H7YAOGANG" && tag.ValueCast<bool>() == true)
            {

            }
            //预精轧开始13号机架咬钢信号
            else if (tag.TagName == "H13YAOGANG" && tag.ValueCast<bool>() == true)
            {

            }
            //精轧18号机架抛钢信号
            else if (tag.TagName == "H18YAOGANG" && tag.ValueCast<bool>() == false)
            {
                this.Mill18ActionYaoGang();
            }
            return true;            
        }
    }
}
