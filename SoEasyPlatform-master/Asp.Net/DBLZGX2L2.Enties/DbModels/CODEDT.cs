using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("CODEDT")]
    public partial class CODEDT
    {
           public CODEDT(){


           }
           /// <summary>
           /// Desc:代码管理号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CD_MANA_NO {get;set;}

           /// <summary>
           /// Desc:代码号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CD {get;set;}

           /// <summary>
           /// Desc:代码说明
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CD_DESC {get;set;}

           /// <summary>
           /// Desc:代码名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CD_NAME {get;set;}

           /// <summary>
           /// Desc:代码名称简称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CD_SHORT_NAME {get;set;}

    }
}
