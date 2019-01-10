using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [ProtoContract]
    public class SetNameResult
    {
        [ProtoMember(1)]
        public bool State { get; set; }
        [ProtoMember(2)]
        public string Message { get; set; }
        [ProtoMember(3)]
        public string Name { get; set; }
    }
}
