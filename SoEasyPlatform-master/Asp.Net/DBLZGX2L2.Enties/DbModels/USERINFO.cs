using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("USERINFO")]
    public partial class USERINFO
    {
           public USERINFO(){


           }
           /// <summary>
           /// Desc:用户ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? USERID {get;set;}

           /// <summary>
           /// Desc:用户工号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string USERCODE {get;set;}

           /// <summary>
           /// Desc:用户角色
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ROLE {get;set;}

           /// <summary>
           /// Desc:用户姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string NAME {get;set;}

           /// <summary>
           /// Desc:用户密码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PASSWORD {get;set;}

           /// <summary>
           /// Desc:用户班别
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string USERSHIFT {get;set;}

    }
}
