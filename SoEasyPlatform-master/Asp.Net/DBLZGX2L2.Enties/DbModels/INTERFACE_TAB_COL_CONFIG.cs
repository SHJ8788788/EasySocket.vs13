using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("INTERFACE_TAB_COL_CONFIG")]
    public partial class INTERFACE_TAB_COL_CONFIG
    {
           public INTERFACE_TAB_COL_CONFIG(){


           }
           /// <summary>
           /// Desc:表名
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string TAB_NAME {get;set;}

           /// <summary>
           /// Desc:字段名
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string COL_NAME {get;set;}

           /// <summary>
           /// Desc:字段顺序
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? COL_INDEX {get;set;}

           /// <summary>
           /// Desc:收发标识（‘S’发送，‘R’接收）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string INTE_FLAG {get;set;}

    }
}
