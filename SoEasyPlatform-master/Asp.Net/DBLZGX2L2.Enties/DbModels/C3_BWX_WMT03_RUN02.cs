using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("C3_BWX_WMT03_RUN02")]
    public partial class C3_BWX_WMT03_RUN02
    {
           public C3_BWX_WMT03_RUN02(){


           }
           /// <summary>
           /// Desc:流水号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MSG_ID {get;set;}

           /// <summary>
           /// Desc:读写标识（0：未读，1：已读）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MSG_STATUS {get;set;}

           /// <summary>
           /// Desc:运行状态 0：停机  1：开机
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CONTENT {get;set;}

           /// <summary>
           /// Desc:写入时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? MSG_WRITETIME {get;set;}

           /// <summary>
           /// Desc:读取时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? MSG_READTIME {get;set;}

           /// <summary>
           /// Desc:备用字段
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK_1 {get;set;}

           /// <summary>
           /// Desc:备用字段
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK_2 {get;set;}

           /// <summary>
           /// Desc:备用字段
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK_3 {get;set;}

           /// <summary>
           /// Desc:备用字段
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK_4 {get;set;}

           /// <summary>
           /// Desc:备用字段
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK_5 {get;set;}

           /// <summary>
           /// Desc:备用字段
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK_6 {get;set;}

    }
}
