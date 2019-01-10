using EasySocket.vs13.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasySocket.vs13
{
    /// <summary>
    /// 可指定并绑定会话的唯一ID类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISession<T>:ISession
    {
        /// <summary>
        /// 会话对象指针(唯一ID)
        /// </summary>
        T ConnId { get; }   
    }

    public interface ISession
    {
        /// <summary>
        /// 为会话设置额外的信息
        /// </summary>
        ISessionExtra Extra { get; }

        /// <summary>
        /// 获取会话的包装对象
        /// 该对象一般为会话对协议操作的包装
        /// </summary>
        IWrapper Wrapper { get; }

        /// <summary>
        /// 待处理的数据长度
        /// 可用来判断长度是否满足解析要求
        /// </summary>
        /// <returns></returns>
        int RemainDataLength { get; }

        /// <summary>
        /// 获取接收到数据读取器
        /// </summary>      
        ISessionStreamReader StreamReader { get; }
        
        /// <summary>
        /// 会话是否已连接
        /// </summary>
        bool IsConnected { get; set; }
        /// <summary>
        /// 错误代码
        /// </summary>
        int errorCode { get; set; }

        /// <summary>
        /// 会话额外的信息
        /// </summary>

        ///// <summary>
        ///// 会话本地监听IP
        ///// </summary>
        //string LocalIP { get;}
        ///// <summary>
        ///// 会话监听端口
        ///// </summary>
        //ushort LocalPort { get; }
        ///// <summary>
        ///// 会话远程连接IP
        ///// </summary>
        //string RemoteIP { get; }
        ///// <summary>
        ///// 会话远程连接端口
        ///// </summary>
        //string RemotePort { get; }

        /// <summary>
        /// 设置会话的协议名和会话包装对象
        /// </summary>
        /// <param name="protocol">协议</param>
        /// <param name="wrapper">会话的包装对象</param>
        void SetProtocolWrapper(Protocol protocol, IWrapper wrapper);
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="bytes">数据字节流</param>
        /// <returns></returns>
        bool SendData(ArraySegment<byte> byteRange);
        /// <summary>
        /// 断开和远程端的连接
        /// </summary>
        void Disconnect();
    }
}
