using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Convert;

namespace Models
{
    /// <summary>
    /// 与OpLink通讯的基础包装类
    /// </summary>
    [ProtoContract]
    public class TagSimple
    {
        [ProtoMember(1)]
        public string TagName { get; set; }
        [ProtoMember(2)]
        public string TagValue { get; set; }
        [ProtoMember(3)]
        public string TagTypeName { get; set; }

        /// <summary>
        /// 默认类型转换
        /// </summary>
        /// <returns></returns>
        public dynamic ValueCast()
        {
            return Converter.Cast(TagValue, Type.GetType(TagTypeName));
        }
        /// <summary>
        /// 强制类型转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ValueCast<T>()
        {             
            return Converter.Cast<T>(TagValue);
        }
    }
}
