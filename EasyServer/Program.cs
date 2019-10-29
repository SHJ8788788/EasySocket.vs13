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
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Configuration;
using Log4Ex;
using System.Threading;

namespace EasyServer
{
    class Program
    {
        const int STD_INPUT_HANDLE = -10;
        const uint ENABLE_QUICK_EDIT_MODE = 0x0040;
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr GetStdHandle(int hConsoleHandle);
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint mode);
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint mode);


        static void Main(string[] args)
        {
            //获取Configuration对象
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //根据Key读取<add>元素的Value
            var Ip = config.AppSettings.Settings["EasyServerIp"].Value;
            var Port =Convert.ToUInt16(config.AppSettings.Settings["EasyServerPort"].Value);

            TcpListenerHP listener = new TcpListenerHP(Ip, Port);
            listener.Use<EasyMiddleware>();
            listener.UsePlug<SessionIdlePlug>()
                    .IdleTime(TimeSpan.FromMinutes(60));
            listener.UsePlug<EasySocketPlug>();
            listener.Start();
            //Console.CursorVisible = false;
            DisbleQuickEditMode();
            CleanLogFiles();

            Console.Title = "EasyServer-Gr";
            string input = Console.ReadLine();
            if (input == "Q")
            {
                Environment.Exit(0);
            }
            if (input == "C")
            {
                Console.Clear();
            }
            Console.ReadLine();
        }

        /// <summary>
        /// 关闭控制台应用程序的快速编辑模式
        /// </summary>
        public static void DisbleQuickEditMode()
        {
            IntPtr hStdin = GetStdHandle(STD_INPUT_HANDLE);
            uint mode;
            GetConsoleMode(hStdin, out mode);
            mode &= ~ENABLE_QUICK_EDIT_MODE;
            SetConsoleMode(hStdin, mode);

        }

        public static void CleanLogFiles()
        {           
            Task.Run(() =>
            {
                while (true)
                {
                    if (DateTime.Now.Hour == 0 && DateTime.Now.Minute == 0)  // //如果当前时间是0点0分
                    {
                        LogFileCleanupTask.CleanUp();                       
                    }
                    Thread.Sleep(60000);//1分钟间隔
                }
            });           
        }


    }
}
