using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("P_DATA_RF")]
    public partial class P_DATA_RF
    {
           public P_DATA_RF(){


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

    }
}
