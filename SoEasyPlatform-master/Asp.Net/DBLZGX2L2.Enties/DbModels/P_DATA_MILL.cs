using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("P_DATA_MILL")]
    public partial class P_DATA_MILL
    {
           public P_DATA_MILL(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string FLAG {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

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
           /// Desc:2#水箱水压
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WATER_PRESS_2 {get;set;}

           /// <summary>
           /// Desc:3#水箱水压
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WATER_PRESS_3 {get;set;}

           /// <summary>
           /// Desc:4#水箱水压
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WATER_PRESS_4 {get;set;}

           /// <summary>
           /// Desc:5#水箱水压
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
           /// Desc:2#水箱流量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_WATER_YIELD2 {get;set;}

           /// <summary>
           /// Desc:3#水箱流量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_WATER_YIELD3 {get;set;}

           /// <summary>
           /// Desc:4#水箱流量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_WATER_YIELD4 {get;set;}

           /// <summary>
           /// Desc:5#水箱流量
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
           /// Desc:2#风门
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG2 {get;set;}

           /// <summary>
           /// Desc:3#风门
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG3 {get;set;}

           /// <summary>
           /// Desc:4#风门
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG4 {get;set;}

           /// <summary>
           /// Desc:5#风门
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG5 {get;set;}

           /// <summary>
           /// Desc:6#风门
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG6 {get;set;}

           /// <summary>
           /// Desc:7#风门
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG7 {get;set;}

           /// <summary>
           /// Desc:8#风门
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG8 {get;set;}

           /// <summary>
           /// Desc:9#风门
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG9 {get;set;}

           /// <summary>
           /// Desc:10#风门
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG10 {get;set;}

           /// <summary>
           /// Desc:11#风门
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG11 {get;set;}

           /// <summary>
           /// Desc:12#风门
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_AIR_BW_ANG12 {get;set;}

           /// <summary>
           /// Desc:13#风门
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
           /// Desc:baowenzhao_state(18个开关量)
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
           /// Desc:第2段辊速
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_AIR_C_Z_CONVEYOR_SPD3 {get;set;}

           /// <summary>
           /// Desc:第3段辊速
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_AIR_C_Z_CONVEYOR_SPD4 {get;set;}

           /// <summary>
           /// Desc:第4段辊速
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? WR_AIR_C_Z_CONVEYOR_SPD5 {get;set;}

           /// <summary>
           /// Desc:第5段辊速
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_AIR_C_Z_CONVEYOR_SPD6 {get;set;}

           /// <summary>
           /// Desc:第6段辊速
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_AIR_C_Z_CONVEYOR_SPD7 {get;set;}

           /// <summary>
           /// Desc:第7段辊速
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_AIR_C_Z_CONVEYOR_SPD8 {get;set;}

           /// <summary>
           /// Desc:第8段辊速
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_AIR_C_Z_CONVEYOR_SPD9 {get;set;}

           /// <summary>
           /// Desc:第9段辊速
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
