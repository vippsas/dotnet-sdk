using Microsoft.Extensions.Logging;
using Vipps.net.Exceptions;

namespace Vipps.net.Infrastructure
{
    public static class VippsConfiguration
    {
        public static void ConfigureVipps(VippsConfigurationOptions vippsConfigurationOptions)
        {
            ConfigureVipps(vippsConfigurationOptions, null, null);
        }

        public static void ConfigureVipps(
            VippsConfigurationOptions vippsConfigurationOptions,
            ILoggerFactory loggerFactory
        )
        {
            ConfigureVipps(vippsConfigurationOptions, loggerFactory, null);
        }

        public static void ConfigureVipps(
            VippsConfigurationOptions vippsConfigurationOptions,
            VippsHttpClient vippsHttpClient
        )
        {
            ConfigureVipps(vippsConfigurationOptions, null, vippsHttpClient);
        }

        public static void ConfigureVipps(
            VippsConfigurationOptions vippsConfigurationOptions,
            ILoggerFactory loggerFactory,
            VippsHttpClient vippsHttpClient
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
            set { _pluginName = AssertNotNullOrEmpty(value, nameof(PluginName)); }
        }

        private static string _pluginVersion = "1.0";
        internal static string PluginVersion
        {
            get { return _pluginVersion; }
            set { _pluginVersion = AssertNotNullOrEmpty(value, nameof(PluginVersion)); }
        }

        private static string _clientId;
        internal static string ClientId
        {
            get { return _clientId ?? throw CreateMissingConfigException(nameof(ClientId)); }
            set { _clientId = AssertNotNullOrEmpty(value, nameof(ClientId)); }
        }
        private static string _clientSecret;
        internal static string ClientSecret
        {
            get
            {
                return _clientSecret ?? throw CreateMissingConfigException(nameof(ClientSecret));
            }
            set { _clientSecret = AssertNotNullOrEmpty(value, nameof(ClientSecret)); }
        }
        private static string _subscriptionKey;
        internal static string SubscriptionKey
        {
            get
            {
                return _subscriptionKey
                    ?? throw CreateMissingConfigException(nameof(SubscriptionKey));
            }
            set { _subscriptionKey = AssertNotNullOrEmpty(value, nameof(SubscriptionKey)); }
        }
        private static string _merchantSerialNumber;
        internal static string MerchantSerialNumber
        {
            get
            {
                return _merchantSerialNumber
                    ?? throw CreateMissingConfigException(nameof(MerchantSerialNumber));
            }
            set
            {
                _merchantSerialNumber = AssertNotNullOrEmpty(value, nameof(MerchantSerialNumber));
            }
        }
        private static bool? _testMode;
        internal static bool TestMode
        {
            get { return _testMode ?? throw CreateMissingConfigException(nameof(TestMode)); }
            set { _testMode = value; }
        }

        internal static string BaseUrl =>
            TestMode == true ? "https://apitest.vipps.no" : "https://api.vipps.no";

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
            set { _vippsHttpClient = value; }
        }

        private static IVippsHttpClient CreateDefaultVippsHttpClient()
        {
            return new VippsHttpClient();
        }

        private static VippsUserException CreateMissingConfigException(string propertyName)
        {
            return new VippsUserException(
                $"VippsConfiguration incomplete - {propertyName} is missing. Have you run {nameof(VippsConfiguration.ConfigureVipps)}?"
            );
        }

        private static string AssertNotNullOrEmpty(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new VippsUserException(
                    $"VippsConfiguration incomplete - {propertyName} is null, empty or whitespace."
                );
            }

            return value;
        }
    }
}
