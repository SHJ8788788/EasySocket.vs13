using EasySocket.vs13.Telegram.Easy;
using Log4Ex;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllBase
{
    public static class SugarDao
    {       
        /// <summary>
        /// 获取唯一实例
        /// </summary>
        public static SqlSugarClient Instance
        {
            get
            {
                var db = new SqlSugarClient(ConnectionConfig);
                //用来打印Sql方便你调式    
                db.Aop.OnLogExecuting = (sql, pars) =>
                {
                    string str = "\r\n"+ sql + "\r\n" +
                    db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value));
                    LogHelper.Info(str.Replace("\n", "\n                                                                       "));
                    //Console.WriteLine(sql + "\r\n" +
                    //db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                    //Console.WriteLine();
                };
                return db;
            }
        }

        //ORACLE
        public static ConnectionConfig ConnectionConfig
        {
            get
            {
                return new ConnectionConfig
                {
                    ConnectionString = Config.ConnectionString,
                    DbType = SqlSugar.DbType.Oracle,
                    IsAutoCloseConnection = true
                };
            }
        }      
    }
}
