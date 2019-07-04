using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("X2H505")]
    public partial class X2H505
    {
           public X2H505(){


           }
           /// <summary>
           /// Desc:信息ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true, OracleSequenceName = "X2H505_SEQ")]
           public int MSG_ID {get;set;}

           /// <summary>
           /// Desc:时间标签
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MSG_TIME_STAMP {get;set;}

           /// <summary>
           /// Desc:读写标识
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MSG_FLAG {get;set;}

           /// <summary>
           /// Desc:机架号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string STAND_NO {get;set;}

           /// <summary>
           /// Desc:故障起始时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ACC_START_TIME {get;set;}

           /// <summary>
           /// Desc:故障结束时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ACC_END_TIME {get;set;}

           /// <summary>
           /// Desc:班次号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SHIFT_NO {get;set;}

           /// <summary>
           /// Desc:组号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string GROUP_NO {get;set;}

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
