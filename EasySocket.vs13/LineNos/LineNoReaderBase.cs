using EasySocket.vs13.Telegram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.LineNos
{
    public abstract class LineNoReaderBase
    {
        /// <summary>
        /// 所有电文解析器集合
        /// </summary>
        protected List<LineNoInfo> lineNoInfoList = new List<LineNoInfo>();
        protected List<TelegramInfo> telegramInfo = new List<TelegramInfo>();

        /// <summary>
        /// 初始化,加载回线配置信息
        /// </summary>
        /// <param name="path">路径</param>
        protected LineNoReaderBase(string path)
        {
            InitReader(path);
        }

        /// <summary>
        /// 重新加载回线配置信息
        /// </summary>
        /// <param name="path">路径</param>
        protected bool LineNoReaderReload(string path)
        {
           return InitReader(path);
        }

        /// <summary>
        /// 从回线读取器中取出对应ip\port的回线信息
        /// </summary>
        /// <param name="ip">对方ip</param>
        /// <param name="port">port</param>
        /// <returns></returns>
        public LineNoInfo GetLineNoInfo(string ip, ushort port)
        {
            //IEnumerable<LineNoInfo> list = lineNoInfoList.Where(p => p.IpAddress == ip && p.Port == port);
            //var lineNoInfo =
            //    list.Count() == 1 ? list.First() : default(LineNoInfo);

            //return lineNoInfo;

            return new LineNoInfo { IpAddress = ip, Port = port, LineNo = "10", HeadType = "10",Telegram = new TelegramInfo { HeaderLength =16} };
        }

        /// <summary>
        /// 读取并加载回线配置信息
        /// </summary>
        /// <param name="path">路径</param>
        public abstract bool InitReader(string path);

        /// <summary>
        /// 清空所有回线配置
        /// </summary>
        public abstract void Clear();
    }
}
