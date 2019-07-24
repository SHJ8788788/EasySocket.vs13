using MM00;
using EasySocket.vs13.Core;
using EasySocket.vs13.Serializers;
using EasySocket.vs13.Telegram.Easy;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM00
{
    /// <summary>
    /// 代理方法类，需要使用的远程调用方法在此处描述
    /// </summary>
    public partial class ClientProxy
    {
        /// <summary>
        /// 获取唯一实例
        /// </summary>
        public static EasyTcpClient Instance
        {
            get
            {
                return EasyTcpClient.Instance;
            }
        }

        public static Task<String> GetMessage(int code)
        {
            return Instance.InvokeApi<String>("GetMessage", "史哥睡觉--第" + code + "次");
        }

        /// <summary>
        /// 登录服务器
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <param name="ifAdmin">是否为管理员</param>
        /// <returns></returns>
        public static Task<LoginResult> Login(UserInfo user, Boolean ifAdmin)
        {
            return Instance.InvokeApi<LoginResult>("Login", user, ifAdmin).TimeoutAfter(TimeSpan.FromSeconds(5));
            //return this.InvokeApi<LoginResult>("Login", user).TimeoutAfter(TimeSpan.FromSeconds(1));
        }

        /// <summary>
        /// 登出服务器
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <param name="ifAdmin">是否为管理员</param>
        /// <returns></returns>
        public static Task<LoginResult> Logoff(UserInfo user, Boolean ifAdmin)
        {
            return Instance.InvokeApi<LoginResult>("Logoff", user, ifAdmin).TimeoutAfter(TimeSpan.FromSeconds(5));
        }

        /// <summary>
        /// 获取服务组件版本号
        /// </summary>       
        /// <returns></returns>      
        public static Task<string> GetVersion()
        {
            return Instance.InvokeApi<string>("GetVersion");
        }

        public static Task<String> GetMessage10s(int code)
        {
            return Instance.InvokeApi<String>("GetMessage10s", "史哥睡觉--第" + code + "次");
        }


        public static void GetVoidMessage(int code)
        {
            Instance.InvokeApi("GetVoidMessage", "史哥睡觉--第" + code + "次");
        }

        /// <summary>
        /// tag取值
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Task<List<TagSimple>> GetTags(List<string> list)
        {
            return Instance.InvokeApi<List<TagSimple>>("GetTags", list);
        }



        /// <summary>
        /// 信号点取值
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public static Task<string> GetTriggerTag(string tagName)
        {
            return Instance.InvokeApi<string>("GetTriggerValue", tagName);
        }



    }
}
