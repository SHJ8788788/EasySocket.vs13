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

namespace EasyClient
{
    /// <summary>
    /// API自定义类
    /// 1、必须继承EasyTcpClient，要不然会导致方法无法正常加载
    /// 2、需要使用的远程调用方法在此处描述
    /// </summary>
    public class ClientApi:EasyTcpClient
    {    
        [Api]
        public void LoginNotify(int action, string name)
        {
            string msg = name + (action == 0 ? "下线了！！" : "上线了！！");
            Instance.MsgHandle(msg);
        }
        [Api]
        public int GetTemp()
        {
            return 1000;
        }
    }
}
