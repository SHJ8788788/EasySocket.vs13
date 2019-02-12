﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.Core.Internal
{
    /// <summary>
    /// 表示Api行为表
    /// </summary>
    internal class ApiActionTable
    {
        /// <summary>
        /// Api行为字典
        /// </summary>
        private readonly Dictionary<ApiKey, ApiAction> dictionary;

        /// <summary>
        /// Api行为表
        /// </summary>
        public ApiActionTable()
        {
            //this.dictionary = new Dictionary<string, ApiAction>(StringComparer.CurrentCultureIgnoreCase);
            this.dictionary = new Dictionary<ApiKey, ApiAction>();
        }

        /// <summary>
        /// Api行为列表
        /// </summary>
        /// <param name="apiActions">Api行为</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public ApiActionTable(IEnumerable<ApiAction> apiActions)
            : this()
        {
            this.AddRange(apiActions);
        }

        /// <summary>
        /// 添加Api行为
        /// </summary>
        /// <param name="apiAction">Api行为</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void Add(ApiAction apiAction)
        {
            if (apiAction == null)
            {
                throw new ArgumentNullException("apiAction");  
            }

            if (this.dictionary.ContainsKey(apiAction.Key))
            {
                var serviceName = apiAction.DeclaringService.ToString();                
                var apiName = apiAction.ApiName;
                var location = apiAction.DeclaringService.Assembly.Location;
                throw new ArgumentException(string.Format("Api行为[{0}/{1}]或其命令值已存在,无法映射路径{2}", serviceName, apiName, location));
            }
            this.dictionary.Add(apiAction.Key, apiAction);
        }

        /// <summary>
        /// 添加Api行为
        /// </summary>
        /// <param name="apiActions">Api行为</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void AddRange(IEnumerable<ApiAction> apiActions)
        {
            foreach (var action in apiActions)
            {
                this.Add(action);
            }
        }

        /// <summary>
        /// 获取Api行为
        /// 如果获取不到则返回null
        /// </summary>
        /// <param name="name">行为key</param>
        /// <returns></returns>
        public ApiAction TryGetAndClone(ApiKey key)
        {
            ApiAction apiAction;
            if (this.dictionary.TryGetValue(key, out apiAction))
            {                
                return ((ICloneable<ApiAction>)apiAction).CloneConstructor();               
            }
            return null;
        }
    }
}
