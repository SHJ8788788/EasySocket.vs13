using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("orders")]
    public partial class orders
    {
           public orders(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int id {get;set;}

           /// <summary>
           /// Desc:下单用户id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int user_id {get;set;}

           /// <summary>
           /// Desc:订单号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string number {get;set;}

           /// <summary>
           /// Desc:创建订单时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime createtime {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string note {get;set;}

    }
}
