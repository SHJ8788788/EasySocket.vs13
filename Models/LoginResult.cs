using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 表示登录结果
    /// </summary>
    [ProtoContract]
    public class LoginResult
    {
        [ProtoMember(1)]
        public bool State { get; set; }

        [ProtoMember(2)]
        public string Message { get; set; }
    }
}
