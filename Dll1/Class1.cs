using EasySocket.vs13.Core;
using EasySocket.vs13.Telegram.Easy;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dll1
{
    public class Class1 : EasyApiService
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
            var msg = string.Format(" > [user:{0} Login Success] ->Time({1})", user.Account, DateTime.Now);
            return new LoginResult { State = true, Message = msg };
        }

        /// <summary>
        /// 登录操作
        /// </summary>       
        /// <param name="user">用户数据</param>
        /// <param name="ifAdmin"></param>
        /// <returns></returns>    
        [Api]
        [EasyLogFilter("登录操作")]
        public LoginResult Login(UserInfo user)
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
            var msg = string.Format(" > [user:{0} Login Success] ->Time({1})", user.Account, DateTime.Now);
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


        /// <summary>
        /// 获取服务组件版本号
        /// </summary>       
        /// <returns></returns>
        [Api]
        [EasyLogFilter("获取版本号")]
        public string GetVersion()
        {
            return typeof(EasyApiService).Assembly.GetName().Version.ToString();
        }

        [Api]
        [EasyLogFilter("打印返回信息")]
        public string GetMessage(String message)
        {
            Console.WriteLine(message);
            return "通过服务端认证后返回：" + message;
        }

        [Api]
        [EasyLogFilter("打印返回信息10s")]
        public string GetMessage10s(String message)
        {
            Thread.Sleep(1000);
            return "通过服务端认证后返回：" + message;
        }

        [Api]
        [EasyLogFilter("打印返回信息5s")]
        public void GetWait5sMessage(String message)
        {
            Thread.Sleep(5);
            string test = "通过服务端认证后返回：" + message;
            //return "通过服务端认证后返回：" + message;
        }

        [Api]
        [EasyLogFilter("打印返回信息5s")]
        public void GetVoidMessage(String message)
        {
            Thread.Sleep(5);
            string test = "通过服务端认证后返回：" + message;
        }

        [Api]
        [EasyLogFilter("测试是否能传递table")]
        public string GetWaitDataTablesMessage(String table)
        {
            Thread.Sleep(5000);

            return "通过服务端认证后返回：" + table.ToString();
        }



        ///// <summary>
        ///// 登录操作
        ///// </summary>       
        ///// <param name="user">用户数据</param>
        ///// <param name="ifAdmin"></param>
        ///// <returns></returns>    
        //[Api]
        //[EasyLogFilter("登录操作")]
        //public LoginResult Login(UserInfo user, bool ifAdmin)
        //{
        //    var validResult = Model.ValidFor(user);
        //    if (validResult.State == false)
        //    {
        //        return new LoginResult { Message = validResult.ErrorMessage };
        //    }

        //    // 通知其它Easy会话有新成员登录
        //    foreach (var session in this.OtherSessions)
        //    {
        //        session.InvokeApi("LoginNotify", user.Account);
        //    }

        //    CurrentContext.Session.Tag.Set("Logined", true);
        //    return new LoginResult { State = true };
        //}

        /// <summary>
        /// 求合操作       
        /// </summary>     
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        //[Api("GetSum")]
        //[EasyLogFilter("求合操作")]
        //[EasyLogin]
        //public int GetSun(int x, int y, int z)
        //{
        //    Thread.Sleep(10000);
        //    return x + y + z;
        //}


        //public int GetData()
        //{
        //    using (var db = SugarDao.GetInstance())
        //    {
        //        var list = db.Queryable<T>().ToList();
        //    }
        //}
    }


}
