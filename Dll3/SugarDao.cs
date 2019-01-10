using EasySocket.vs13.Telegram.Easy;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll3
{
    public static class SugarDao
    {
        ///// <summary>
        ///// 唯一实例
        ///// </summary>
        //private static readonly Lazy<SqlSugarClient> instance = new Lazy<SqlSugarClient>(() => new SqlSugarClient(ConnectionString));

        ///// <summary>
        ///// 获取唯一实例
        ///// </summary>
        //public static SqlSugarClient Db
        //{
        //    get { return instance.Value; }
        //}
        ////ADO初始化设置
        //public SugarDao()
        //{
        //    instance.Value.Context.ToString();
        //}

        //public SqlSugarClient Db { get; set; }

        /////// <summary>
        /////// 唯一实例
        /////// </summary>
        //private static readonly Lazy<SugarDao> instance = new Lazy<SugarDao>(() => new SugarDao());

        ///// <summary>
        ///// 获取唯一实例
        ///// </summary>
        //public static SugarDao Instance
        //{
        //    get { return instance.Value; }
        //}

        //public SugarDao()
        //{
        //    Db = new SqlSugarClient(ConnectionString);
        //}

        ///// <summary>
        ///// 唯一实例
        ///// </summary>
        private static readonly Lazy<SqlSugarClient> instance = new Lazy<SqlSugarClient>(() => new SqlSugarClient(ConnectionString));

        /// <summary>
        /// 获取唯一实例
        /// </summary>
        public static SqlSugarClient Instance
        {
            get { return instance.Value; }
        }

        //ORACLE
        //public static string ConnectionString
        //{
        //    get
        //    {
        //        string reval = "server=.;uid=sa;pwd=sasa;database=SqlSugarTest";              
        //        return reval;
        //    }
        //}
        //public static SqlSugarClient GetInstance()
        //{
        //    var db = new SqlSugarClient(ConnectionString);
        //    db.IsEnableLogEvent = true;//Enable log events
        //    db.LogEventStarting = (sql, par) => { Console.WriteLine(sql + " " + par + "\r\n"); };            
        //    return db;
        //}

        //MySQL
        public static ConnectionConfig ConnectionString
        {
            get
            {
                return new ConnectionConfig { ConnectionString = Config.ConnectionString, DbType = SqlSugar.DbType.MySql, IsAutoCloseConnection = true };
            }
        }      
    }
}
