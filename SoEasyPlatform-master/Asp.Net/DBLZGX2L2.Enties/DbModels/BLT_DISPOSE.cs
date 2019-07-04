using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("BLT_DISPOSE")]
    public partial class BLT_DISPOSE
    {
           public BLT_DISPOSE(){


           }
           /// <summary>
           /// Desc:方坯号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string BLT_NO {get;set;}

           /// <summary>
           /// Desc:批次号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string LOT_NO {get;set;}

           /// <summary>
           /// Desc:炉号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string HEAT_NO {get;set;}

           /// <summary>
           /// Desc:生产开始时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? WR_RL_SAT_DT {get;set;}

           /// <summary>
           /// Desc:方坯剔除时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? WR_RL_DN_DT {get;set;}

           /// <summary>
           /// Desc:生产人员班组
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SHIFT {get;set;}

           /// <summary>
           /// Desc:剔除原因代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DISOP_CAU_CD {get;set;}

           /// <summary>
           /// Desc:操作人员
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RF_EMPLOYEE {get;set;}

           /// <summary>
           /// Desc:方坯状态	1=炉前挑废	2=炉后挑废	4=轧废结束
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? FLAG {get;set;}

           /// <summary>
           /// Desc:剔除说明
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DISOP_DESC {get;set;}

           /// <summary>
           /// Desc:理论重量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public double? BLT_WGT {get;set;}

           /// <summary>
           /// Desc:位置代码 M
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WR_RL_OP_ABNR_OCR_TP_LOC_TP {get;set;}

           /// <summary>
           /// Desc:设备位置分类:轧制风冷I ;其它：J
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WR_RL_OP_ABNR_OCR_EQP_LOC_TP {get;set;}

           /// <summary>
           /// Desc:线卷号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string COIL_NO {get;set;}

    }
}
