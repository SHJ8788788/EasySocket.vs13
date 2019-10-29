using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("BLT_PROC_DATA")]
    public partial class BLT_PROC_DATA
    {
           public BLT_PROC_DATA(){


           }
           /// <summary>
           /// Desc:坯料号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string BLT_NO {get;set;}

           /// <summary>
           /// Desc:轧批号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string LOT_NO {get;set;}

           /// <summary>
           /// Desc:更新时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

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
           public decimal? HEAT_TEMP_1 {get;set;}

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
           public Single? WR_AIR_C_Z_CONVEYOR_SPD5 {get;set;}

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

        /// <summary>
        /// Desc:(钢坯)出炉炉温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? OUT_FURNACE_TEMP { get; set; }

        /// <summary>
        /// Desc:粗轧入口侧温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_RM_ESD_MAT_TM { get; set; }
        /// <summary>
        /// Desc:中轧入口侧温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_MID_RM_ESD_MAT_TM { get; set; }
        /// <summary>
        /// Desc:预精轧入口侧温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_MID_FIN_RL_ESD_MAT_TM { get; set; }
        /// <summary>
        /// Desc:预精轧出口侧温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_MID_FIN_RL_OT_MAT_TM { get; set; }
        /// <summary>
        /// Desc:精轧出口温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? FINROLL_OUT_TEMP { get; set; }


    }
}
