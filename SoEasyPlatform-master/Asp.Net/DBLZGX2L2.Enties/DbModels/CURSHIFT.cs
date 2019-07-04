using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("CURSHIFT")]
    public partial class CURSHIFT
    {
           public CURSHIFT(){


           }
           /// <summary>
           /// Desc:用户角色
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ROLE {get;set;}

           /// <summary>
           /// Desc:班次
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SHIFT_DATE {get;set;}

           /// <summary>
           /// Desc:班组
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SHIFT_GROUP {get;set;}

           /// <summary>
           /// Desc:用户编号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string USER_CODE {get;set;}

    }
}
