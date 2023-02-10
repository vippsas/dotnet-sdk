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
            services
                .AddOptions<VippsConfigurationSection>()
                .Bind(configuration.GetSection(sectionName));

            VippsLogging.LoggerFactory = services
                .BuildServiceProvider()
                .GetRequiredService<ILoggerFactory>();
            // Maybe not required service?
        }
    }
}
