using DllBase;
using DllCoil;
using DllFurn;
using DllMill;
using DllOpc;
using EasySocket.vs13.Core;
using EasySocket.vs13.Telegram.Easy;
using Log4Ex;
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
            LogHelper.Info($"TagName:{tag.TagName} TagValue:{tag.ValueCast<string>()}");   
            //加热炉入炉
            if (tag.TagName== "JRL_RL"&& tag.ValueCast()==true)
            {              
               this.FurnIn();               
            }
            //加热炉出炉
            else if (tag.TagName == "JRL_CL" && tag.ValueCast() == true)
            {
               this.FurnOut();
            }
            //粗轧咬钢信号-轧制开始
            else if (tag.TagName == "H1YAOGANG" && tag.ValueCast() == true)
            {
                this.Mill1ActionYaoGang();
            }
            //1号轧机抛钢信号信号
            else if (tag.TagName == "H1YAOGANG" && tag.ValueCast() == false)
            {
                this.Mill1ActionPaoGang();
            }
            //粗轧抛钢信号
            else if (tag.TagName == "H6YAOGANG" && tag.ValueCast() == false)
            {
                this.Mill6ActionPaoGang();
            }
            //中轧开始7号机架咬钢信号
            else if (tag.TagName == "H7YAOGANG" && tag.ValueCast() == true)
            {
                this.Mill7ActionYaoGang();
            }
            //中轧结束12号机架抛钢信号
            else if (tag.TagName == "H12YAOGANG" && tag.ValueCast() == false)
            {
                this.Mill12ActionPaoGang();
            }
            //预精轧开始13号机架咬钢信号
            else if (tag.TagName == "H13YAOGANG" && tag.ValueCast() == true)
            {
                this.Mill13ActionYaoGang();
            }
            //预精轧开始18号机架抛钢信号
            else if (tag.TagName == "H18YAOGANG" && tag.ValueCast() == false)
            {
                this.Mill18ActionPaoGang();
            }
            //精轧机咬钢信号
            else if (tag.TagName == "JZYAOGANG" && tag.ValueCast() == true)
            {
                this.JZActionYaoGang();
            }
            //精轧机抛钢信号
            else if (tag.TagName == "JZYAOGANG" && tag.ValueCast() == false)
            {
                this.JZActionPaoGang();
            }
            //吐丝机咬钢信号
            else if (tag.TagName == "TSYAOGANG" && tag.ValueCast() == true)
            {
                
            }
            //吐丝机抛钢信号--轧制结束
            else if (tag.TagName == "TSYAOGANG" && tag.ValueCast() == false)
            {
                this.TSActionPaoGang();
            }
            //集卷上钩
            else if (tag.TagName== "HookA")
            {
                this.CoilHookFinish(tag.ValueCast<int>());
            }
            else
            {
                LogHelper.Info($"TagName:{tag.TagName},TagValue:{tag.TagValue.ToString()} 不存在可用的函数或信号未能处理");
            }
            return true;            
        }
    }
}
