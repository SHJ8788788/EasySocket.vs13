using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Sugar.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("PRINTTMP")]
    public partial class PRINTTMP
    {
           public PRINTTMP(){


           }
           /// <summary>
           /// Desc:模板(W1、W2、W3、W4)
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string TEMP {get;set;}

           /// <summary>
           /// Desc:IP地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IP {get;set;}

           /// <summary>
           /// Desc:纸张类型（有标A、无标B）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SHEET {get;set;}

           /// <summary>
           /// Desc:称重机号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string WEIGHT_NO {get;set;}

           /// <summary>
           /// Desc:操作人员
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EMPLOYEE {get;set;}

           /// <summary>
           /// Desc:新增修改日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CREATEDATE {get;set;}

    }
}
