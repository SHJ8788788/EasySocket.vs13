using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("CURCTRA_1")]
    public partial class CURCTRA_1
    {
           public CURCTRA_1(){


           }
           /// <summary>
           /// Desc:集卷台
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEM {get;set;}

           /// <summary>
           /// Desc:判断是否有手动钩号以释放当前重钩（0：复位，XX：手动输入的钩号）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TYPE {get;set;}

           /// <summary>
           /// Desc:强制释放当前重钩（0：不释放， 1：强制释放）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SIGNALIN {get;set;}

    }
}
