using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("P_DATA")]
    public partial class P_DATA
    {
           public P_DATA(){


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
           /// Desc:辊道速度1
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? MILLSPD1 {get;set;}

           /// <summary>
           /// Desc:辊道速度2
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? MILLSPD2 {get;set;}

           /// <summary>
           /// Desc:辊道速度3
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? MILLSPD3 {get;set;}

           /// <summary>
           /// Desc:辊道速度4
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? MILLSPD4 {get;set;}

           /// <summary>
           /// Desc:辊道速度5
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? MILLSPD5 {get;set;}

           /// <summary>
           /// Desc:轧辊区温度1
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? MILLTM1 {get;set;}

           /// <summary>
           /// Desc:轧辊区温度2
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? MILLTM2 {get;set;}

           /// <summary>
           /// Desc:轧辊区温度3
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? MILLTM3 {get;set;}

           /// <summary>
           /// Desc:轧辊区温度4
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? MILLTM4 {get;set;}

           /// <summary>
           /// Desc:轧辊区温度5
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? MILLTM5 {get;set;}

           /// <summary>
           /// Desc:轧辊区温度6
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? MILLTM6 {get;set;}

           /// <summary>
           /// Desc:轧辊区温度7
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? MILLTM7 {get;set;}

           /// <summary>
           /// Desc:轧辊区温度8
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? MILLTM8 {get;set;}

           /// <summary>
           /// Desc:风机风量1
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? BW_ANGLE1 {get;set;}

           /// <summary>
           /// Desc:风机风量2
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? BW_ANGLE2 {get;set;}

           /// <summary>
           /// Desc:风机风量3
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? BW_ANGLE3 {get;set;}

           /// <summary>
           /// Desc:风机风量4
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? BW_ANGLE4 {get;set;}

           /// <summary>
           /// Desc:风机风量5
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? BW_ANGLE5 {get;set;}

           /// <summary>
           /// Desc:风机风量6
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? BW_ANGLE6 {get;set;}

           /// <summary>
           /// Desc:风机风量7
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? BW_ANGLE7 {get;set;}

           /// <summary>
           /// Desc:风机风量8
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? BW_ANGLE8 {get;set;}

           /// <summary>
           /// Desc:风机风量9
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? BW_ANGLE9 {get;set;}

           /// <summary>
           /// Desc:风机风量10
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? BW_ANGLE10 {get;set;}

           /// <summary>
           /// Desc:风机风量11
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? BW_ANGLE11 {get;set;}

           /// <summary>
           /// Desc:冷区辊道速度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? CZ_SPD1 {get;set;}

           /// <summary>
           /// Desc:冷区辊道速度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? CZ_SPD2 {get;set;}

           /// <summary>
           /// Desc:冷区辊道速度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? CZ_SPD3 {get;set;}

           /// <summary>
           /// Desc:冷区辊道速度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? CZ_SPD4 {get;set;}

           /// <summary>
           /// Desc:冷区辊道速度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? CZ_SPD5 {get;set;}

           /// <summary>
           /// Desc:冷区辊道速度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? CZ_SPD6 {get;set;}

           /// <summary>
           /// Desc:冷区辊道速度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? CZ_SPD7 {get;set;}

           /// <summary>
           /// Desc:冷区辊道速度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? CZ_SPD8 {get;set;}

           /// <summary>
           /// Desc:冷区辊道速度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? CZ_SPD9 {get;set;}

           /// <summary>
           /// Desc:冷区辊道速度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? CZ_SPD10 {get;set;}

           /// <summary>
           /// Desc:冷区辊道速度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? CZ_SPD11 {get;set;}

           /// <summary>
           /// Desc:冷区辊道速度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? CZ_SPD12 {get;set;}

           /// <summary>
           /// Desc:水箱穿水水压(1-5号)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_WATER_PRE1 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_WATER_PRE2 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_WATER_PRE3 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_WATER_PRE4 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_WATER_PRE5 {get;set;}

           /// <summary>
           /// Desc:水箱穿水水量(1-5号)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_WATER_YIELD1 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_WATER_YIELD2 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_WATER_YIELD3 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_WATER_YIELD4 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? WR_WATER_YIELD5 {get;set;}

           /// <summary>
           /// Desc:水箱穿水进水温度(1-5号)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_WATER_IN_TM1 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_WATER_IN_TM2 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_WATER_IN_TM3 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_WATER_IN_TM4 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_WATER_IN_TM5 {get;set;}

           /// <summary>
           /// Desc:水箱穿水出水温度(1-5号)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_WATER_OUT_TM1 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_WATER_OUT_TM2 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_WATER_OUT_TM3 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_WATER_OUT_TM4 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Single? WR_WATER_OUT_TM5 {get;set;}

    }
}
