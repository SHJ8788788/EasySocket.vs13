using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasySocket.vs13
{
    public interface ITag
    {
        /// <summary>
        /// 获取或设置唯一标识符
        /// </summary>
        TagItem ID { get; set; }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        void Set(string key, object value);

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        TagItem Get(string key);

        /// <summary>
        /// 获取值
        /// 如果指定的键存在则返回键的值
        /// 如果指定的键不存在，则将添加并返回valueFactory的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="valueFactory">值</param>
        /// <returns></returns>
        TagItem Get(string key, Func<object> valueFactory);

        /// <summary>
        /// 删除键
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        bool Remove(string key);

        /// <summary>
        /// 判断key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool ContainsKey(string key);
    }
}
