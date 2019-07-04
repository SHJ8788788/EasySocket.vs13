using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("ERRRECORD")]
    public partial class ERRRECORD
    {
           public ERRRECORD(){


           }
           /// <summary>
           /// Desc:错误编号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? ERRID {get;set;}

           /// <summary>
           /// Desc:错误内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ERROR {get;set;}

           /// <summary>
           /// Desc:错误来源
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ERROR_SOURCE {get;set;}

           /// <summary>
           /// Desc:错误产生日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? ERROR_DATE {get;set;}

    }
}
