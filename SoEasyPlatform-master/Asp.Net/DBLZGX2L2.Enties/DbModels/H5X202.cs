using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("H5X202")]
    public partial class H5X202
    {
           public H5X202(){


           }
           /// <summary>
           /// Desc:信息ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int MSG_ID {get;set;}

           /// <summary>
           /// Desc:信息时间标签
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MSG_TIME_STAMP {get;set;}

           /// <summary>
           /// Desc:读写标识（0：未读，1：已读）	
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MSG_FLAG {get;set;}

           /// <summary>
           /// Desc:方坯号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BILLET_NO {get;set;}

           /// <summary>
           /// Desc:缺号日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RF_OP_DT {get;set;}

           /// <summary>
           /// Desc:缺号作业班
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string HT_FCE_OP_SFT {get;set;}

           /// <summary>
           /// Desc:炉号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string HEAT_NO {get;set;}

           /// <summary>
           /// Desc:方坯指示重量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public double? BILLET_WGT {get;set;}

           /// <summary>
           /// Desc:缺号原因
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DISOP_CAU_CD {get;set;}

           /// <summary>
           /// Desc:缺号操作员
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RF_EMPLOYEE1 {get;set;}

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
           public decimal? BAK_5 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? BAK_6 {get;set;}

    }
}
