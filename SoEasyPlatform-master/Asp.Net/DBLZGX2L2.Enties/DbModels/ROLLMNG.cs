using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("ROLLMNG")]
    public partial class ROLLMNG
    {
           public ROLLMNG(){


           }
           /// <summary>
           /// Desc:轧辊位置
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ROLL_LOC {get;set;}

           /// <summary>
           /// Desc:所用辊槽
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ROLL_SLOT {get;set;}

           /// <summary>
           /// Desc:轧辊编号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ROLL_NO {get;set;}

           /// <summary>
           /// Desc:换槽上线时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? START_DATE {get;set;}

           /// <summary>
           /// Desc:下线时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? END_DATE {get;set;}

           /// <summary>
           /// Desc:预定轧制重量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public double? PRE_WEIGHT {get;set;}

           /// <summary>
           /// Desc:实际轧制质量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public double? FINISH_WEIGHT {get;set;}

           /// <summary>
           /// Desc:辊槽状态：0=未使用，1=使用中，2=使用完毕
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string FLAG {get;set;}

           /// <summary>
           /// Desc:预定更换时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? PRE_DATE {get;set;}

           /// <summary>
           /// Desc:轧辊上线时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? ROLL_START_TIME {get;set;}

           /// <summary>
           /// Desc:辊槽数量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? SLOT_NUM {get;set;}

    }
}
