using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("BLT_WEIGHT_CHK")]
    public partial class BLT_WEIGHT_CHK
    {
           public BLT_WEIGHT_CHK(){


           }
           /// <summary>
           /// Desc:时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? WR_WGT_DT {get;set;}

           /// <summary>
           /// Desc:钩号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? HOOKNO {get;set;}

           /// <summary>
           /// Desc:称重位置
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WGTPOS {get;set;}

           /// <summary>
           /// Desc:重量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public double? WGT {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string USER_CODE {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BAK_3 {get;set;}

    }
}
