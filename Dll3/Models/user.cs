using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("user")]
    public partial class user
    {
           public user(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int id {get;set;}

           /// <summary>
           /// Desc:用户名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string username {get;set;}

           /// <summary>
           /// Desc:生日
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? birthday {get;set;}

           /// <summary>
           /// Desc:性别
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string sex {get;set;}

           /// <summary>
           /// Desc:地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string address {get;set;}

    }
}
