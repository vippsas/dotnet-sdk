using Vipps.Infrastructure;

namespace Vipps.net.Infrastructure
{
    public static class DependencyInjection
    {
        public static void ConfigureVipps(VippsConfigurationOptions vippsConfigurationOptions)
        {
            VippsConfiguration.ClientId = vippsConfigurationOptions.ClientId;
            VippsConfiguration.ClientSecret = vippsConfigurationOptions.ClientSecret;
            VippsConfiguration.MerchantSerialNumber =
                vippsConfigurationOptions.MerchantSerialNumber;
            VippsConfiguration.SubscriptionKey = vippsConfigurationOptions.SubscriptionKey;
            VippsConfiguration.TestMode = vippsConfigurationOptions.UseTestMode;
        }
    }
}
