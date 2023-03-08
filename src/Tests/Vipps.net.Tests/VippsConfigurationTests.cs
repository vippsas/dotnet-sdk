using Vipps.net.Infrastructure;
using Vipps.net.Services;

namespace Vipps.net.Tests
{
    [TestClass]
    public class VippsConfigurationTests
    {
        [TestMethod]
        public async Task UsingVippsConfiguration_WithoutRunningConfigure_Throws_Exception()
        {
            await Assert.ThrowsExceptionAsync<Exceptions.VippsUserException>(
                () => AccessTokenService.GetAccessToken()
            );
        }

        [TestMethod]
        public void UsingVippsConfiguration_WithInvalid_Throws_Exception()
        {
            Assert.ThrowsException<Exceptions.VippsUserException>(
                () => VippsConfiguration.ConfigureVipps(new VippsConfigurationOptions())
            );
        }

        [TestMethod]
        public void jalla()
        {
            VippsConfiguration.ConfigureVipps(
                new VippsConfigurationOptions
                {
                    ClientId = "CI",
                    ClientSecret = "CS",
                    MerchantSerialNumber = "MSN",
                    PluginName = "PLN",
                    PluginVersion = "PLV",
                    SubscriptionKey = "SK",
                    UseTestMode = true
                }
            );
            var x = VippsHttpClient.GetHeaders();
            if (x != null)
            {
                Console.WriteLine(x);
            }
            Assert.IsNotNull(x);
        }
    }
}
