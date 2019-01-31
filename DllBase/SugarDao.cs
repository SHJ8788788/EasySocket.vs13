using EasySocket.vs13.Telegram.Easy;
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
                return new SqlSugarClient(ConnectionConfig);
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
