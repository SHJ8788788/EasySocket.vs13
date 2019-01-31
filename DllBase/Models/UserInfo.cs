using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Models
{    ///<summary>
     ///
     ///</summary>
    [SugarTable("userinfo")]
    public partial class userInfo
    {
        public userInfo()
        {
        }
        /// <summary>
        /// Desc:用户ID
        /// Default:
        /// Nullable:False
        /// </summary> 
        public int userid { get; set; }

        /// <summary>
        /// Desc:用户工号
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string usercode { get; set; }
        /// <summary>
        /// Desc:用户角色
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string role { get; set; }
        /// <summary>
        /// Desc:用户姓名
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string name { get; set; }
        /// <summary>
        /// Desc:用户密码
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string password { get; set; }
        /// <summary>
        /// Desc:用户班别
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string usershift { get; set; }
    }
}