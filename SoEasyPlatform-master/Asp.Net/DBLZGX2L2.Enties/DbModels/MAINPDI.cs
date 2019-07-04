using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("MAINPDI")]
    public partial class MAINPDI
    {
           public MAINPDI(){


           }
           /// <summary>
           /// Desc:检验批号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string LOT_NO {get;set;}

           /// <summary>
           /// Desc:炉号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string HEAT_NO {get;set;}

           /// <summary>
           /// Desc:坯料钢种
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string STEEL_GRADE {get;set;}

           /// <summary>
           /// Desc:坯料规格
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BLT_FAC {get;set;}

           /// <summary>
           /// Desc:轧制钢种
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MILL_GRADE {get;set;}

           /// <summary>
           /// Desc:轧制规格
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? FINISH_SIZE {get;set;}

           /// <summary>
           /// Desc:坯料支数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? BLT_NUM {get;set;}

           /// <summary>
           /// Desc:登记时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? REG_TIME {get;set;}

           /// <summary>
           /// Desc:订单号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ORD_NO {get;set;}

           /// <summary>
           /// Desc:0:未开始生产  1:生产中  2: 生产完成
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string FLAG {get;set;}

           /// <summary>
           /// Desc:方坯重量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? BLT_WGT {get;set;}

           /// <summary>
           /// Desc:完成数量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? FINISH_NUM {get;set;}

           /// <summary>
           /// Desc:入炉数量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? ENRF_NUM {get;set;}

           /// <summary>
           /// Desc:轧制完成数量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? MILL_NUM {get;set;}

           /// <summary>
           /// Desc:挂钩完成数量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? HOOK_NUM {get;set;}

           /// <summary>
           /// Desc:生产开始时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? STARTPRO_TIME {get;set;}

           /// <summary>
           /// Desc:生产结束时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? ENDPRO_TIME {get;set;}

           /// <summary>
           /// Desc:任务号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SCHEDULE_NO {get;set;}

           /// <summary>
           /// Desc:入炉序号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EN_RF_SEQ {get;set;}

           /// <summary>
           /// Desc:出炉数量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? EXRF_NUM {get;set;}

           /// <summary>
           /// Desc:轧废或剔除支数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? MISS_NUM {get;set;}

           /// <summary>
           /// Desc:生产主顺序号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MAIN_SEQ {get;set;}

           /// <summary>
           /// Desc:次顺序号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? SEC_SEQ {get;set;}

    }
}
