using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.Core
{
    /// <summary>
    /// 包括方法名、参数名
    /// 以此标识唯一方法
    /// </summary>
    public class ApiKey
    {
        /// <summary>
        /// 获取Api行为的Api名称
        /// </summary>
        public string ApiName { get; private set; }
        /// <summary>
        /// 获取Api类型参数
        /// </summary>
        public IList<string> ParameterTypes { get; private set; }
        public ApiKey(string apiName, ApiParameter[] parameters)
        {
            ApiName = apiName;
            ParameterTypes = parameters.Select(p => p.Type.Name).ToArray();
        }
        public ApiKey(string apiName, IList<string> parameterNames)
        {
            ApiName = apiName;
            ParameterTypes = parameterNames;
        }
        /// <summary>
        /// 比较是否和目标相等
        /// </summary>
        /// <param name="obj">目标</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            if (!(obj is ApiKey))
                return false;

            var apiKey = (ApiKey)obj;

            return ApiName == apiKey.ApiName 
                && GetParameterTypesAll(ParameterTypes) == GetParameterTypesAll(apiKey.ParameterTypes);
        }
        /// <summary>
        /// 获取哈希码
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (ApiName + "|" + GetParameterTypesAll(ParameterTypes)).GetHashCode();
        }

        public override string ToString()
        {
            return ApiName + "  par:(" + GetParameterTypesAll(ParameterTypes)+")";
        }
        /// <summary>
        /// 将List转换为以|分隔的字符串
        /// </summary>
        /// <returns></returns>
        private string GetParameterTypesAll(IList<string> parameterTypes)
        {
            return string.Join("|", parameterTypes);
        }
    }
}
