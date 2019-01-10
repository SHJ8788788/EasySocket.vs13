using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySocket.vs13;
using EasySocket.vs13.Telegram.Easy;
using EasySocket.vs13.Plugs;
using System.Reflection;
using System.IO;

namespace EasyServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //string assemblyFilePath = Assembly.GetExecutingAssembly().Location;
            //string assemblyDirPath = Path.GetDirectoryName(assemblyFilePath);
            //string configFilePath = assemblyDirPath + " \\log4net.xml";
            //log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(configFilePath));

            TcpListenerHP listener = new TcpListenerHP("0.0.0.0", 5555);
            listener.Use<EasyMiddleware>();
            listener.UsePlug<SessionIdlePlug>()
                    .IdleTime(TimeSpan.FromMinutes(60));            
            listener.UsePlug<EasySocketPlug>();
            listener.Start();
            string input = Console.ReadLine();
            if (input =="Q")
            {
                Environment.Exit(0);
            }
            if (input =="C")
            {
                Console.Clear();
            }
        }
    }
}
