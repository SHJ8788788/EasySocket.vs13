using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("CURSET")]
    public partial class CURSET
    {
           public CURSET(){


           }
           /// <summary>
           /// Desc:数据项
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ITEM {get;set;}

           /// <summary>
           /// Desc:数据值
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEMSET {get;set;}

           /// <summary>
           /// Desc:挂钩位置（A:上台，B：1号下台，C：2号下台）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEMONLOC {get;set;}

           /// <summary>
           /// Desc:下钩位置
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEMDOWNLOC {get;set;}

    }
}
