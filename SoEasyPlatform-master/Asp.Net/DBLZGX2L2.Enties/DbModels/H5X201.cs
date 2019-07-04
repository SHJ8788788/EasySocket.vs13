using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("H5X201")]
    public partial class H5X201
    {
           public H5X201(){


           }
           /// <summary>
           /// Desc:流水号
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
           /// Desc:坯料号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BILLET_NO {get;set;}

           /// <summary>
           /// Desc:原料的规格-长	
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? BLT_LEN {get;set;}

           /// <summary>
           /// Desc:原料的规格-重	
           /// Default:
           /// Nullable:True
           /// </summary>           
           public double? BLT_WGT {get;set;}

           /// <summary>
           /// Desc:断面（规格-例：170*170）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BLT_FAC {get;set;}

           /// <summary>
           /// Desc:产出的直径要求-标准值	
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? ORD_DIA {get;set;}

           /// <summary>
           /// Desc:产出的直径要求-最大值	
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? ORD_DIA_MAX {get;set;}

           /// <summary>
           /// Desc:产出的直径要求-最小值	
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? ORD_DIA_MIM {get;set;}

           /// <summary>
           /// Desc:钢种	
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string STL_GRD {get;set;}

           /// <summary>
           /// Desc:检验批号	
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SMP_NO {get;set;}

           /// <summary>
           /// Desc:CCR,HCR,WCR标识（红送:R  冷送:L）	
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string HCT_STAT {get;set;}

           /// <summary>
           /// Desc:出炉温度上限	
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? BLT_DIS_TEM_UP {get;set;}

           /// <summary>
           /// Desc:出炉温度下限	
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? BLT_DIS_TEM_DOWN {get;set;}

           /// <summary>
           /// Desc:精轧温度上限	
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? BLT_FM_TEM_UP {get;set;}

           /// <summary>
           /// Desc:精轧温度下限	
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? BLT_FM_TEM_DOWN {get;set;}

           /// <summary>
           /// Desc:炉号	
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string HEAT_ID {get;set;}

           /// <summary>
           /// Desc:件编号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string COIL_NO {get;set;}

           /// <summary>
           /// Desc:C
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? C {get;set;}

           /// <summary>
           /// Desc:SI
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? SI {get;set;}

           /// <summary>
           /// Desc:MN
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? MN {get;set;}

           /// <summary>
           /// Desc:TE
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? TE {get;set;}

           /// <summary>
           /// Desc:BI
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? BI {get;set;}

           /// <summary>
           /// Desc:CU
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? CU {get;set;}

           /// <summary>
           /// Desc:ALS
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? ALS {get;set;}

           /// <summary>
           /// Desc:ALT
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? ALT {get;set;}

           /// <summary>
           /// Desc:NB
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? NB {get;set;}

           /// <summary>
           /// Desc:V
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? V {get;set;}

           /// <summary>
           /// Desc:NI
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? NI {get;set;}

           /// <summary>
           /// Desc:CR
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? CR {get;set;}

           /// <summary>
           /// Desc:MO
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? MO {get;set;}

           /// <summary>
           /// Desc:B
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? B {get;set;}

           /// <summary>
           /// Desc:TI
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? TI {get;set;}

           /// <summary>
           /// Desc:CA
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? CA {get;set;}

           /// <summary>
           /// Desc:SN
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? SN {get;set;}

           /// <summary>
           /// Desc:ZR
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? ZR {get;set;}

           /// <summary>
           /// Desc:CEQ
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? CEQ {get;set;}

           /// <summary>
           /// Desc:AS
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? AS1 {get;set;}

           /// <summary>
           /// Desc:RE
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? RE {get;set;}

           /// <summary>
           /// Desc:CO
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? CO {get;set;}

           /// <summary>
           /// Desc:PB
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? PB {get;set;}

           /// <summary>
           /// Desc:W
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? W {get;set;}

           /// <summary>
           /// Desc:MG
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? MG {get;set;}

           /// <summary>
           /// Desc:SB
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? SB {get;set;}

           /// <summary>
           /// Desc:取样位置：0:头部，1:中部，2:尾部，3:不明	
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
           /// Desc:入炉顺序号（当天的年月日+ 4位流水号）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IN_SEQ {get;set;}

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
           /// Desc:理重
           /// Default:
           /// Nullable:True
           /// </summary>           
           public double? WT_PER_METER {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK1 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK2 {get;set;}

           /// <summary>
           /// Desc:
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
