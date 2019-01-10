using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.Core.Internal
{
    class ProtoBuffSerializer : ISerializer
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
            MemoryStream ms = new MemoryStream(bytes);
            return Serializer.Deserialize(type, ms);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <returns></returns>
        public T Deserialize<T>(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            return Serializer.Deserialize<T>(ms);

        }
    }
}
