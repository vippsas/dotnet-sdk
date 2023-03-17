using System.Reflection;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Vipps.net.Infrastructure;

namespace Vipps.net.IntegrationTests
{
    [TestClass]
    public class TestSetup
    {
        [AssemblyInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            // Called once before any MSTest test method has started (optional)
            var configbuilder = new ConfigurationBuilder();
            configbuilder.AddEnvironmentVariables(prefix: "vmp_net_sdk");
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
                ClientId = config.GetSection("CLIENT-ID").Value,
                ClientSecret = config.GetSection("CLIENT-SECRET").Value,
                MerchantSerialNumber = config.GetSection("MERCHANT-SERIAL-NUMBER").Value,
                SubscriptionKey = config.GetSection("SUBSCRIPTION-KEY").Value,
                UseTestMode = true,
                PluginName = Assembly.GetExecutingAssembly().GetName().Name,
                PluginVersion =
                    Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0"
            };

            // The following line configures vipps with custom settings
            VippsConfiguration.ConfigureVipps(vippsConfigurationOptions);
        }
    }
}
