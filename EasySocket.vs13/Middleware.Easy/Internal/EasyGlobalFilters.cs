using EasySocket.vs13.Core;
using EasySocket.vs13.Core.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.Telegram.Easy.Internal
{
    /// <summary>
    /// Easy协议的全局过滤器提供者
    /// </summary>
    internal class EasyGlobalFilters : GlobalFiltersBase
    {
        /// <summary>
        /// 添加过滤器
        /// </summary>
        /// <param name="filter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public override void Add(IFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException();
            }

            var EasyFilter = filter as EasyFilterAttribute;
            if (EasyFilter == null)
            {
                throw new ArgumentException("过滤器的类型要继承于" + typeof(EasyFilterAttribute).Name);
            }
            base.Add(filter);
        }
    }
}
