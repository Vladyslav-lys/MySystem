using System;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using MySystem.Service.Main;
using MySystem.Service.Configuration;

namespace MySystem.Service.Console
{
    class Program
    {
        //Запуск сервера
        public static void Main(string[] args)
        {
            string pathProccessFileName = Process.GetCurrentProcess().MainModule.FileName;
            string pathRootDirectory = Path.GetDirectoryName(pathProccessFileName);

            WebHost.CreateDefaultBuilder(args).UseContentRoot(pathRootDirectory).UseStartup<Startup>().UseUrls(ServiceSettings.ServiceUrl).Build().Run();
        }
    }
}
