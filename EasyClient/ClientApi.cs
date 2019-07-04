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
        /// <summary>
        /// 上线通知
        /// </summary>
        /// <param name="name"></param>
        [Api]
        public void LoginNotify(string name)
        {
            string msg = name + "上线了！！";
            Instance.MsgHandle(msg);
        }
        /// <summary>
        /// 下线通知
        /// </summary>
        /// <param name="name"></param>
        [Api]
        public void LogoffNotify(string name)
        {
            string msg = name + "下线了！！";
            Instance.MsgHandle(msg);
        }
        [Api]
        public int GetTemp()
        {
            return 1000;
        }

        /// <summary>
        /// 加热炉炉内发生变化
        /// </summary>
        /// <param name="message"></param>
        [Api]
        public void FurnChanged(List<FurnInfo> furnInfos)
        {
            foreach (var furnInfo in furnInfos)
            {
                Instance.MsgHandle(furnInfo.BLT_NO);
            }
           
        }

        /// <summary>
        /// 加热炉炉内发生变化
        /// </summary>
        /// <param name="message"></param>
        [Api]
        public void MillChanged(string message)
        {
            Instance.MsgHandle(message);
        }
    }
}
