using EasySocket.vs13.Telegram.Easy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.Plugs
{
    public class EasySocketPlug : PlugBase
    {
        /// <summary>
        /// 会话断开后事件
        /// </summary>
        protected override void OnDisconnected(object sender, IContext context)
        {
            this.ProcessOfflineNotify(context);
        }

        /// <summary>
        /// 处理离线通知
        /// </summary>
        /// <param name="context">上下文</param>
        private void ProcessOfflineNotify(IContext context)
        {
            if (context.Session.Extra.Protocol != Protocol.Easy)
            {
                return;
            }

            var account = context.Session.Extra.Tag.Get("account");
            if (account.IsNull == true)
            {
                return;
            }

            var easySessions = context
                .AllSessions
                .FilterWrappers<EasySession>();

            //var members = easySessions
            //    .Select(item => item.Tag.Get("name").AsString())
            //    .Where(item => item != null)
            //    .ToArray();

            // 推送成员下线通知
            foreach (var item in easySessions)
            {
                item.InvokeApi("LoginNotify", 0, account.Value.ToString());
            }
        }
    }
}
