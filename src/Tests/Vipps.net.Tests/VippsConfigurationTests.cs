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
    }
}
