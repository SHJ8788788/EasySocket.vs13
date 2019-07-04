using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("X2H502")]
    public partial class X2H502
    {
           public X2H502(){


           }
           /// <summary>
           /// Desc:信息ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true, OracleSequenceName = "X2H502_SEQ")]
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
           /// Desc:加热炉出炉日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RF_DEV_DT {get;set;}

           /// <summary>
           /// Desc:加热炉出炉作业班
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RF_DEV_OP_SFT {get;set;}

           /// <summary>
           /// Desc:加热炉出炉操作员
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EMPLOYEE_N1 {get;set;}

           /// <summary>
           /// Desc:加热炉在炉时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? RF_IN_FCE_TIME {get;set;}

           /// <summary>
           /// Desc:加热炉预热段在炉时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? RF_PRHT_IN_FCE_TIME {get;set;}

           /// <summary>
           /// Desc:加热炉加热段在炉时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? RF_HT_Z_IN_FCE_TIME {get;set;}

           /// <summary>
           /// Desc:加热炉均热段在炉时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? RF_NOR_Z_IN_FCE_TIME {get;set;}

           /// <summary>
           /// Desc:加热炉出炉坯温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? RF_DEV_MAT_TM {get;set;}

           /// <summary>
           /// Desc:加热炉加热段坯料温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? RF_HT_Z_MAT_TM {get;set;}

           /// <summary>
           /// Desc:加热炉均热段坯料温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? RF_NOR_Z_MAT_TM {get;set;}

           /// <summary>
           /// Desc:加热炉预热段温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? RF_PRHT_TM {get;set;}

           /// <summary>
           /// Desc:加热炉加热段温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? RF_HT_Z_TM {get;set;}

           /// <summary>
           /// Desc:加热炉均热段温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? RF_NOR_Z_TM {get;set;}

           /// <summary>
           /// Desc:加热炉预热段空燃比
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? RF_PRHT_VEFFI {get;set;}

           /// <summary>
           /// Desc:加热炉加热段空燃比
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? RF_HT_Z_VEFFI {get;set;}

           /// <summary>
           /// Desc:加热炉均热段空燃比
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? RF_NOR_Z_VEFFI {get;set;}

           /// <summary>
           /// Desc:加热炉预热段02分析值
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? RF_PRHT_O2_ASIS_V {get;set;}

           /// <summary>
           /// Desc:加热炉加热段02分析值
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? RF_HT_Z_O2_ASIS_V {get;set;}

           /// <summary>
           /// Desc:加热炉均热段02分析值
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? RF_NOR_Z_O2_ASIS_V {get;set;}

           /// <summary>
           /// Desc:高线除鳞机运行与否1
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WR_DESCALER_OP_F1 {get;set;}

           /// <summary>
           /// Desc:高线除鳞机压力
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_DESCALER_OP_PRS1 {get;set;}

           /// <summary>
           /// Desc:出炉分类（出炉:1,取消:2）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RF_EXIT_STATUS {get;set;}

           /// <summary>
           /// Desc:(钢坯)入炉温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? IN_FURNACE_TEMP {get;set;}

           /// <summary>
           /// Desc:炉膛炉压
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? FURN_PRESS {get;set;}

           /// <summary>
           /// Desc:煤气总管压力
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? GAS_PRESS {get;set;}

           /// <summary>
           /// Desc:煤气总管流量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? GAS_FLUX {get;set;}

           /// <summary>
           /// Desc:煤气热值
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? GAS_HEAT_VAL {get;set;}

           /// <summary>
           /// Desc:换热器前风压
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? HUANRE_PRESS_F {get;set;}

           /// <summary>
           /// Desc:换热器后风压
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? HUANRE_PRESS_R {get;set;}

           /// <summary>
           /// Desc:热风温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? HOT_WIND_TEMP {get;set;}

           /// <summary>
           /// Desc:残氧含量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? O2_VALUE {get;set;}

           /// <summary>
           /// Desc:预热段温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? PRE_HEAT_TEMP {get;set;}

           /// <summary>
           /// Desc:上加温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? HEAT_TEMP_1 {get;set;}

           /// <summary>
           /// Desc:下加温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? HEAT_TEMP_2 {get;set;}

           /// <summary>
           /// Desc:上均左温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? HEAT_TEMP_3 {get;set;}

           /// <summary>
           /// Desc:下均左温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? HEAT_TEMP_4 {get;set;}

           /// <summary>
           /// Desc:上均中温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? HEAT_TEMP_5 {get;set;}

           /// <summary>
           /// Desc:下均中温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? HEAT_TEMP_6 {get;set;}

           /// <summary>
           /// Desc:上均右温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? HEAT_TEMP_7 {get;set;}

           /// <summary>
           /// Desc:下均右温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? HEAT_TEMP_8 {get;set;}

    }
}
