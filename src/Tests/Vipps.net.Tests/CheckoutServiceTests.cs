using Vipps.Infrastructure;
using Vipps.net.Infrastructure;
using Vipps.Services;

namespace Vipps.net.Tests
{
    [TestClass]
    public class CheckoutServiceTests
    {
        [TestMethod]
        public async Task UsingCheckoutService_IncorrectConfiguration_Throws_Exception()
        {
            var configOptions = new VippsConfigurationOptions
            {
                ClientId = "1",
                ClientSecret = "secret",
                MerchantSerialNumber = "12345",
                PluginName = "SDK plugin",
                PluginVersion = "1.0",
                SubscriptionKey = "42",
                UseTestMode = true
            };
            VippsConfiguration.ConfigureVipps(configOptions);

            var exceptionFound =
                await Assert.ThrowsExceptionAsync<Exceptions.VippsTechnicalException>(
                    () => CheckoutService.GetSessionInfo("1")
                );

            Assert.IsTrue(exceptionFound.Message.Contains("No such host is known"));
        }
    }
}
