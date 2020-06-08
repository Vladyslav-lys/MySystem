using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using MySystem.Client.Main;
using System.Configuration;

namespace MySystem.Client.Console
{
    class Program
    {
        public static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                try
                {
                    string serviceurl = ConfigurationManager.AppSettings["ServiceUrl"];
                    string hubname = ConfigurationManager.AppSettings["Hub"];

                    SystemSettings systemSettings = new SystemSettings(hubname, serviceurl, null);
                    
                    systemSettings.Connection = new HubConnectionBuilder().WithUrl(systemSettings.FullPath).Build();

                    systemSettings.Connection.On<string>("Notify", (message) =>
                    {
                        System.Console.WriteLine("Notification: " + message);
                    });

                    await systemSettings.Connection.StartAsync();
                    await systemSettings.Connection.InvokeAsync("send", "Connected!");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Cannot connect to the server! Check out the server");
                }
            });

            System.Console.ReadLine();
        }
    }
}
