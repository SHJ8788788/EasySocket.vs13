using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("orderdetail")]
    public partial class orderdetail
    {
           public orderdetail(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int id {get;set;}

           /// <summary>
           /// Desc:订单id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int orders_id {get;set;}

           /// <summary>
           /// Desc:商品id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int items_id {get;set;}

           /// <summary>
           /// Desc:商品购买数量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? items_num {get;set;}

    }
}
