using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("X2H501")]
    public partial class X2H501
    {
           public X2H501(){


           }
           /// <summary>
           /// Desc:信息ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,OracleSequenceName = "X2H501_SEQ")]
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
           /// Desc:方坯号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BILLET_NO {get;set;}

           /// <summary>
           /// Desc:工厂工序代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string FAC_OP_CD {get;set;}

           /// <summary>
           /// Desc:生成程序ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CREATED_PROGRAM_ID {get;set;}

           /// <summary>
           /// Desc:生成日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CREATION_D {get;set;}

           /// <summary>
           /// Desc:加热炉装炉日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RF_CH_DT {get;set;}

           /// <summary>
           /// Desc:加热炉装炉作业班
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RF_CH_OP_SFT {get;set;}

           /// <summary>
           /// Desc:加热炉装炉操作员
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EMPLOYEE_N1 {get;set;}

           /// <summary>
           /// Desc:加热炉装炉方坯断面
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_HT_FCE_CH_BT_SEC {get;set;}

           /// <summary>
           /// Desc:加热炉装炉方坯长度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? RF_CH_MAT_LEN {get;set;}

           /// <summary>
           /// Desc:加热炉装炉方坯实际重量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public double? RF_CH_MAT_RL_WGT {get;set;}

           /// <summary>
           /// Desc:加热炉装炉方坯理论重量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public double? RF_CH_MAT_CAL_WGT {get;set;}

           /// <summary>
           /// Desc:加热炉坯料装炉温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? RF_CH_MAT_TM {get;set;}

           /// <summary>
           /// Desc:加热炉装炉所需时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? RF_MAT_CH_LEAD_TIME {get;set;}

           /// <summary>
           /// Desc:装炉分类(装炉/取消)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RF_CHARGE_STATUS {get;set;}

           /// <summary>
           /// Desc:实绩HCR分类
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RST_HCR_FLAG {get;set;}

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
