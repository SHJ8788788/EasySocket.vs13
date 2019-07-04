using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("SERVERLOG")]
    public partial class SERVERLOG
    {
           public SERVERLOG(){


           }
           /// <summary>
           /// Desc:日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? START_DATE {get;set;}

           /// <summary>
           /// Desc:信息
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SERVER_INFO {get;set;}

    }
}
