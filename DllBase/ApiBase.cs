using EasySocket.vs13.Core;
using Log4Ex;
using EasySocket.vs13.Telegram.Easy;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllBase
{
    /// <summary>
    /// 基础API服务
    /// 提供用户登陆、注销等操作
    /// 会话分类Category:
    /// client 客户端用户会话
    /// opc    opc会话
    /// </summary>
    public class ApiBase : EasyApiService, IClient
    {
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
        }

        /// <summary>
        /// 获取来至客户端已登录的会话
        /// </summary>
        public IEnumerable<EasySession> ClientSessions
        {
            get
            {
                return this
                    .CurrentContext
                    .EasySessions
                    .Where(item =>
                    item != this.CurrentContext.Session&&
                    item.Tag.ContainsKey("category") &&
                    item.Tag.Get("category").Value.ToString() == "client");
            }
        }

        /// <summary>
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

            // 通知其它客户端会话有新成员上线
            this.LoginNotify(user.Account);        
            CurrentContext.Session.Tag.Set("logined", true);
            CurrentContext.Session.Tag.Set("account", user.Account);
            CurrentContext.Session.Tag.Set("category", "client");
            userInfo newUser;
            string msg;
            using (var db = SugarDao.Instance)
            {
                newUser = db.Queryable<userInfo>().Where(p => p.usercode == user.Account&&p.password==user.Password).First();
            }
            if (newUser != null)
            {
                //Console.WriteLine(newUser.name.ToString());
                msg = string.Format(" > [user:{0} Login Success] ->Time({1})", newUser.usercode + " " + newUser.name, DateTime.Now);
                return new LoginResult { State = true, Message = msg };
            }
            else
            {
                msg = string.Format(" > [user:{0} Login Failture] ->Time({1})", user.Account + " " + user.Name, DateTime.Now);
                return new LoginResult { State = false, Message = msg };
            }            
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
            // 通知其它客户端会话有成员下线
            this.LogoffNotify(user.Account);

            CurrentContext.Session.Tag.Set("logined", false);
            bool success = CurrentContext.Session.Tag.Remove("account");
            if (success)
            {
                var msg = string.Format(" > [user:{0} Login Off Success] ->Time({1})", user.Account, DateTime.Now);
                return new LoginResult { State = true, Message = msg };
            }
            else
            {
                var msg = string.Format(" > [user:{0} Login Off Failture] ->Time({1})", user.Account, DateTime.Now);
                return new LoginResult { State = false, Message = msg };
            }
           
        } 
  
        [Api]
        [EasyLogFilter("设置通讯类别")]
        public bool Verification(string msg)
        {
            this.CurrentContext.Session.Tag.Set("category", msg);
            return true;
        }

        /// <summary>
        /// 获取服务组件版本号
        /// </summary>       
        /// <returns></returns>
        [Api]
        [EasyLogFilter("获取版本号")]
        public string GetVersion()
        {
            try
            {
                return typeof(EasyApiService).Assembly.GetName().Version.ToString();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message.ToString());
                throw;
            }
        }

        /// <summary>
        /// 登出操作
        /// </summary>       
        /// <param name="user">用户数据</param>
        /// <param name="ifAdmin"></param>
        /// <returns></returns>    
        [Api]
        [EasyLogFilter("登出操作-测试用")]
        public LoginResult LogTest(List<UserInfo> users, bool ifAdmin)
        {
            CurrentContext.Session.Tag.Set("logined", false);
            CurrentContext.Session.Tag.Remove("account");
            var msg = string.Format(" > [user:{0} Login Off] ->Time({1})", users.FirstOrDefault().Account, DateTime.Now);
            //var result = this.OpLinkTagValue("RandomXaxis");
            //int resultMax = this.OpLinkTagValueMaxBetweenDate("RandomXaxis", DateTime.Now.AddSeconds(-10));
            //List<TagSimple> list = this.OpLinkGetTags(new List<string> { "RandomXaxis", "RandomYaxis", "Random3" });
            //Console.WriteLine(result);
            //return new LoginResult { State = false, Message = msg + result + resultMax };
            return new LoginResult { State = false, Message = msg };
        }

        [Api]
        [EasyLogFilter("登出操作-测试用")]
        public LoginResult Log2StringTest(List<string> users, bool ifAdmin)
        {
            CurrentContext.Session.Tag.Set("logined", false);
            CurrentContext.Session.Tag.Remove("account");
            var msg = string.Format(" > [user:{0} Login Off] ->Time({1})", users, DateTime.Now);
            return new LoginResult { State = false, Message = msg };
        } 
    }
}
