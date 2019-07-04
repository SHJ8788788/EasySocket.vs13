using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("H5X20A")]
    public partial class H5X20A
    {
           public H5X20A(){


           }
           /// <summary>
           /// Desc:流水号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? MSG_ID {get;set;}

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
           /// Desc:检验批号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SAMPLE_LOT_NO {get;set;}

           /// <summary>
           /// Desc:件编号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PIECE_NO_1 {get;set;}

           /// <summary>
           /// Desc:标准
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SG_STD {get;set;}

           /// <summary>
           /// Desc:牌号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SG_SIGN {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public double? WT_PER_METER {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? ORD_DIA {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? MAT_WIDTH {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? MAT_LEN {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MODEL_ID {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? OUT_MAT_NUM {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public double? BUNDLE_WT {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ROLL_TIME {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public double? MAT_RHEORY_WT {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WT_MODE {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SHROT_FLAG {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BUSI_ID {get;set;}

           /// <summary>
           /// Desc:采购单号和产品编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SPARE_ITEM_10 {get;set;}

           /// <summary>
           /// Desc:打印用牌号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SPARE_ITEM_11 {get;set;}

           /// <summary>
           /// Desc:产品名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SPARE_ITEM_12 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SPARE_ITEM_13 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SPARE_ITEM_14 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SPARE_ITEM_15 {get;set;}

    }
}
