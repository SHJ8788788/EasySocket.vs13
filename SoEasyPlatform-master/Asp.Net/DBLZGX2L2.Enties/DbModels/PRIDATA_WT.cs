using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("PRIDATA_WT")]
    public partial class PRIDATA_WT
    {
           public PRIDATA_WT(){


           }
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
           /// Desc:米重
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? WT_PER_METER {get;set;}

           /// <summary>
           /// Desc:材料厚度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? MAT_THICK {get;set;}

           /// <summary>
           /// Desc:材料宽度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? MAT_WIDTH {get;set;}

           /// <summary>
           /// Desc:材料长度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? MAT_LEN {get;set;}

           /// <summary>
           /// Desc:标牌模板编号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? ORD_DIA {get;set;}

           /// <summary>
           /// Desc:称重完成标识（0：未完成，1：已完成）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MODEL_ID {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WT_FLAG {get;set;}

           /// <summary>
           /// Desc:重量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public double? MAT_RHEORY_WT {get;set;}

           /// <summary>
           /// Desc:生产日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ROLL_TIME {get;set;}

           /// <summary>
           /// Desc:采购单号和产品编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PROD_STATUS_DESC {get;set;}

           /// <summary>
           /// Desc:打印用牌号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PRINT_SG_SIGN {get;set;}

           /// <summary>
           /// Desc:产品名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PROD_CNAME {get;set;}

           /// <summary>
           /// Desc:称量1 打印0
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WEIGHT_OR_PRINT {get;set;}

    }
}
