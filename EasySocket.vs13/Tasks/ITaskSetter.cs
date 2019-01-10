using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.Tasks
{
    /// <summary>
    /// 定义任务行为接口
    /// </summary>
    public interface ITaskSetter
    {
        /// <summary>
        /// 获取任务的返回值类型
        /// </summary>
        Type ValueType { get; }

        /// <summary>
        /// 设置任务的行为结果
        /// </summary>     
        /// <param name="value">数据值</param>   
        /// <returns></returns>
        bool SetResult(object value);

        /// <summary>
        /// 设置设置为异常
        /// </summary>
        /// <param name="ex">异常</param>
        /// <returns></returns>
        bool SetException(Exception ex);
    }

    /// <summary>
    /// 定义任务行为接口
    /// </summary>
    /// <typeparam name="TResult">结果类型</typeparam>
    public interface ITaskSetter<TResult> : ITaskSetter
    {
        /// <summary>
        /// 设置任务的行为结果
        /// </summary>     
        /// <param name="value">数据值</param>   
        /// <returns></returns>
        bool SetResult(TResult value);
    }
}
