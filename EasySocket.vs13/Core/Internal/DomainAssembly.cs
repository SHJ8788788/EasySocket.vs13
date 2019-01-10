using EasySocket.vs13.Telegram.Easy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasySocket.vs13.Core.Internal
{
    /// <summary>
    /// 当前程序域内的程序集
    /// </summary>
    internal static class DomainAssembly
    {
        /// <summary>
        /// 获取程序域内所有第三方程序集,在Api目录下
        /// 不包含当前程序集和全局程序集
        /// </summary>
        /// <returns></returns>
        public static List<Assembly> GetAssemblies()
        {
            //var current = Assembly.GetAssembly(typeof(DomainAssembly));
            //return AppDomain
            //    .CurrentDomain
            //    .GetAssemblies()
            //    .Where(item => item.GlobalAssemblyCache == false)
            //    .Where(item => item != current)
            //    .ToList();

            //return new List<Assembly> { Assembly.Load("Dll1"), Assembly.Load("Dll2") };
            //return new List<Assembly> { Assembly.Load("Dll3") };
            List<Assembly> assemblys = new List<Assembly>();
            string windowsPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Api");
            //string windowsPath = Application.StartupPath;
            foreach (string dllFile in Directory.GetFiles(windowsPath, "*.dll"))
            {
                string dllFileName = dllFile.Substring(dllFile.LastIndexOf("\\") + 1, (dllFile.LastIndexOf(".") - dllFile.LastIndexOf("\\") - 1)); //文件名
                //必须采用Assembly.Load才能使用全局已初始化的静态方法
                var assembly = Assembly.Load(dllFileName);                
                assemblys.Add(assembly);
            }
            return assemblys;            
        }
    }
}
