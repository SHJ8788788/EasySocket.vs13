using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Log4Ex
{
    //log4net二次封装，支持动态文件名，按日期和大小自动分割文件
    public class LogHelper : CustomRollingFileLogger
    {
        #region For Method
        public static void Info(object message)
        {
            var methodName = GetMethodName();
            var log = GetCustomLogger();
            if (log == null)
            {
                return;
            }
            message = "Method:[" + methodName + "]  Msg: " + message;
            log.Info(message);
        }
        public static void Debug(object message)
        {
            var methodName = GetMethodName();
            var log = GetCustomLogger();
            if (log == null)
            {
                return;
            }
            message = "Method:[" + methodName + "]  Msg: " + message;
            log.Debug(message);
        }
        public static void Error(object message)
        {
            var methodName = GetMethodName();
            var log = GetCustomLogger();
            if (log == null)
            {
                return;
            }
            message = "Method:[" + methodName + "]  Msg: " + message;
            log.Error(message);
        }
        public static void Fatal(object message)
        {
            var methodName = GetMethodName();
            var log = GetCustomLogger();
            if (log == null)
            {
                return;
            }
            message = "Method:[" + methodName + "]  Msg: " + message;
            log.Fatal(message);
        }  
        #region 平台Filter专用
        /// <summary>
        /// 调用函数前
        /// </summary>
        /// <param name="methodName">函数名</param>
        public static void MethodBegin(string methodName)
        {
            var log = GetCustomLoggerByFileName(methodName);
            if (log == null)
            {
                return;
            }
            string message = "Method:[" + methodName + "()]  Msg: " + "**********************************Begin**********************************";
            log.Info(message);
        }
        /// <summary>
        /// 调用函数后
        /// </summary>
        /// <param name="methodName">函数名</param>
        public static void MethodEnd(string methodName)
        {
            var log = GetCustomLoggerByFileName(methodName);
            if (log == null)
            {
                return;
            }
            string message = "Method:[" + methodName + "()]  Msg: " + "**********************************End**********************************";
            log.Info(message);
        }
        /// <summary>
        /// 调用函数发生异常后捕获
        /// </summary>
        /// <param name="methodName">函数名</param>
        /// <param name="errorDesc">异常描述</param>
        public static void MethodException(string methodName,string errorDesc)
        {
            var log = GetCustomLoggerByFileName(methodName);
            if (log == null)
            {
                return;
            }
            string messageDesc = "Method:[" + methodName + "()]  Msg: " + errorDesc;            
            string message = "Method:[" + methodName + "()]  Msg: " + "**********************************End with Exception**********************************";
            log.Error(messageDesc);
            log.Error(message);
        }
        #endregion
        #endregion

        #region For Middleware
        /// <summary>
        /// 平台异常日志，保存在Server文件夹中
        /// </summary>
        /// <param name="errorFromwhat">文件名</param>
        /// <param name="errorDesc">日志内容</param>
        public static void MiddlewareException(string errorFromwhat,string errorDesc)
        {
            var methodName = GetMethodName();
            var log = GetCustomLoggerByFileName(errorFromwhat,"Server");
            if (log == null)
            {
                return;
            }
            string messageDesc = "Method:[" + methodName + "()]  Msg: " + errorDesc;
            log.Error(messageDesc);
        }
        #endregion
    }
}
