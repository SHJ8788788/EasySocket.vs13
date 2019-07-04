using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("BLT_PROC")]
    public partial class BLT_PROC
    {
        public BLT_PROC()
        {


        }
        /// <summary>
        /// Desc:线卷号
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true)]
        public string COIL_NO { get; set; }

        /// <summary>
        /// Desc:方坯号
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true)]
        public string BLT_NO { get; set; }

        /// <summary>
        /// Desc:生产批号
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true)]
        public string LOT_NO { get; set; }

        /// <summary>
        /// Desc:生产序号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string SEQ_NO { get; set; }

        /// <summary>
        /// Desc:方坯实际长度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? BLT_LTH { get; set; }

        /// <summary>
        /// Desc:方坯实际重量
        /// Default:
        /// Nullable:True
        /// </summary>           
        public double? BLT_WGT { get; set; }

        /// <summary>
        /// Desc:加热炉装炉日期
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? RF_EN_DT { get; set; }

        /// <summary>
        /// Desc:加热炉出炉日期
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? RF_OUT_DT { get; set; }

        /// <summary>
        /// Desc:加热炉出炉坯温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? RF_DEV_MAT_TM { get; set; }

        /// <summary>
        /// Desc:加热炉装炉作业班
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string RF_CH_OP_SFT { get; set; }

        /// <summary>
        /// Desc:加热炉出炉作业班
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string RF_DEV_OP_SFT { get; set; }

        /// <summary>
        /// Desc:轧制开始日期
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? WR_RL_SAT_DT { get; set; }

        /// <summary>
        /// Desc:轧制结束日期
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? WR_RL_DN_DT { get; set; }

        /// <summary>
        /// Desc:轧制作业班组
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_RL_OP_SFT { get; set; }

        /// <summary>
        /// Desc:加热炉坯料装炉温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? RF_CH_MAT_TM { get; set; }

        /// <summary>
        /// Desc:粗轧入口侧速度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_RM_ESD_SPD { get; set; }

        /// <summary>
        /// Desc:粗轧出口侧速度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_RM_OT_SPD { get; set; }

        /// <summary>
        /// Desc:中轧出口侧速度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_MID_RM_OT_SPD { get; set; }

        /// <summary>
        /// Desc:预精轧出口侧速度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_MID_FIN_RL_OT_SPD { get; set; }

        /// <summary>
        /// Desc:精轧出口侧速度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_FIN_RL_OT_SPD { get; set; }

        /// <summary>
        /// Desc:吐丝机出口侧速度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_LH_RL_OT_SPD { get; set; }

        /// <summary>
        /// Desc:粗轧入口侧坯料温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_RM_ESD_MAT_TM { get; set; }

        /// <summary>
        /// Desc:中轧入口侧坯料温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_MID_RM_ESD_MAT_TM { get; set; }

        /// <summary>
        /// Desc:预精轧入口侧坯料温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_MID_FIN_RL_ESD_MAT_TM { get; set; }

        /// <summary>
        /// Desc:预精轧出口侧坯料温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_MID_FIN_RL_OT_MAT_TM { get; set; }

        /// <summary>
        /// Desc:精轧入口侧坯料温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_FIN_RL_RETE_MAT_TM { get; set; }

        /// <summary>
        /// Desc:精轧出口侧坯料温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_FIN_RL_OT_MAT_TM { get; set; }

        /// <summary>
        /// Desc:吐丝机出口侧温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_LH_OT_MAT_TM { get; set; }

        /// <summary>
        /// Desc:集卷坯料温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_REE_MAT_TM { get; set; }

        /// <summary>
        /// Desc:线卷挂钩日期
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? WR_HOOK_DT { get; set; }

        /// <summary>
        /// Desc:挂钩作业班组
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string HANGING_OP_SFT { get; set; }

        /// <summary>
        /// Desc:挂钩操作员
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string EMPLOYEE_HANG { get; set; }

        /// <summary>
        /// Desc:线卷钩号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_HOOK_NUM { get; set; }

        /// <summary>
        /// Desc:线卷称重日期
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? WR_WGTING_DT { get; set; }

        /// <summary>
        /// Desc:称重作业班组
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WGTING_OP_SFT { get; set; }

        /// <summary>
        /// Desc:产品毛重
        /// Default:
        /// Nullable:True
        /// </summary>           
        public double? PRD_GR_ACTUAL_WGT { get; set; }

        /// <summary>
        /// Desc:产品净重
        /// Default:
        /// Nullable:True
        /// </summary>           
        public double? PRD_NET_ACTUAL_WGT { get; set; }

        /// <summary>
        /// Desc:外观等级
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string EXT_TOT_JDG_GD { get; set; }

        /// <summary>
        /// Desc:外观综合等级原因代码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string APP_DGR { get; set; }

        /// <summary>
        /// Desc:外观检查等级
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_EXT_INSP_GD { get; set; }

        /// <summary>
        /// Desc:高线缺陷评分
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_DEF_AVP { get; set; }

        /// <summary>
        /// Desc:高线废料量
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? WR_SCR_QT { get; set; }

        /// <summary>
        /// Desc:线卷卸货位置
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_UNLOAD_LOC { get; set; }

        /// <summary>
        /// Desc:线卷打捆机号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_UTE_MCN_NUM { get; set; }

        /// <summary>
        /// Desc:线卷打捆机打捆压力
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? WR_UTE_MCN_UTE_PRS { get; set; }

        /// <summary>
        /// Desc:线卷打捆机线卷高度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? WR_UTE_MCN_COIL_HEIT { get; set; }

        /// <summary>
        /// Desc:线卷外观检查员ID
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_EXT_INSP_EMP_ID { get; set; }

        /// <summary>
        /// Desc:高线包装材重量
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? WR_PACK_HOOP_WGT { get; set; }

        /// <summary>
        /// Desc:轧制作业发生异常日期
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? RL_OP_ABNR_OCR_DT { get; set; }

        /// <summary>
        /// Desc:高线发生轧废班组
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_COB_OCR_SFT { get; set; }

        /// <summary>
        /// Desc:高线发生轧制作业异常类型分类
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_RL_OP_ABNR_OCR_TP_LOC_TP { get; set; }

        /// <summary>
        /// Desc:高线发生轧制作业异常设备位置分类
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_RL_OP_ABNR_OCR_EQP_LOC_TP { get; set; }

        /// <summary>
        /// Desc:订单／余材分类
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ORD_YN { get; set; }

        /// <summary>
        /// Desc:余材原因代码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string SPRD_CAU_CD { get; set; }

        /// <summary>
        /// Desc:高线缺陷代码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_DEF_CD { get; set; }

        /// <summary>
        /// Desc:称重操作员
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string EMPLOYEE_WGT { get; set; }

        /// <summary>
        /// Desc:方坯状态0=还未投产	1=作业中	10=进入加热炉	11=出加热炉	12=开始轧制	13=轧制结束 挂钩前	14=挂钩后 称重前	15= 称重完成	2=成品入库结束	3=挑废结束	4=轧废结束
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string BLT_FLG { get; set; }

        /// <summary>
        /// Desc:轧制完成班次
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string FINISH_SHIFT { get; set; }

        /// <summary>
        /// Desc:生产完成时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? FINISH_DATE { get; set; }

        /// <summary>
        /// Desc:炉号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string HEAT_NO { get; set; }

        /// <summary>
        /// Desc:线卷返送标志
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string COILBACK_FLAG { get; set; }

        /// <summary>
        /// Desc:进入打标列表标志
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ENTER_PRINT { get; set; }

        /// <summary>
        /// Desc:预热段炉顶中温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? RF_PRHT_TM { get; set; }

        /// <summary>
        /// Desc:上加热段左侧温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? RF_HTUL_Z_TM { get; set; }

        /// <summary>
        /// Desc:上加热段右侧温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? RF_HTUR_Z_TM { get; set; }

        /// <summary>
        /// Desc:下加热段左侧温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? RF_HTDL_Z_TM { get; set; }

        /// <summary>
        /// Desc:下加热段右侧温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? RF_HTDR_Z_TM { get; set; }

        /// <summary>
        /// Desc:上均热段左侧温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? RF_NORUL_Z_TM { get; set; }

        /// <summary>
        /// Desc:上均热段右侧温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? RF_NORUR_Z_TM { get; set; }

        /// <summary>
        /// Desc:上均热段顶部温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? RF_NORUU_Z_TM { get; set; }

        /// <summary>
        /// Desc:下均热段左侧温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? RF_NORDL_Z_TM { get; set; }

        /// <summary>
        /// Desc:下均热段右侧温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? RF_NORDR_Z_TM { get; set; }

        /// <summary>
        /// Desc:下均热段顶部温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? RF_NORDU_Z_TM { get; set; }

        /// <summary>
        /// Desc:在炉序号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? SEQ_IN_FURANCE { get; set; }

        /// <summary>
        /// Desc:收集标志:0:未进入;1:进粗轧;2:进中轧;3:进预精轧;4:进精轧;5:吐丝
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string INFO_FLAG { get; set; }

        /// <summary>
        /// Desc:1#风机风量
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_AIR_BW_ANG1 { get; set; }

        /// <summary>
        /// Desc:2#风机风量
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_AIR_BW_ANG2 { get; set; }

        /// <summary>
        /// Desc:3#风机风量
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_AIR_BW_ANG3 { get; set; }

        /// <summary>
        /// Desc:4#风机风量
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_AIR_BW_ANG4 { get; set; }

        /// <summary>
        /// Desc:51#风机风量
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_AIR_BW_ANG5 { get; set; }

        /// <summary>
        /// Desc:6#风机风量
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_AIR_BW_ANG6 { get; set; }

        /// <summary>
        /// Desc:7#风机风量
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_AIR_BW_ANG7 { get; set; }

        /// <summary>
        /// Desc:8#风机风量
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_AIR_BW_ANG8 { get; set; }

        /// <summary>
        /// Desc:9#风机风量
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_AIR_BW_ANG9 { get; set; }

        /// <summary>
        /// Desc:10#风机风量
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_AIR_BW_ANG10 { get; set; }

        /// <summary>
        /// Desc:11#风机风量
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_AIR_BW_ANG11 { get; set; }

        /// <summary>
        /// Desc:头部辊道速度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_AIR_C_Z_SPD_ENTER { get; set; }

        /// <summary>
        /// Desc:1#辊道速度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_AIR_C_Z_SPD1 { get; set; }

        /// <summary>
        /// Desc:2#辊道速度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_AIR_C_Z_SPD2 { get; set; }

        /// <summary>
        /// Desc:3#辊道速度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_AIR_C_Z_SPD3 { get; set; }

        /// <summary>
        /// Desc:4#辊道速度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_AIR_C_Z_SPD4 { get; set; }

        /// <summary>
        /// Desc:5#辊道速度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_AIR_C_Z_SPD5 { get; set; }

        /// <summary>
        /// Desc:6#辊道速度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_AIR_C_Z_SPD6 { get; set; }

        /// <summary>
        /// Desc:7#辊道速度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_AIR_C_Z_SPD7 { get; set; }

        /// <summary>
        /// Desc:8#辊道速度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_AIR_C_Z_SPD8 { get; set; }

        /// <summary>
        /// Desc:9#辊道速度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_AIR_C_Z_SPD9 { get; set; }

        /// <summary>
        /// Desc:10#辊道速度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_AIR_C_Z_SPD10 { get; set; }

        /// <summary>
        /// Desc:尾部辊道速度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_AIR_C_Z_SPD_EXIT { get; set; }

        /// <summary>
        /// Desc:保温罩启动与否1
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_SLW_C_CVR_OP_F1 { get; set; }

        /// <summary>
        /// Desc:保温罩启动与否2
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_SLW_C_CVR_OP_F2 { get; set; }

        /// <summary>
        /// Desc:保温罩启动与否3
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_SLW_C_CVR_OP_F3 { get; set; }

        /// <summary>
        /// Desc:保温罩启动与否4
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_SLW_C_CVR_OP_F4 { get; set; }

        /// <summary>
        /// Desc:保温罩启动与否5
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_SLW_C_CVR_OP_F5 { get; set; }

        /// <summary>
        /// Desc:保温罩启动与否6
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_SLW_C_CVR_OP_F6 { get; set; }

        /// <summary>
        /// Desc:保温罩启动与否7
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_SLW_C_CVR_OP_F7 { get; set; }

        /// <summary>
        /// Desc:保温罩启动与否8
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_SLW_C_CVR_OP_F8 { get; set; }

        /// <summary>
        /// Desc:保温罩启动与否9
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_SLW_C_CVR_OP_F9 { get; set; }

        /// <summary>
        /// Desc:保温罩启动与否10
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_SLW_C_CVR_OP_F10 { get; set; }

        /// <summary>
        /// Desc:保温罩启动与否11
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_SLW_C_CVR_OP_F11 { get; set; }

        /// <summary>
        /// Desc:保温罩启动与否12
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_SLW_C_CVR_OP_F12 { get; set; }

        /// <summary>
        /// Desc:保温罩启动与否13
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_SLW_C_CVR_OP_F13 { get; set; }

        /// <summary>
        /// Desc:保温罩启动与否14
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_SLW_C_CVR_OP_F14 { get; set; }

        /// <summary>
        /// Desc:保温罩启动与否15
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_SLW_C_CVR_OP_F15 { get; set; }

        /// <summary>
        /// Desc:保温罩启动与否16
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_SLW_C_CVR_OP_F16 { get; set; }

        /// <summary>
        /// Desc:保温罩启动与否17
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_SLW_C_CVR_OP_F17 { get; set; }

        /// <summary>
        /// Desc:保温罩启动与否18
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string WR_SLW_C_CVR_OP_F18 { get; set; }

        /// <summary>
        /// Desc:水箱穿水水压(1-5号)
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_WATER_PRE1 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_WATER_PRE2 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_WATER_PRE3 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_WATER_PRE4 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_WATER_PRE5 { get; set; }

        /// <summary>
        /// Desc:水箱穿水水量(1-5号)
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_WATER_YIELD1 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_WATER_YIELD2 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_WATER_YIELD3 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_WATER_YIELD4 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short? WR_WATER_YIELD5 { get; set; }

        /// <summary>
        /// Desc:水箱穿水进水温度(1-5号)
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_WATER_IN_TM1 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_WATER_IN_TM2 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_WATER_IN_TM3 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_WATER_IN_TM4 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_WATER_IN_TM5 { get; set; }

        /// <summary>
        /// Desc:水箱穿水出水温度(1-5号)
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_WATER_OUT_TM1 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_WATER_OUT_TM2 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_WATER_OUT_TM3 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_WATER_OUT_TM4 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public Single? WR_WATER_OUT_TM5 { get; set; }

        /// <summary>
        /// Desc:停机开始时间(咬钢结束)
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ACC_START_TIME { get; set; }

        /// <summary>
        /// Desc:停机结束时间(咬钢开始)
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ACC_END_TIME { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string BAK_3 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string BAK_4 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? BAK_5 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? BAK_6 { get; set; }

        /// <summary>
        /// Desc:装炉操作员
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string EMPLOYEE_ENRF { get; set; }

        /// <summary>
        /// Desc:出炉操作员
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string EMPLOYEE_OUTRF { get; set; }

        /// <summary>
        /// Desc:轧制操作员
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string EMPLOYEE_MILL { get; set; }

        /// <summary>
        /// Desc:A:auto;M:man
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string EN_MILL_TP { get; set; }

        /// <summary>
        /// Desc:计量顺序号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string SINGLE_ITEM_NUMBER { get; set; }

        /// <summary>
        /// Desc:成品堆垛位置
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string STRE_LOC_CD { get; set; }

        /// <summary>
        /// Desc:改判钢种
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string X_MILL_GRADE { get; set; }

        /// <summary>
        /// Desc:称重次数
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? WEIGHT_CNT { get; set; }

        /// <summary>
        /// Desc:<> 粗轧机开始轧制时刻
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? COAROLL_START_TIME { get; set; }

        /// <summary>
        /// Desc:<> 粗轧机结束轧制时刻
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? COAROLL_END_TIME { get; set; }

        /// <summary>
        /// Desc:<> 中轧开始时刻
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? MIDROLL_START_TIME { get; set; }

        /// <summary>
        /// Desc:<> 中轧结束时刻
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? MIDROLL_END_TIME { get; set; }

        /// <summary>
        /// Desc:<> 预精轧机开始轧制时刻
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? MIDFINROLL_START_TIME { get; set; }

        /// <summary>
        /// Desc:<> 预精轧机结束轧制时刻
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? MIDFINROLL_END_TIME { get; set; }

        /// <summary>
        /// Desc:<> 精轧机开始轧制时刻
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? FINROLL_START_TIME { get; set; }

        /// <summary>
        /// Desc:<> 精轧机结束轧制时刻
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? FINROLL_END_TIME { get; set; }

        /// <summary>
        /// Desc:<> 吐丝机开始轧制时刻
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? TUSHI_START_TIME { get; set; }

        /// <summary>
        /// Desc:<> 吐丝机结束轧制时刻
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? TUSHI_END_TIME { get; set; }


    }
}
