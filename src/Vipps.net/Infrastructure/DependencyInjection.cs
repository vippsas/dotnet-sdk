using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Vipps.Infrastructure;

namespace Vipps.net.Infrastructure
{
    public static class DependencyInjection
    {
        public static void ConfigureVipps(
            this IServiceCollection services,
            IConfiguration configuration,
            string sectionName
        )
        {
            var settings = new VippsConfigurationOptions();
            configuration.GetSection(sectionName).Bind(settings);
            services.ConfigureVipps(settings);
        }

        public static void ConfigureVipps(
            this IServiceCollection services,
            VippsConfigurationOptions vippsConfigurationOptions
        )
        {
            VippsConfiguration.ClientId = vippsConfigurationOptions.ClientId;
            VippsConfiguration.ClientSecret = vippsConfigurationOptions.ClientSecret;
            VippsConfiguration.MerchantSerialNumber =
                vippsConfigurationOptions.MerchantSerialNumber;
            VippsConfiguration.SubscriptionKey = vippsConfigurationOptions.SubscriptionKey;
            VippsConfiguration.TestMode = vippsConfigurationOptions.UseTestMode;

            VippsLogging.LoggerFactory =
                services.BuildServiceProvider().GetService<ILoggerFactory>()
                ?? LoggerFactory.Create((lb) => { });
        }
    }
}
