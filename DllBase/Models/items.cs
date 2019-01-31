using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("items")]
    public partial class items
    {
           public items(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int id {get;set;}

           /// <summary>
           /// Desc:商品名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string name {get;set;}

           /// <summary>
           /// Desc:商品定价
           /// Default:
           /// Nullable:False
           /// </summary>           
           public float price {get;set;}

           /// <summary>
           /// Desc:商品描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string detail {get;set;}

           /// <summary>
           /// Desc:商品图片
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string pic {get;set;}

           /// <summary>
           /// Desc:生产日期
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime createtime {get;set;}

    }
}
