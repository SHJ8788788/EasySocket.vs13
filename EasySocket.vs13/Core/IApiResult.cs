﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.Core
{
    /// <summary>
    /// 定义IApiResult接口
    /// </summary>
    public interface IApiResult
    {
        /// <summary>
        /// 返回Task对象
        /// </summary>
        /// <returns></returns>
        Task GetTask();
    }


    /// <summary>
    /// 定义IApiResult接口
    /// </summary>
    /// <typeparam name="TResult">结果类型</typeparam>
    public interface IApiResult<TResult>
    {
        /// <summary>
        /// 返回Task对象
        /// </summary>
        /// <returns></returns>
        Task<TResult> GetTask();
    }
}
