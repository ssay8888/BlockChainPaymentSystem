using BlockChainPaymentSystem.Constants.CultureCommon;
using BlockChainPaymentSystem.Net;
using BlockChainPaymentSystem.Net.Packet;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainPaymentSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var asd = Client.Instance.ConnectAsync();
            CultureStorage.ChargeTask();
            ServerPackets.RegisterPackets();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
            webBuilder.ConfigureKestrel(serverOptions =>
            {
                serverOptions.ListenAnyIP(5454);
            });
        });
    }
}
