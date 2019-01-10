using EasySocket.vs13.Networking;
using EasySocket.vs13.Stream;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13
{
    /// <summary>
    /// Tcp会话抽象类
    /// </summary>
    public abstract class TcpSessionBase<T> :TcpSessionBase, ISession<T>, IDisposable
    {
        /// <summary>
        /// 会话对象指针或唯一ID
        /// </summary>
        public T ConnId { get; private set; }
        /// <summary>
        /// 处理和分析收到的数据的委托
        /// </summary>
        public Func<TcpSessionBase<T>, Task> ReceiveAsyncHandler;
        /// <summary>
        /// 发送数据的委托  
        /// </summary>
        public Func<T, ArraySegment<byte>, bool> SendBufferHandler;
        /// <summary>
        /// 发送数据的委托  
        /// </summary>
        public Func<T, byte[], bool> SendBytesHandler;
        /// <summary>
        /// 会话关闭时的委托
        /// </summary>
        public Action<T> CloseHandler;
        /// <summary>
        /// 会话断开时的委托
        /// </summary>
        public Action<T> DisconnectHandler;

        /// <summary>
        /// 表示会话对象
        /// </summary>
        /// <param name="ConnId">会话对象指针</param>
        public TcpSessionBase(T connId) :base()
        {
            this.ConnId = connId;           
        }

        /// <summary>
        /// 使用此会话发送数据
        /// 使用方式有两种：
        /// 1、通过在外部调用类 实现SendBufferHandler委托
        /// 2、通过继承TcpSessionBase，并重写SendData方法
        /// </summary>
        /// <param name="byteRange"></param>
        /// <returns></returns>
        public override bool SendData(ArraySegment<byte> byteRange)
        {
            return SendBufferHandler(ConnId, byteRange);
        }

        /// <summary>
        /// 使用此会话发送数据
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public override bool SendData(byte[] bytes)
        {
            return SendBytesHandler(ConnId, bytes);
        }

        /// <summary>
        /// 接收数据
        /// 调用接收数据后委托
        /// </summary>
        /// <param name="bytes">接收的数据</param>
        /// <returns></returns>
        public override TcpSessionBase ReceiveData(byte[] bytes)
        {            
            this.StreamReader.WriteBytes(bytes);
            this.ReceiveAsyncHandler(this);
            return this;
        }

        /// <summary>
        /// 关闭会话的发送与接收
        /// 断开和远程端的连接
        /// </summary>
        public override void Disconnect()
        {
            this.DisconnectHandler(ConnId);
        }

        #region IDisposable
        /// <summary>
        /// 析构函数
        /// </summary>
        ~TcpSessionBase()
        {
            this.Dispose(false);
        }
        /// <summary>
        /// 释放资源
        ///参数为true表示释放所有资源，只能由使用者调用
        //参数为false表示释放非托管资源，只能由垃圾回收器自动调用
        //如果子类有自己的非托管资源，可以重载这个函数，添加自己的非托管资源的释放
        //但是要记住，重载此函数必须保证调用基类的版本，以保证基类的资源正常释放
        /// </summary>
        /// <param name="disposing">是否也释放托管资源</param>
        protected override void Dispose(bool disposing)
        {
            //释放非托管资源
            this.StreamReader.Stream.Dispose();
            // 释放托管资源(一般用不到，不需要手动释放，依赖垃圾回收器自动回收)
            if (disposing)
            {
                this.Extra = null;
                this.CloseHandler = null;
                this.DisconnectHandler = null;
                this.ReceiveAsyncHandler = null;
            }
            base.Dispose(disposing);
        }
        #endregion
    }

    /// <summary>
    /// Tcp会话抽象类
    /// </summary>
    public abstract class TcpSessionBase : ISession, IDisposable
    {
        /// <summary>
        /// 为会话设置额外的信息
        /// 此处以指针方式存储Key
        /// 回线信息
        /// </summary>
        public ISessionExtra Extra { get; set; }

        /// <summary>
        /// 获取会话的包装对象
        /// </summary>
        public IWrapper Wrapper { get; private set; }
        /// <summary>
        /// 待处理的数据长度
        /// 可用来判断长度是否满足解析要求
        /// </summary>
        /// <returns></returns>
        public int RemainDataLength { get { return this.StreamReader.Length; } }
        /// <summary>
        /// 获取接收到数据读取器
        /// </summary>      
        public ISessionStreamReader StreamReader { get; private set; }
        /// <summary>
        /// 会话是否已连接
        /// </summary>
        public bool IsConnected { get; set; }
        /// <summary>
        /// 错误代码
        /// </summary>
        public int errorCode { get; set; }

        /// <summary>
        /// 表示会话对象
        /// </summary>
        public TcpSessionBase()
        {
            this.StreamReader = new SessionStreamReader();
            //session创建时实例化一个唯一对应的Extra
            this.Extra = new SessionExtra(new DefaultTag());
        }

        /// <summary>
        /// 设置会话的协议名和会话包装对象
        /// </summary>
        /// <param name="protocol">协议</param>
        /// <param name="wrapper">会话的包装对象</param>
        public void SetProtocolWrapper(Protocol protocol, IWrapper wrapper)
        {
            this.Extra.Protocol = protocol;
            this.Wrapper = wrapper;
        }
        /// <summary>
        /// 使用此会话发送数据
        /// 使用方式有两种：
        /// 1、通过在外部调用类 实现SendBufferHandler委托
        /// 2、通过继承TcpSessionBase，并重写SendData方法
        /// </summary>
        /// <param name="byteRange"></param>
        /// <returns></returns>
        public virtual bool SendData(ArraySegment<byte> byteRange)
        {
            return true;
        }

        /// <summary>
        /// 使用此会话发送数据
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public virtual bool SendData(byte[] bytes)
        {
            return true;
        }

        /// <summary>
        /// 接收数据
        /// 调用接收数据后委托
        /// </summary>
        /// <param name="bytes">接收的数据</param>
        /// <returns></returns>
        public virtual TcpSessionBase ReceiveData(byte[] bytes)
        {
            this.StreamReader.WriteBytes(bytes);
            return this;
        }

        /// <summary>
        /// 关闭会话的发送与接收
        /// 断开和远程端的连接
        /// </summary>
        public virtual void Disconnect()
        {
        }

        #region IDisposable

        /// <summary>
        /// 获取是否已释放
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// 关闭和释放所有相关资源
        /// </summary>
        public void Dispose()
        {
            // 如果资源未释放 这个判断主要用了防止对象被多次释放
            if (this.IsDisposed == false)
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
            this.IsDisposed = true;
        }
        /// <summary>
        /// 析构函数
        /// </summary>
        ~TcpSessionBase()
        {
            this.Dispose(false);
        }
        /// <summary>
        /// 释放资源
        ///参数为true表示释放所有资源，只能由使用者调用
        //参数为false表示释放非托管资源，只能由垃圾回收器自动调用
        //如果子类有自己的非托管资源，可以重载这个函数，添加自己的非托管资源的释放
        //但是要记住，重载此函数必须保证调用基类的版本，以保证基类的资源正常释放
        /// </summary>
        /// <param name="disposing">是否也释放托管资源</param>
        protected virtual void Dispose(bool disposing)
        {
            //释放非托管资源
            this.StreamReader.Stream.Dispose();
            // 释放托管资源(一般用不到，不需要手动释放，依赖垃圾回收器自动回收)
            if (disposing)
            {
                this.Extra = null;
                this.StreamReader = null;
            }
        }
        #endregion
    }
}
