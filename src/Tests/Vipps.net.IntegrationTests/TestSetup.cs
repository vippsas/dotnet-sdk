using System.Reflection;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Vipps.net.Infrastructure;

namespace Vipps.net.IntegrationTests
{
    public class TestSetup
    {
        public static IVippsApi CreateVippsAPI()
        {
            var configbuilder = new ConfigurationBuilder();
            configbuilder.AddEnvironmentVariables(prefix: "vmp_net_sdk_");
            configbuilder.AddJsonFile("appsettings.json");
            configbuilder.AddUserSecrets<TestSetup>();
            var keyvaultHost = configbuilder.Build().GetSection("keyvaultHost")?.Value;
            if (!string.IsNullOrEmpty(keyvaultHost))
            {
                // The following lines adds secrets from the key vault to the configuration.
                configbuilder.AddAzureKeyVault(
                    new Uri($"https://{keyvaultHost}.vault.azure.net/"),
                    new DefaultAzureCredential()
                );
            }

            var config = configbuilder.Build();
            var vippsConfigurationOptions = new VippsConfigurationOptions
            {
                ClientId = GetConfigValue(config, "CLIENT-ID"),
                ClientSecret = GetConfigValue(config, "CLIENT-SECRET"),
                MerchantSerialNumber = GetConfigValue(config, "MERCHANT-SERIAL-NUMBER"),
                SubscriptionKey = GetConfigValue(config, "SUBSCRIPTION-KEY"),
                UseTestMode = true,
                PluginName = Assembly.GetExecutingAssembly().GetName().Name,
                PluginVersion =
                    Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0"
            };

            // The following line configures vipps with custom settings
            return new VippsApi(vippsConfigurationOptions);
        }

        private static string GetConfigValue(IConfiguration config, string key)
        {
            return config.GetSection(key.Replace("-", "_"))?.Value
                ?? config.GetSection(key)?.Value
                ?? string.Empty;
        }
    }
}
