using log4net;
using log4net.Appender;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Ex
{
    public static class LogFileCleanupTask
    {   

        #region - Methods -
        /// <summary>
        /// Cleans up. Auto configures the cleanup based on the log4net configuration
        /// </summary>
        /// <param name="date">Anything prior will not be kept.</param>
        public static void CleanUp()
        {
            string directory = string.Empty;
            string filePrefix = string.Empty;


            IAppender[] appenders = LogManager.GetRepository().GetAppenders();
            MethodAppender appender= appenders.Where(a => a.GetType() == typeof(MethodAppender)).FirstOrDefault() as MethodAppender;

            if (appender == null)
            {
                throw new NotSupportedException("Log4Net has not been configured yet.");
            }
            else
            {
                int maxSizeRollBackups = appender.MaxSizeRollBackups;
                DateTime date = DateTime.Now.AddDays(-maxSizeRollBackups);
                directory = Path.GetDirectoryName(appender.File);
                filePrefix = Path.GetFileName(appender.File);
                CleanUp(directory, filePrefix, date);
            }
        }

        /// <summary>
        /// Cleans up.
        /// </summary>
        /// <param name="logDirectory">The log directory.</param>
        /// <param name="logPrefix">The log prefix. Example: logfile dont include the file extension.</param>
        /// <param name="date">Anything prior will not be kept.</param>
        public static void CleanUp(string logDirectory, string logPrefix, DateTime date)
        {
            if (string.IsNullOrEmpty(logDirectory))
                throw new ArgumentException("logDirectory is missing");

            if (string.IsNullOrEmpty(logPrefix))
                throw new ArgumentException("logPrefix is missing");

            var dirInfo = new DirectoryInfo(logDirectory);
            if (!dirInfo.Exists)
                return;

            //var fileInfos = dirInfo.GetFiles("{0}*.*".Sub(logPrefix));
            var fileInfos = dirInfo.GetFiles(logPrefix);
            if (fileInfos.Length == 0)
                return;

            foreach (var info in fileInfos)
            {
                int beginIndex = info.Name.LastIndexOf(".txt") -8;
                int endIndex = info.Name.LastIndexOf(".txt");
                if (endIndex>8)
                {
                    string dateStr = info.Name.Substring(beginIndex, 8);
                    if (IsDate(dateStr)) //日志名称是否包括日期格式
                    {
                        if (ToDate(dateStr) < date) //当日志日期为10(log4net -MaxSizeRollBackups参数)天前生成，则删除
                        {
                            info.Delete();
                        }

                    }                    
                }
                //if (info.CreationTime < date)
                //{
                //    info.Delete();
                //}
            }

        }

        public static bool IsDate(string strDate)
        {
            try
            {
                IFormatProvider culture = new System.Globalization.CultureInfo("zh-CN", true);
                string[] expectedFormats = { "yyyyMMdd", "yyyyMMd", "yyyyMdd", "yyyyMdd" };
                DateTime dtDate = DateTime.ParseExact(strDate, expectedFormats, culture, System.Globalization.DateTimeStyles.AllowInnerWhite);              
                return true;
            }
            catch
            {               
                return false;
            }
        }

        public static DateTime ToDate(string strDate)
        {
            try
            {
                IFormatProvider culture = new System.Globalization.CultureInfo("zh-CN", true);
                string[] expectedFormats = { "yyyyMMdd", "yyyyMMd", "yyyyMdd", "yyyyMdd" };
                return DateTime.ParseExact(strDate, expectedFormats, culture, System.Globalization.DateTimeStyles.AllowInnerWhite);
            }
            catch
            {
                return default(DateTime);
            }
        }
        #endregion
    }

    [DebuggerStepThrough, DebuggerNonUserCode]
    public static class StringExtensions
    {
        /// <summary>
        /// Formats a string using the <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        /// <returns>A string with the format placeholders replaced by the args.</returns>
        public static string Sub(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
    }  
}
