using EasySocket.vs13.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.Telegram.Easy
{
    public interface IEasyClient 
    {   
        /// <summary>
        /// 接收数据字节
        /// </summary>
        /// <param name="bytes"></param>
        void ReceiveData(byte[] bytes);
        /// <summary>
        /// 调用服务端实现的Api   
        /// 并返回结果数据任务
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="api">Api行为的api</param>
        /// <param name="parameters">参数</param>
        /// <exception cref="SocketException"></exception>        
        /// <exception cref="SerializerException"></exception>
        /// <returns>远程数据任务</returns>    
        ApiResult<T> InvokeApi<T>(string api, params object[] parameters);

        /// <summary>
        /// 调用服务端实现的Api  
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="api">Api行为的api</param>
        /// <param name="parameters">参数</param>
        /// <exception cref="SocketException"></exception>        
        /// <exception cref="SerializerException"></exception>
        /// <returns>远程数据任务</returns>    
        void InvokeVoidApi<T>(string api, params object[] parameters);
    }
}
