using System;
using Microsoft.Extensions.Logging;
using Vipps.Infrastructure;

namespace Vipps.net.Infrastructure
{
    public static class VippsConfiguration
    {
        public static void ConfigureVipps(
            VippsConfigurationOptions vippsConfigurationOptions,
            ILoggerFactory loggerFactory = null,
            VippsHttpClient vippsHttpClient = null
        )
        {
            if (loggerFactory != null)
            {
                VippsLogging.LoggerFactory = loggerFactory;
            }

            if (vippsHttpClient != null)
            {
                VippsHttpClient = vippsHttpClient;
            }

            PluginName = vippsConfigurationOptions.PluginName;
            PluginVersion = vippsConfigurationOptions.PluginVersion;
            ClientId = vippsConfigurationOptions.ClientId;
            ClientSecret = vippsConfigurationOptions.ClientSecret;
            MerchantSerialNumber = vippsConfigurationOptions.MerchantSerialNumber;
            SubscriptionKey = vippsConfigurationOptions.SubscriptionKey;
            TestMode = vippsConfigurationOptions.UseTestMode;
        }

        private static string _pluginName = "checkout-sandbox";
        internal static string PluginName
        {
            get { return _pluginName; }
            set { _pluginName = value; }
        }

        private static string _pluginVersion = "1.0";
        internal static string PluginVersion
        {
            get { return _pluginVersion; }
            set { _pluginVersion = value; }
        }

        private static string _clientId;
        internal static string ClientId
        {
            get { return _clientId ?? throw new ArgumentNullException(nameof(ClientId)); }
            set { _clientId = value; }
        }
        private static string _clientSecret;
        internal static string ClientSecret
        {
            get { return _clientSecret ?? throw new ArgumentNullException(nameof(ClientSecret)); }
            set { _clientSecret = value; }
        }
        private static string _subscriptionKey;
        internal static string SubscriptionKey
        {
            get
            {
                return _subscriptionKey ?? throw new ArgumentNullException(nameof(SubscriptionKey));
            }
            set
            {
                if (_subscriptionKey != null)
                {
                    throw new ArgumentException($"{nameof(SubscriptionKey)} is already set");
                }
                _subscriptionKey = value;
            }
        }
        private static string _merchantSerialNumber;
        internal static string MerchantSerialNumber
        {
            get
            {
                return _merchantSerialNumber
                    ?? throw new ArgumentNullException(nameof(MerchantSerialNumber));
            }
            set
            {
                if (_merchantSerialNumber != null)
                {
                    throw new ArgumentException($"{nameof(MerchantSerialNumber)} is already set");
                }
                _merchantSerialNumber = value;
            }
        }
        private static bool? _testMode;
        internal static bool TestMode
        {
            get { return _testMode ?? throw new ArgumentNullException(nameof(TestMode)); }
            set
            {
                if (_testMode != null)
                {
                    throw new ArgumentException($"{nameof(TestMode)} is already set");
                }
                _testMode = value;
            }
        }

        internal static string BaseUrl =>
            TestMode == true ? "https://api-test.vipps.no" : "https://api.vipps.no";

        private static IVippsHttpClient _vippsHttpClient;
        internal static IVippsHttpClient VippsHttpClient
        {
            get
            {
                if (_vippsHttpClient is null)
                {
                    _vippsHttpClient = CreateDefaultVippsHttpClient();
                }

                return _vippsHttpClient;
            }
            set
            {
                if (_vippsHttpClient != null)
                {
                    throw new InvalidOperationException(
                        "Once created, VippsHttpClient cannot be modified"
                    );
                }
                _vippsHttpClient = value;
            }
        }

        private static IVippsHttpClient CreateDefaultVippsHttpClient()
        {
            return new VippsHttpClient();
        }
    }
}
