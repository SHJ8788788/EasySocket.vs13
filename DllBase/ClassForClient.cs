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

namespace DllBase
{
    public class ClassForClient : EasyApiService
    {        
        /// <summary>
        /// 获取服务组件版本号
        /// </summary>       
        /// <returns></returns>
        [Api]
        [EasyLogFilter("获取版本号")]
        public string GetVersion()
        {            
            int i = 0;
            LogHelper.Debug(@"测试进入version;askdljf;sldjfosidfjad;flsakjfdsdoffjds;lajds;lfjsdf");
            try
            {
                test1();
                int j = 1;
                int s = j / i;
                return typeof(EasyApiService).Assembly.GetName().Version.ToString();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message.ToString());
                throw;
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
            Console.WriteLine(message);
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
