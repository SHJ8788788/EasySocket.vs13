using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("INTERFACE_TEL_CONFIG_INFO")]
    public partial class INTERFACE_TEL_CONFIG_INFO
    {
           public INTERFACE_TEL_CONFIG_INFO(){


           }
           /// <summary>
           /// Desc:表名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TAB_NAME {get;set;}

           /// <summary>
           /// Desc:回线号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? LINE_NO {get;set;}

           /// <summary>
           /// Desc:电文号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TEL_NO {get;set;}

           /// <summary>
           /// Desc:主机标识
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string HOST_NAME {get;set;}

           /// <summary>
           /// Desc:收发标识（‘S’发送，‘R’接收）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string INTE_FLAG {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? LOOPCOL_START {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? LOOPCOL_LENGTH {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? LOOP_NUM {get;set;}

    }
}
