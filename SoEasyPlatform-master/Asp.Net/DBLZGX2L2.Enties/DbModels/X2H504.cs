using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("X2H504")]
    public partial class X2H504
    {
           public X2H504(){


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
           /// Desc:信息标志
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MSG_FLAG {get;set;}

           /// <summary>
           /// Desc:操作标识（正常轧制,轧废M）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ACTION {get;set;}

           /// <summary>
           /// Desc:检验批号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SMP_NO {get;set;}

           /// <summary>
           /// Desc:线卷号：相当于捆包号(01~99)	
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string COIL_NO {get;set;}

           /// <summary>
           /// Desc:生成日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CREATION_D {get;set;}

           /// <summary>
           /// Desc:线卷称重日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WR_WGTING_DT {get;set;}

           /// <summary>
           /// Desc:称重作业班组
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WGTING_OP_SFT {get;set;}

           /// <summary>
           /// Desc:产品毛重
           /// Default:
           /// Nullable:True
           /// </summary>           
           public double? PRD_GR_ACTUAL_WGT {get;set;}

           /// <summary>
           /// Desc:产品净重
           /// Default:
           /// Nullable:True
           /// </summary>           
           public double? PRD_NET_ACTUAL_WGT {get;set;}

           /// <summary>
           /// Desc:外观等级
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EXT_TOT_JDG_GD {get;set;}

           /// <summary>
           /// Desc:线卷打捆机打捆压力
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_UTE_MCN_UTE_PRS {get;set;}

           /// <summary>
           /// Desc:线卷打捆机线卷高度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_UTE_MCN_COIL_HEIT {get;set;}

           /// <summary>
           /// Desc:线卷外观检查员ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WR_EXT_INSP_EMP_ID {get;set;}

           /// <summary>
           /// Desc:高线包装材重量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public double? WR_PACK_HOOP_WGT {get;set;}

           /// <summary>
           /// Desc:轧制作业发生异常日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RL_OP_ABNR_OCR_DT {get;set;}

           /// <summary>
           /// Desc:高线发生轧废班组
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WR_COB_OCR_SFT {get;set;}

           /// <summary>
           /// Desc:称重操作员
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EMPLOYEE_N1 {get;set;}

           /// <summary>
           /// Desc:称重机号（B：1号，C：2号）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WEIGHT_NO {get;set;}

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
