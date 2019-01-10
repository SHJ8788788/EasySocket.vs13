using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
using System.IO;
using EasySocket.vs13.Core;

namespace EasySocket.vs13.Serializers
{
    public class ProtoBufSerializer : ISerializer
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <returns></returns>
        public byte[] Serialize(object model)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, model);
                byte[] bytes = new byte[ms.Length];
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(bytes, 0, bytes.Length);
                return bytes;
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <returns></returns>
        public object Deserialize(byte[] bytes, Type type)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Serializer.Deserialize(type, ms);
            }    
        }


        /// <summary>
        /// 反序列化
        /// </summary>
        /// <returns></returns>
        public T Deserialize<T>(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Serializer.Deserialize<T>(ms);
            }
        }
    }
}
