using Microsoft.Extensions.Configuration;
using Vipps.Infrastructure;

namespace Vipps.net.Infrastructure
{
    public static class DependencyInjection
    {
        public static void ConfigureVipps(IConfiguration configuration, string sectionName)
        {
            var settings = new VippsConfigurationSection();
            configuration.GetSection(sectionName).Bind(settings);
            // Update settings here
        }
    }
}
