using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MySystem.Service.Contract;
using MySystem.BL.Contract;
using MySystem.BL.Rules;
using System.Configuration;
using MySystem.Service.Configuration;

namespace MySystem.Service.Main
{
    //Заданёт начальные параметры при запуске хоста
    public class Startup : IStartup
    {
        //Конфигурация служб для промежуточного ПО и установка пользователя по заданому логину на сервис
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();

            string constringname = ConfigurationManager.ConnectionStrings["UsersDBCon"].ConnectionString;
            string tableUsername = ConfigurationManager.AppSettings["UserTable"];
            string tableAccountname = ConfigurationManager.AppSettings["AccountTable"];
            string tableNotename = ConfigurationManager.AppSettings["NoteTable"];

            try
            {
                if(constringname.Length > 0 && tableUsername.Length > 0 && tableAccountname.Length > 0 && tableNotename.Length > 0)
                {
                    services.AddSingleton<IValidationRuleFactory>(new ValidationRuleFactory());
                    services.AddSingleton<HubController>();
                }
                else if(constringname.Length == 0)
                {
                    throw new Exception("There is no connection string!");
                }
                else if (tableUsername.Length == 0 || tableAccountname.Length == 0 || tableNotename.Length == 0)
                {
                    throw new Exception("There is no table name!");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Установка и настройка маршрута при добавлении функционала SignalR в приложение
        public void Configure(IApplicationBuilder app)
        {
            app.UseSignalR(routes =>
            {
                routes.MapHub<CurHub>("/" + ServiceSettings.HubName);
            });
        }
    }
}
//public void ConfigureServices(IServiceCollection services)
//{
//    var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
//    var pathToContentRoot = Path.GetDirectoryName(pathToExe);

//    //https://stackoverflow.com/questions/42789450/iis-express-asp-net-core-invalid-uri-the-hostname-could-not-be-parsed
//    //  services.AddCors();
//    //ILog log = log4net.LogManager.GetLogger(typeof(Logger<>));
//    //var logRepository = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

//    //XmlConfigurator.Configure(logRepository, new FileInfo(Path.Combine(pathToContentRoot, "Configuration/log4net.config")));

//    services.AddSignalR(hubOptions =>
//    {
//        hubOptions.EnableDetailedErrors = true;
//        hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(1);
//    });

//    //string connectionString = ConfigurationManager.ConnectionStrings["Notes"].ConnectionString;
//    //string connectionString = ConnectionStringReader.GetConnectionString(databaseName: "Notes", xmlFilePath: Path.Combine(pathToContentRoot, "Configuration/connectionStrings.config"));

//    //IUnitOfWorkFactory unitOfWorkFactory = new RemoteNotes.DAL.MySql.UnitOfWorkFactory(connectionString, false);
//    //IManagerFactory managerFactory = new ManagerFactory(unitOfWorkFactory);
//    IManagerFactory managerFactory = new ManagerFactory();

//    //services.AddSingleton<ILog>(log);
//    services.AddSingleton<IManagerFactory>(managerFactory);
//    services.AddSingleton<HubEnvironment>();
//}