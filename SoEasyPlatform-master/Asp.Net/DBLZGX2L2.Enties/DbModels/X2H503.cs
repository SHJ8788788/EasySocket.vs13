using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("X2H503")]
    public partial class X2H503
    {
           public X2H503(){


           }
           /// <summary>
           /// Desc:信息ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true, OracleSequenceName = "X2H503_SEQ")]
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
           /// Desc:操作标识（正常轧制N,轧废U）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ACTION {get;set;}

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
           /// Desc:轧制作业班组
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WR_RL_OP_SFT {get;set;}

           /// <summary>
           /// Desc:轧机操作员
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EMPLOYEE_N1 {get;set;}

           /// <summary>
           /// Desc:轧制开始日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WR_RL_SAT_DT {get;set;}

           /// <summary>
           /// Desc:轧制结束日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WR_RL_DN_DT {get;set;}

           /// <summary>
           /// Desc:轧制所需时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_RL_RQR_TM {get;set;}

           /// <summary>
           /// Desc:轧制间隔时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_RL_INTERVAL_TM {get;set;}

           /// <summary>
           /// Desc:轧制作业发生异常日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RL_OP_ABNR_OCR_DT {get;set;}

           /// <summary>
           /// Desc:轧制作业发生异常原因
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RL_OP_ABNR_CAU_CD {get;set;}

           /// <summary>
           /// Desc:发生轧废班组
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WR_COB_OCR_SFT {get;set;}

           /// <summary>
           /// Desc:发生轧制作业异常类型分类
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WR_RL_OP_ABNR_OCR_TP_LOC_TP {get;set;}

           /// <summary>
           /// Desc:发生轧制作业异常设备位置分类
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WR_RL_OP_ABNR_OCR_EQP_LOC_TP {get;set;}

           /// <summary>
           /// Desc:开轧温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? TEMP_START_ROLL {get;set;}

           /// <summary>
           /// Desc:精轧入口温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? FINROLL_IN_TMEP {get;set;}

           /// <summary>
           /// Desc:精轧机速度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? ROLL_SPEED_TMB2 {get;set;}

           /// <summary>
           /// Desc:1#水箱水压
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WATER_PRESS_1 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WATER_PRESS_2 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WATER_PRESS_3 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WATER_PRESS_4 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WATER_PRESS_5 {get;set;}

           /// <summary>
           /// Desc:1#水箱流量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_WATER_YIELD1 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_WATER_YIELD2 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_WATER_YIELD3 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_WATER_YIELD4 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_WATER_YIELD5 {get;set;}

           /// <summary>
           /// Desc:吐丝温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? TUSI_TEMP {get;set;}

           /// <summary>
           /// Desc:1#风门
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG1 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG2 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG3 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG4 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG5 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG6 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG7 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG8 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG9 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG10 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG11 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG12 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG13 {get;set;}

           /// <summary>
           /// Desc:14#风门
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG14 {get;set;}

           /// <summary>
           /// Desc:保温罩18个开关量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAOWENZHAO_STATE {get;set;}

           /// <summary>
           /// Desc:首段辊速
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_AIR_C_Z_CONVEYOR_SPD1 {get;set;}

           /// <summary>
           /// Desc:第1段辊速
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_AIR_C_Z_CONVEYOR_SPD2 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_AIR_C_Z_CONVEYOR_SPD3 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_AIR_C_Z_CONVEYOR_SPD4 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_AIR_C_Z_CONVEYOR_SPD5 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_AIR_C_Z_CONVEYOR_SPD6 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_AIR_C_Z_CONVEYOR_SPD7 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_AIR_C_Z_CONVEYOR_SPD8 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_AIR_C_Z_CONVEYOR_SPD9 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_AIR_C_Z_CONVEYOR_SPD10 {get;set;}

           /// <summary>
           /// Desc:第10段辊速
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_AIR_C_Z_CONVEYOR_SPD11 {get;set;}

           /// <summary>
           /// Desc:尾段辊速
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_AIR_C_Z_CONVEYOR_SPD12 {get;set;}

           /// <summary>
           /// Desc:风冷线1#测温点温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COOLLINE_TEMP_1 {get;set;}

           /// <summary>
           /// Desc:风冷线2#测温点温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COOLLINE_TEMP_2 {get;set;}

           /// <summary>
           /// Desc:风冷线3#测温点温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COOLLINE_TEMP_3 {get;set;}

    }
}
