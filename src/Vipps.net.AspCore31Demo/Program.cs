using System;
using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Vipps.Infrastructure;
using Vipps.net.Infrastructure;

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

                        config = builder.Build();
                        var vippsConfigurationOptions = new VippsConfigurationOptions
                        {
                            ClientId = config.GetValue<string>("CLIENT-ID")!,
                            ClientSecret = config.GetValue<string>("CLIENT-SECRET")!,
                            MerchantSerialNumber = config.GetValue<string>(
                                "MERCHANT-SERIAL-NUMBER"
                            )!,
                            SubscriptionKey = config.GetValue<string>("SUBSCRIPTION-KEY")!,
                            UseTestMode = true
                        };

                        // The following line configures vipps with custom settings
                        DependencyInjection.ConfigureVipps(vippsConfigurationOptions);
                    }
                )
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
