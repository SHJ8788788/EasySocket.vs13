using DllBase;
using EasySocket.vs13.Core;
using EasySocket.vs13.Telegram.Easy;
using Log4Ex;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DllClient
{
    /// <summary>
    /// 客户端API服务
    /// 会话分类Category:
    /// client 客户端用户会话
    /// opc    opc会话
    public class ApiForClient : EasyApiService, IClient
    {
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
                    item.Tag.Get("category").Value.ToString() == "client");
            }
        }

        public void test1()
        {
            LogHelper.Debug("测试调用test1");
        }


        //private static void WhoCalledMe()
        //{
        //    StackTrace stackTrace = new StackTrace();
        //    StackFrame stackFrame = stackTrace.GetFrame(1);
        //    MethodBase methodBase = stackFrame.GetMethod();
        //    // Displays “WhatsmyName”,(下一行如果不写的话,会引发异常)
        //    Console.WriteLine(" Parent Method Name {0} n", methodBase.Name);
        //    CallingSequence();
        //}

        ////演示追踪函数堆栈,查找函数名
        //private static void CallingSequence()
        //{
        //    StackTrace st = new StackTrace(1, true);//跳过给定的帧数
        //    string methodName = "";
        //    for (int i = 0; i < st.FrameCount; i++)
        //    {
        //        StackFrame sf = st.GetFrame(i);
        //        if (sf.GetMethod().Name == "lambda_method")//最终调用方式lambda排除
        //        {
        //            break;
        //        }
        //        methodName = sf.GetMethod().Name;
        //        Console.WriteLine("Method: {0}", sf.GetMethod().Name);
        //        //Console.WriteLine("Method: {0}", sf.GetMethod());
        //    }
        //}


        [Api]
        [EasyLogFilter("打印返回信息")]
        public string GetMessage(String message)
        {
            LogHelper.Debug("123123123123123213");
            return "通过服务端认证后返回：" + message;
        }

        [Api]
        [EasyLogFilter("打印返回信息10s")]
        public string GetMessage10s(String message)
        {
            Thread.Sleep(1000);
            LogHelper.Info("通过服务端认证后返回：" + message);
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
    }
}
