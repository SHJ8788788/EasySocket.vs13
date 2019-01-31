using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllBase
{
    public class Config
    {
        //public static string ConnectionString = "server=.;uid=sa;pwd=sasa;database=SqlSugar4XTest";
        //public static string ConnectionString = "Data Source=lzgx2l2;User ID=info;Password = ceri;";      
        public static string ConnectionString
        {
            get
            {
                string reval = @"Data Source= (DESCRIPTION=
    (ADDRESS=
      (PROTOCOL=TCP)
      (HOST=127.0.0.1)
      (PORT=1521)
    )
    (CONNECT_DATA=
      (SERVER=dedicated)
      (SERVICE_NAME=ORCLFORTEST)
    )
  );User ID=INFO;Password = ceri;";
                return reval;
            }
        }
    }
}
