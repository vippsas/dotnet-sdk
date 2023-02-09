using Microsoft.Extensions.Configuration;
using Vipps.Models;

namespace Vipps.net
{
    public static class DependencyInjection
    {
        public static void ConfigureVipps(IConfiguration configuration, string sectionName)
        {
            var settings = new VippsConfiguration();
            configuration.GetSection(sectionName).Bind(settings);
        }
    }
}
