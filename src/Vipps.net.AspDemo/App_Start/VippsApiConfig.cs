using System.Configuration;
using Vipps.net.Infrastructure;

namespace Vipps.net.AspDemo
{
    public static class VippsApiConfig
    {
        public static void Configure()
        {
            VippsConfiguration.ClientId = ConfigurationManager.AppSettings["ClientId"];
            VippsConfiguration.ClientSecret = ConfigurationManager.AppSettings["ClientSecret"];
            VippsConfiguration.MerchantSerialNumber = ConfigurationManager.AppSettings[
                "MerchantSerialNumber"
            ];
            VippsConfiguration.SubscriptionKey = ConfigurationManager.AppSettings[
                "SubscriptionKey"
            ];
            VippsConfiguration.TestMode = bool.Parse(
                ConfigurationManager.AppSettings["UseTestMode"]
            );
        }
    }
}
