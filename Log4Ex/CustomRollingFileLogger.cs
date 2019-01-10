using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace Log4Ex
{
    public abstract class CustomRollingFileLogger
    {
        private static readonly ConcurrentDictionary<string, ILog> loggerContainer = new ConcurrentDictionary<string, ILog>();  
        //自定义appender,为每个方法生成日志
        private static readonly Dictionary<string, MethodAppender> methodContainer = new Dictionary<string, MethodAppender>();
        //通用appender,新建logger时加载全部
        //private static readonly Dictionary<string, IAppender> appenderContainer = new Dictionary<string, IAppender>();  
        
        private static object lockObj = new object();  
  
        //默认配置  
        private const int MAX_SIZE_ROLL_BACKUPS = 20;
        //private const string LAYOUT_PATTERN = "%d [%-5t] %-5p %c  - %m%n";  
        private const string LAYOUT_PATTERN = "%d [%-5t] %-5p - %m%n";  
        private const string DATE_PATTERN = "yyyyMMdd\".txt\"";  
        private const string MAXIMUM_FILE_SIZE = "256MB";  
        private const string LEVEL = "debug";  
  
        //读取配置文件并缓存  
        static CustomRollingFileLogger()  
        {  
            IAppender[] appenders = LogManager.GetRepository().GetAppenders();              
            for (int i = 0; i < appenders.Length; i++)  
            {  
                if (appenders[i] is MethodAppender)  
                {  
                    MethodAppender appender = (MethodAppender)appenders[i];  
                    if (appender.MaxSizeRollBackups == 0)  
                    {  
                        appender.MaxSizeRollBackups = MAX_SIZE_ROLL_BACKUPS;  
                    }  
                    if (appender.Layout != null && appender.Layout is log4net.Layout.PatternLayout)  
                    {  
                        appender.LayoutPattern = ((log4net.Layout.PatternLayout)appender.Layout).ConversionPattern;  
                    }  
                    if (string.IsNullOrEmpty(appender.LayoutPattern))  
                    {  
                        appender.LayoutPattern = LAYOUT_PATTERN;  
                    }  
                    if (string.IsNullOrEmpty(appender.DatePattern))  
                    {  
                        appender.DatePattern = DATE_PATTERN;  
                    }  
                    if (string.IsNullOrEmpty(appender.MaximumFileSize))  
                    {  
                        appender.MaximumFileSize = MAXIMUM_FILE_SIZE;  
                    }  
                    if (string.IsNullOrEmpty(appender.Level))  
                    {  
                        appender.Level = LEVEL;  
                    }  
                    lock(lockObj)  
                    {
                        methodContainer[appenders[i].Name] = appender;  
                    }  
                }               
            }  
        }  
  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggerName">日志文件名</param>
        /// <param name="category"></param>
        /// <param name="additivity">是否继承root</param>
        /// <returns></returns>
        public static ILog GetCustomLoggerByFileName(string loggerName, string category = null, bool additivity = true)  
        {  
            return loggerContainer.GetOrAdd(loggerName, delegate(string name)  
            {  
                RollingFileAppender newAppender = null;  
                MethodAppender appender = null;
                if (methodContainer.ContainsKey(loggerName))  
                {
                    appender = methodContainer[loggerName];  
                    newAppender = GetNewFileApender(loggerName, string.IsNullOrEmpty(appender.File) ? GetFile(category, loggerName) : appender.File, appender.MaxSizeRollBackups,  
                        appender.AppendToFile, true, appender.MaximumFileSize, RollingFileAppender.RollingMode.Composite, appender.DatePattern, appender.LayoutPattern);  
                }  
                else  
                {  
                    newAppender = GetNewFileApender(loggerName, GetFile(category, loggerName), MAX_SIZE_ROLL_BACKUPS, true, true, MAXIMUM_FILE_SIZE, RollingFileAppender.RollingMode.Composite,   
                        DATE_PATTERN, LAYOUT_PATTERN);  
                }  
                log4net.Repository.Hierarchy.Hierarchy repository = (log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository();  
                Logger logger = repository.LoggerFactory.CreateLogger(repository, loggerName);  
                logger.Hierarchy = repository;  
                logger.Parent = repository.Root;  
                logger.Level = GetLoggerLevel(appender == null ? LEVEL : appender.Level);  
                logger.Additivity = additivity;  
                logger.AddAppender(newAppender); 
                
                logger.Repository.Configured = true;  
                return new LogImpl(logger);  
            });  
        }
        /// <summary>
        /// 以方法名生成日志文件
        /// </summary>
        /// <param name="category"></param>
        /// <param name="additivity">是否继承root</param>
        /// <returns></returns>
        public static ILog GetCustomLogger(string category = null, bool additivity = true)
        {
            string loggerName = GetFileName();
            return loggerContainer.GetOrAdd(loggerName, delegate(string name)
            {
                RollingFileAppender newAppender = null;
                MethodAppender appender = null;
                if (methodContainer.ContainsKey(loggerName))
                {
                    appender = methodContainer[loggerName];
                    newAppender = GetNewFileApender(loggerName, string.IsNullOrEmpty(appender.File) ? GetFile(category, loggerName) : appender.File, appender.MaxSizeRollBackups,
                        appender.AppendToFile, true, appender.MaximumFileSize, RollingFileAppender.RollingMode.Composite, appender.DatePattern, appender.LayoutPattern);
                }
                else
                {
                    newAppender = GetNewFileApender(loggerName, GetFile(category, loggerName), MAX_SIZE_ROLL_BACKUPS, true, true, MAXIMUM_FILE_SIZE, RollingFileAppender.RollingMode.Composite,
                        DATE_PATTERN, LAYOUT_PATTERN);
                }
                log4net.Repository.Hierarchy.Hierarchy repository = (log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository();
                Logger logger = repository.LoggerFactory.CreateLogger(repository, loggerName);
                logger.Hierarchy = repository;
                logger.Parent = repository.Root;
                logger.Level = GetLoggerLevel(appender == null ? LEVEL : appender.Level);
                logger.Additivity = additivity;
                logger.AddAppender(newAppender);
                logger.Repository.Configured = true;
                return new LogImpl(logger);
            });
        }  
  
        //如果没有指定文件路径则在运行路径下建立 Log\{loggerName}.txt  
        private static string GetFile(string category, string loggerName)  
        {  
            if (string.IsNullOrEmpty(category))  
            {  
                return string.Format(@"Log\{0}.txt", loggerName);  
            }  
            else  
            {  
                return string.Format(@"Log\{0}\{1}.txt", category, loggerName);  
            }  
        }  
  
        private static Level GetLoggerLevel(string level)  
        {  
            if (!string.IsNullOrEmpty(level))  
            {  
                switch (level.ToLower().Trim())  
                {  
                    case "debug":  
                        return Level.Debug;  
  
                    case "info":  
                        return Level.Info;  
  
                    case "warn":  
                        return Level.Warn;  
  
                    case "error":  
                        return Level.Error;  
  
                    case "fatal":  
                        return Level.Fatal;  
                }  
            }  
            return Level.Debug;  
        }  
  
        private static RollingFileAppender GetNewFileApender(string appenderName, string file, int maxSizeRollBackups, bool appendToFile = true, bool staticLogFileName = false, string maximumFileSize = "5MB", RollingFileAppender.RollingMode rollingMode = RollingFileAppender.RollingMode.Composite, string datePattern = "yyyyMMdd\".txt\"", string layoutPattern = "%d [%t] %-5p %c  - %m%n")  
        {  
            RollingFileAppender appender = new RollingFileAppender  
            {  
                LockingModel = new FileAppender.MinimalLock(),  
                Name = appenderName,  
                File = file,  
                AppendToFile = appendToFile,  
                MaxSizeRollBackups = maxSizeRollBackups,  
                MaximumFileSize = maximumFileSize,  
                StaticLogFileName = staticLogFileName,  
                RollingStyle = rollingMode,  
                DatePattern = datePattern  
            };  
            PatternLayout layout = new PatternLayout(layoutPattern);  
            appender.Layout = layout;  
            layout.ActivateOptions();  
            appender.ActivateOptions();  
            return appender;  
        } 
        //将日记对象缓存起来
        //private static Dictionary<string, ILog> LogDic = new Dictionary<string, ILog>();
        //static object _islock = new object();

        //protected static ILog GetLog()
        //{
        //    string fileName = GetFileName();
        //    return GetLog(fileName);
        //}
        //protected static ILog GetLog(string name)
        //{
        //    try
        //    {
        //        if (LogDic == null)
        //        {
        //            LogDic = new Dictionary<string, ILog>();
        //        }
        //        lock (_islock)
        //        {
        //            if (!LogDic.ContainsKey(name))
        //            {
        //                //ILog log = LogManager.GetLogger(name);
        //                ILog log = LogManager.GetLogger("AppLogger");
        //                string filePath = "log/"+name + ".log";
        //                //string filePath = @"d:/" + name + ".log";
        //                log.SetLog4netLogFileName(filePath);//修改日志文件名
        //                LogDic.Add(name, log);
        //            }
        //        }
        //        return LogDic[name];
        //    }
        //    catch
        //    {
        //        return LogManager.GetLogger("Default");
        //    }
        //}

        /// <summary>
        /// 记录日志时，追踪函数堆栈,查找函数名
        /// </summary>
        /// <returns></returns>
        protected static string GetMethodName()
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(2);
            MethodBase methodBase = stackFrame.GetMethod();
            // Displays “WhatsmyName”,(下一行如果不写的话,会引发异常)
            //Console.WriteLine(" Parent Method Name {0} n", methodBase.Name);
            return methodBase.Name;
        }
        /// <summary>
        /// 记录日志时，通过栈查询lambda初始调用的方法，并以函数名做为日志文件名
        /// </summary>
        /// <returns></returns>
        protected static string GetFileName()
        {
            StackTrace st = new StackTrace(1, true);//跳过给定的帧数
            string methodName = "";
            for (int i = 0; i < st.FrameCount; i++)
            {
                StackFrame sf = st.GetFrame(i);
                if (sf.GetMethod().Name == "lambda_method")//最终调用方式lambda排除
                {
                    break;
                }
                methodName = sf.GetMethod().Name;
                //Console.WriteLine("Method: {0}", sf.GetMethod().Name);
            }
            return methodName;
        }
    }
}
