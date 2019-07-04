using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("PRIDATA")]
    public partial class PRIDATA
    {
           public PRIDATA(){


           }
           /// <summary>
           /// Desc:记录时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? REG_DATA_TIME {get;set;}

           /// <summary>
           /// Desc:炉号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string HEAT_NO {get;set;}

           /// <summary>
           /// Desc:方坯钢种
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string STEEL_GRADE {get;set;}

           /// <summary>
           /// Desc:钢坯数量（预删）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? BILLET_NUM {get;set;}

           /// <summary>
           /// Desc:轧制规格
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? FINISH_SIZE {get;set;}

           /// <summary>
           /// Desc:轧制程序编号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ROLL_SCH_ID {get;set;}

           /// <summary>
           /// Desc:冷却程序
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string COOL_SCH_ID {get;set;}

           /// <summary>
           /// Desc:出炉钢坯数量（预删）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? DISCHARGE_NUM {get;set;}

           /// <summary>
           /// Desc:处理标志,0:待生产;1:已投入生产;2:删除
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? FLAG {get;set;}

           /// <summary>
           /// Desc:方坯号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BILLET_NO {get;set;}

           /// <summary>
           /// Desc:方坯长度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? BLT_LEN {get;set;}

           /// <summary>
           /// Desc:方坯重量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public double? BLT_WGT {get;set;}

           /// <summary>
           /// Desc:方坯规格
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BLT_FAC {get;set;}

           /// <summary>
           /// Desc:线卷直径
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? ORD_DIA {get;set;}

           /// <summary>
           /// Desc:线卷最大直径
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? ORD_DIA_MAX {get;set;}

           /// <summary>
           /// Desc:线卷最小直径
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? ORD_DIA_MIN {get;set;}

           /// <summary>
           /// Desc:批次号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string LOT_NO {get;set;}

           /// <summary>
           /// Desc:方坯钢种
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ORD_STE_GRD {get;set;}

           /// <summary>
           /// Desc:取样号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SMP_NO {get;set;}

           /// <summary>
           /// Desc:装炉分类号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string HCT_STAT_CD {get;set;}

           /// <summary>
           /// Desc:出炉温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? BLT_DIS_TEM {get;set;}

           /// <summary>
           /// Desc:精轧温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? BLT_FM_TEM {get;set;}

           /// <summary>
           /// Desc:订单号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ORD_MARK_CD {get;set;}

           /// <summary>
           /// Desc:订单客户
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ORD_CUST_N {get;set;}

           /// <summary>
           /// Desc:线卷号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string COIL_NO {get;set;}

           /// <summary>
           /// Desc:取样位置
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SMP_POS {get;set;}

           /// <summary>
           /// Desc:取样长度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? SMP_LEN {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_C {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_SI {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_MN {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_TE {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_BI {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_CU {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_ALS {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_ALT {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_NB {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_V {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_NI {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_CR {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_MO {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_B {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_TI {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_CA {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_SN {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_ZR {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_CEQ {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_RE {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_CO {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_PB {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_W {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_MG {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_SB {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? COMPOSE_AS {get;set;}

           /// <summary>
           /// Desc:生产序号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string SEQ_NO {get;set;}

           /// <summary>
           /// Desc:检验批号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SMP_LOT_NO {get;set;}

           /// <summary>
           /// Desc:次顺序号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? SEC_SEQ_NO {get;set;}

           /// <summary>
           /// Desc:批次内顺序
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? BILLET_SEQ {get;set;}

           /// <summary>
           /// Desc:轧制钢种
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MILL_GRADE {get;set;}

           /// <summary>
           /// Desc:标牌类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string STEEL_TYPE_4 {get;set;}

           /// <summary>
           /// Desc:质保书标准
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string STEEL_MARKING_METHOD {get;set;}

           /// <summary>
           /// Desc:计重方式0实重，1理重
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WEIGHT_TYPE {get;set;}

           /// <summary>
           /// Desc:计划结束标识
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string FINISH_FLAG {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK1 {get;set;}

           /// <summary>
           /// Desc:打印用牌号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK2 {get;set;}

           /// <summary>
           /// Desc:产品名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK3 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK4 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK5 {get;set;}

    }
}
