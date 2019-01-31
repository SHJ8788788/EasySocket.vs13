using DllOpc;
using EasySocket.vs13.Core;
using EasySocket.vs13.Telegram.Easy;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllOpc
{
    /// <summary>
    /// 接收并分发OPC发出的信号
    /// 关键函数TagEventChange
    /// </summary>
    public class TagEvent : EasyApiService, IOpc
    {
        /// <summary>
        /// Opc访问，需要继承IOpc
        /// 为保证Session安全，必须通过传入OpcSession访问Opc
        /// </summary>
        EasySession IOpc.OpcSession
        {
            get
            {
                //get { return this.CurrentContext.EasySessionByFilter("opc"); }
                //return this.CurrentContext.Session;
                return this.CurrentContext.EasySessionByFilter("category", "opc");
            }
        }

        [Api]
        [EasyLogFilter("事件发生变化")]
        public bool TagEventChange(TagSimple tag)
        {
            Console.WriteLine("事件:" + tag.TagName + "值:" + tag.TagValue.ToString());
            if (tag.TagName== "PL_RULU"&& tag.ValueCast<bool>()==true)
            {
               //new ClassFurn().FurnIn();
            }
            else if (tag.TagName == "JRL_CHUGANG")
            {

            }
            else if (tag.TagName == "H1YAOGANG")
            {

            }
            else if (tag.TagName == "H7YAOGANG")
            {

            }
            else if (tag.TagName == "H13YAOGANG")
            {

            }
            return true;            
        }

        /// <summary>
        /// 取值操作
        /// </summary>       
        /// <param name="list">tag值</param>
        /// <returns></returns>    
        [Api]
        [EasyLogFilter("取值操作")]
        public List<TagSimple> GetTags(List<string> list)
        {
            return this.OpLinkGetTags(list);
        }
    }
}
