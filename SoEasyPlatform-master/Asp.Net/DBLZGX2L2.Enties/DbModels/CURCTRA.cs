using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("CURCTRA")]
    public partial class CURCTRA
    {
           public CURCTRA(){


           }
           /// <summary>
           /// Desc:称重台
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEM {get;set;}

           /// <summary>
           /// Desc:称重台状态（0：未动作，1：动作触发中）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TYPE {get;set;}

           /// <summary>
           /// Desc:下降到位信号（0：未到位 1：已到位）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SIGNALIN {get;set;}

    }
}
