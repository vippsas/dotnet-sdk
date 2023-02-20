using Vipps.Services;

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
    }
}
