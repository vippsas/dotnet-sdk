using System.Configuration;
using System.Reflection;
using Vipps.net.Infrastructure;

namespace Vipps.net.AspDemo
{
    public static class VippsApiConfig
    {
        private static VippsApi _vippsApi = null;
        public static VippsApi VippsApi
        {
            get { return _vippsApi; }
        }

        public static void Configure()
        {
            var configurationOptions = new VippsConfigurationOptions
            {
                ClientId = ConfigurationManager.AppSettings["ClientId"],
                ClientSecret = ConfigurationManager.AppSettings["ClientSecret"],
                MerchantSerialNumber = ConfigurationManager.AppSettings["MerchantSerialNumber"],
                SubscriptionKey = ConfigurationManager.AppSettings["SubscriptionKey"],
                UseTestMode = bool.Parse(ConfigurationManager.AppSettings["UseTestMode"]),
                PluginName = Assembly.GetExecutingAssembly().GetName().Name,
                PluginVersion =
                    Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0"
            };

            _vippsApi = new VippsApi(configurationOptions);
        }
    }
}
