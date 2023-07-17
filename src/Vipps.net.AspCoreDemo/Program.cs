using System;
using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Vipps.net.AspCore31Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(
                    (context, builder) =>
                    {
                        var config = builder.Build();
                        var host = config.GetValue<string>("keyvaultHost");

                        builder.AddAzureKeyVault(
                            new Uri($"https://{host}.vault.azure.net/"),
                            new DefaultAzureCredential()
                        );
                    }
                )
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
