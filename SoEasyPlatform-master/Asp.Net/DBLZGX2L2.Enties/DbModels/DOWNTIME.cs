using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("DOWNTIME")]
    public partial class DOWNTIME
    {
        public DOWNTIME()
        {


        }
        /// <summary>
        /// Desc:停机时间开始(咬钢结束)
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ACC_START_TIME { get; set; }

        /// <summary>
        /// Desc:停机时间结束(咬钢开始)
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ACC_END_TIME { get; set; }

        [SugarColumn(IsPrimaryKey = true)]
        /// <summary>
        /// Desc:ID
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int ID { get; set; }

    }
}
