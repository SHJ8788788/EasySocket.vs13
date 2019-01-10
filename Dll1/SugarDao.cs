using OracleSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll1
{
    class SugarDao
    {
        private SugarDao()
        {
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
        public static string ConnectionString
        {
            get
            {
                string reval = "server=.;uid=sa;pwd=sasa;database=SqlSugarTest";
                return reval;
            }
        }
        public static SqlSugarClient GetInstance()
        {
            var db = new SqlSugarClient(ConnectionString);
            db.IsEnableLogEvent = true;//Enable log events
            db.LogEventStarting = (sql, par) => { Console.WriteLine(sql + " " + par + "\r\n"); };
            return db;
        }
    }
}
