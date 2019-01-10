using Dll3;
using EasySocket.vs13.Core;
using Log4Ex;
using EasySocket.vs13.Telegram.Easy;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllOpc;

namespace Dll3
{
    public class Class1 : EasyApiService, IOpc
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
                return this.CurrentContext.EasySessionByFilter("Category","opc");
            }
        }

        /// <summary>
        /// 获取其它已登录的会话
        /// </summary>
        public IEnumerable<EasySession> OtherSessions
        {
            get
            {
                return this
                    .CurrentContext
                    .EasySessions
                    .Where(item => item != this.CurrentContext.Session);
            }
        }        /// <summary>
        /// 登录操作
        /// </summary>       
        /// <param name="user">用户数据</param>
        /// <param name="ifAdmin"></param>
        /// <returns></returns>    
        [Api]
        [EasyLogFilter("登录操作")]
        public LoginResult Login(UserInfo user, bool ifAdmin)
        {
            //var validResult = Model.ValidFor(user);
            //if (validResult.State == false)
            //{
            //    return new LoginResult { Message = validResult.ErrorMessage };
            //}

            // 通知其它fast会话有新成员登录
            foreach (var session in this.OtherSessions)
            {
                session.InvokeApi("LoginNotify", 1, user.Account);
            }        
            CurrentContext.Session.Tag.Set("Logined", true);
            CurrentContext.Session.Tag.Set("account", user.Account);
            var users = SugarDao.Instance.Queryable<user>().ToList();
            var userName = users.FirstOrDefault().username;
            Console.WriteLine(userName.ToString());
            var msg = string.Format(" > [user:{0} Login Success] ->Time({1})", user.Account + " " + userName, DateTime.Now);           
            return new LoginResult { State = true, Message = msg };
        }

        /// <summary>
        /// 登出操作
        /// </summary>       
        /// <param name="user">用户数据</param>
        /// <param name="ifAdmin"></param>
        /// <returns></returns>    
        [Api]
        [EasyLogFilter("登出操作")]
        public LoginResult Logoff(UserInfo user, bool ifAdmin)
        {
            //var validResult = Model.ValidFor(user);
            //if (validResult.State == false)
            //{
            //    return new LoginResult { Message = validResult.ErrorMessage };
            //}
            // 通知其它fast会话有新成员登录
            foreach (var session in this.OtherSessions)
            {
                session.InvokeApi("LoginNotify", 0, user.Account);
            }

            CurrentContext.Session.Tag.Set("Logined", false);
            CurrentContext.Session.Tag.Remove("account");
            var msg = string.Format(" > [user:{0} Login Off] ->Time({1})", user.Account, DateTime.Now);
            return new LoginResult { State = false, Message = msg };
        } 
  
        [Api]
        [EasyLogFilter("设置通讯类别")]
        public bool Verification(string msg)
        {
            this.CurrentContext.Session.Tag.Set("Category", "opc");
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
            return  this.OpLinkGetTags(list);
        }
        /// <summary>
        /// 登出操作
        /// </summary>       
        /// <param name="user">用户数据</param>
        /// <param name="ifAdmin"></param>
        /// <returns></returns>    
        [Api]
        [EasyLogFilter("登出操作")]
        public LoginResult LogTest(List<UserInfo> users, bool ifAdmin)
        {
            CurrentContext.Session.Tag.Set("Logined", false);
            CurrentContext.Session.Tag.Remove("account");
            var msg = string.Format(" > [user:{0} Login Off] ->Time({1})", users.FirstOrDefault().Account, DateTime.Now);
            var result = this.OpLinkTagValue("RandomXaxis");
            int resultMax = this.OpLinkTagValueMaxBetweenDate("RandomXaxis", DateTime.Now.AddSeconds(-10));
            List<TagSimple> list = this.OpLinkGetTags(new List<string> { "RandomXaxis", "RandomYaxis", "Random3" });
            Console.WriteLine(result);
            return new LoginResult { State = false, Message = msg + result + resultMax };
        }

        [Api]
        [EasyLogFilter("登出操作")]
        public LoginResult Log2StringTest(List<string> users, bool ifAdmin)
        {
            CurrentContext.Session.Tag.Set("Logined", false);
            CurrentContext.Session.Tag.Remove("account");
            var msg = string.Format(" > [user:{0} Login Off] ->Time({1})", users, DateTime.Now);
            return new LoginResult { State = false, Message = msg };
        } 
    }
}
