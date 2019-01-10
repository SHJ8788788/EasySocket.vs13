using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.LineNos
{
    /// <summary>
    /// 回线信息读取器，根据ip,port读取相关配置
    /// </summary>
    class LineNoXmlReader:LineNoReaderBase
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public LineNoXmlReader():this("")
        {

        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="path"></param>
        public LineNoXmlReader(string path)
            : base(path)
        {

        }

        /// <summary>
        /// 读取并加载回线配置信息
        /// </summary>
        /// <param name="path">路径</param>
        public override bool InitReader(string path)
        {
            try
            {
                LineNoInfo lineNoInfo = new LineNoInfo();
                lineNoInfo.IpAddress = "127.0.0.1";
                lineNoInfo.Port = 5555;
                lineNoInfo.LineNo = "";
                lineNoInfo.HeadType = "2";
                this.lineNoInfoList.Add(lineNoInfo);
                return true;
            }
            catch (Exception)
            {                
                 return false;
            }          
        } 

        /// <summary>
        /// 清空所有回线配置
        /// </summary>
        public override void Clear()
        {
            lineNoInfoList.Clear();
        }


    }
}
