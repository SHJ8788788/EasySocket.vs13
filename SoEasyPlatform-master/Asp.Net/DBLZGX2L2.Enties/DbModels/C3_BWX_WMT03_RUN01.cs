using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("C3_BWX_WMT03_RUN01")]
    public partial class C3_BWX_WMT03_RUN01
    {
           public C3_BWX_WMT03_RUN01(){


           }
           /// <summary>
           /// Desc:流水号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MSG_ID {get;set;}

           /// <summary>
           /// Desc:读取状态（0，1）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MSG_STATUS {get;set;}

           /// <summary>
           /// Desc:原始轧线状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CONTENT {get;set;}

           /// <summary>
           /// Desc:数据写入时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? MSG_WRITETIME {get;set;}

           /// <summary>
           /// Desc:数据读取时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? MSG_READTIME {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK_1 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK_2 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK_3 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK_4 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK_5 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK_6 {get;set;}

    }
}
