using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySocket.vs13.Core;
using EasySocket.vs13.Telegram.Easy;
using Models;
using System.Windows.Forms;

namespace EasyClient
{
    /// <summary>
    /// 客户端
    /// 长连接单例模式
    /// </summary>
    public class Client : EasyTcpClient
    {
        /// <summary>
        /// 唯一实例
        /// </summary>
        private static readonly Lazy<Client> instance = new Lazy<Client>(() => new Client());

        /// <summary>
        /// 获取唯一实例
        /// </summary>
        public static Client Instance
        {
            get { return instance.Value; }
        }


        /// <summary>
        /// 登录服务器
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <param name="ifAdmin">是否为管理员</param>
        /// <returns></returns>
        public Task<LoginResult> Login(UserInfo user, Boolean ifAdmin)
        {
            return this.InvokeApi<LoginResult>("Login", user, ifAdmin).TimeoutAfter(TimeSpan.FromSeconds(1));
            //return this.InvokeApi<LoginResult>("Login", user).TimeoutAfter(TimeSpan.FromSeconds(1));
        }

        /// <summary>
        /// 登出服务器
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <param name="ifAdmin">是否为管理员</param>
        /// <returns></returns>
        public Task<LoginResult> Logoff(UserInfo user, Boolean ifAdmin)
        {
            return this.InvokeApi<LoginResult>("Logoff", user, ifAdmin).TimeoutAfter(TimeSpan.FromSeconds(1));
        }

        /// <summary>
        /// 获取服务组件版本号
        /// </summary>       
        /// <returns></returns>      
        public Task<string> GetVersion()
        {
            return this.InvokeApi<string>("GetVersion");
        }

        //public Task<String> GetMessage(int code)
        //{
        //    return this.InvokeApi<String>("GetMessage", "史哥睡觉--第" + code + "次");
        //    //return this.InvokeApi<String>("GetMessage", 11111111);
        //}

        public Task<String> GetMessage10s(int code)
        {
            return this.InvokeApi<String>("GetMessage10s", "史哥睡觉--第" + code + "次");
        }


        public void GetVoidMessage(int code)
        {
            this.InvokeApi("GetVoidMessage", "史哥睡觉--第" + code + "次");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action">,状态 0：下线 1：上线 </param>
        /// <param name="name">昵称</param>
        /// <returns></returns>
        [Api]
        [EasyLogFilter("其它成员上线或离线 ")]
        public void LoginNotify(int action, string name)
        {
            string msg = name + (action == 0 ? "下线了！！" : "上线了！！");
            MsgHandle(msg);
        }
    }
}
