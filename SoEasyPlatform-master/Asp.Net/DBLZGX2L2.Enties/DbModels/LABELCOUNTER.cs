using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("LABELCOUNTER")]
    public partial class LABELCOUNTER
    {
           public LABELCOUNTER(){


           }
           /// <summary>
           /// Desc:称重机号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WEIGHT_NO {get;set;}

           /// <summary>
           /// Desc:打标机A有标 B无标
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEM {get;set;}

           /// <summary>
           /// Desc:打印数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? NUM {get;set;}

           /// <summary>
           /// Desc:打印数最大值设置
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? NUMMAX {get;set;}

    }
}
