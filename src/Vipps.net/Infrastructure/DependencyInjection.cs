using Microsoft.Extensions.Logging;
using Vipps.Infrastructure;

namespace Vipps.net.Infrastructure
{
    public static class DependencyInjection
    {
        public static void ConfigureVipps(
            VippsConfigurationOptions vippsConfigurationOptions,
            ILoggerFactory loggerFactory = null
        )
        {
            if (loggerFactory != null)
            {
                VippsLogging.LoggerFactory = loggerFactory;
            }

            VippsConfiguration.PluginName = vippsConfigurationOptions.PluginName;
            VippsConfiguration.PluginVersion = vippsConfigurationOptions.PluginVersion;
            VippsConfiguration.ClientId = vippsConfigurationOptions.ClientId;
            VippsConfiguration.ClientSecret = vippsConfigurationOptions.ClientSecret;
            VippsConfiguration.MerchantSerialNumber =
                vippsConfigurationOptions.MerchantSerialNumber;
            VippsConfiguration.SubscriptionKey = vippsConfigurationOptions.SubscriptionKey;
            VippsConfiguration.TestMode = vippsConfigurationOptions.UseTestMode;
        }
    }
}
