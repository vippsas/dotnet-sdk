using Vipps.net.Infrastructure;

namespace Vipps.net.Tests
{
    [TestClass]
    public class VippsHttpClientTests
    {
        [TestMethod]
        public void Headers_Contain_SystemName()
        {
            DependencyInjection.ConfigureVipps(
                new Vipps.Infrastructure.VippsConfigurationOptions
                {
                    UseTestMode = false,
                    ClientId = "id",
                    ClientSecret = "secret",
                    MerchantSerialNumber = "42",
                    PluginName = "Pluginname",
                    PluginVersion = "1.0.0",
                    SubscriptionKey = "subkey"
                },
                null
            );

            var client = new VippsHttpClient();
            Assert.AreEqual(
                "Vipps.net",
                client.HttpClient.DefaultRequestHeaders.GetValues("Vipps-System-Name").First()
            );
            Assert.AreEqual(
                "Pluginname",
                client.HttpClient.DefaultRequestHeaders
                    .GetValues("Vipps-System-Plugin-Name")
                    .First()
            );
        }
    }
}
