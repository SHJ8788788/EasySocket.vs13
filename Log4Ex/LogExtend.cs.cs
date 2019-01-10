using log4net;
using log4net.Appender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Ex
{
    /// <summary>
    /// 提供log4net的扩展方法
    /// </summary>
    public static class LogExtend
    {
        /// <summary>
        /// 设置文件名
        /// </summary>
        /// <param name="iLog"></param>
        /// <param name="fileName"></param>
        public static void SetLog4netLogFileName(this log4net.ILog iLog, string fileName)
        {
            log4net.Core.LogImpl logImpl = iLog as log4net.Core.LogImpl;            
            if (logImpl != null)
            {
                log4net.Appender.AppenderCollection ac = ((log4net.Repository.Hierarchy.Logger)logImpl.Logger).Appenders;
                for (int i = 0; i < ac.Count; i++)
                {     // 这里我只对RollingFileAppender类型做修改 
                    log4net.Appender.RollingFileAppender rfa = ac[i] as log4net.Appender.RollingFileAppender;
                    if (rfa != null)
                    {
                        rfa.File = fileName;
                        //if (!System.IO.File.Exists(fileName))
                        //{
                        //    System.IO.File.Create(fileName);
                        //}
                        //更新Writer属性 
                        rfa.Writer = new System.IO.StreamWriter(rfa.File, rfa.AppendToFile, rfa.Encoding);
                    }
                }             
            }
        }
    }
}
