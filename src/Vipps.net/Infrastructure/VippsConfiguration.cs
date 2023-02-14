using System;

namespace Vipps.net.Infrastructure
{
    public static class VippsConfiguration
    {
        private static string _clientId;
        public static string ClientId
        {
            get { return _clientId ?? throw new ArgumentNullException(nameof(ClientId)); }
            set
            {
                if (_clientId != null)
                {
                    throw new ArgumentException($"{nameof(ClientId)} is already set");
                }
                _clientId = value;
            }
        }
        private static string _clientSecret;
        public static string ClientSecret
        {
            get { return _clientSecret ?? throw new ArgumentNullException(nameof(ClientSecret)); }
            set
            {
                if (_clientSecret != null)
                {
                    throw new ArgumentException($"{nameof(ClientSecret)} is already set");
                }
                _clientSecret = value;
            }
        }
        private static string _subscriptionKey;
        public static string SubscriptionKey
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
        public static string MerchantSerialNumber
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
        public static bool TestMode
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
        public static IVippsHttpClient VippsHttpClient
        {
            internal get
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
