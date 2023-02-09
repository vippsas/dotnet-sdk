namespace Vipps.net.Infrastructure
{
    public static class VippsConfiguration
    {
        private static string? _clientId;
        public static string ClientId
        {
            get { return _clientId ?? throw new ArgumentNullException(nameof(ClientId)); }
            set
            {
                if (_clientId is not null)
                {
                    throw new ArgumentException($"{nameof(ClientId)} is already set");
                }
                _clientId = value;
            }
        }
        private static string? _clientSecret;
        public static string ClientSecret
        {
            get { return _clientSecret ?? throw new ArgumentNullException(nameof(ClientSecret)); }
            set
            {
                if (_clientSecret is not null)
                {
                    throw new ArgumentException($"{nameof(ClientSecret)} is already set");
                }
                _clientSecret = value;
            }
        }
        private static string? _subscriptionKey;
        public static string SubscriptionKey
        {
            get
            {
                return _subscriptionKey ?? throw new ArgumentNullException(nameof(SubscriptionKey));
            }
            set
            {
                if (_subscriptionKey is not null)
                {
                    throw new ArgumentException($"{nameof(SubscriptionKey)} is already set");
                }
                _subscriptionKey = value;
            }
        }
        private static string? _merchantSerialNumber;
        public static string MerchantSerialNumber
        {
            get
            {
                return _merchantSerialNumber
                    ?? throw new ArgumentNullException(nameof(MerchantSerialNumber));
            }
            set
            {
                if (_merchantSerialNumber is not null)
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
                if (_testMode is not null)
                {
                    throw new ArgumentException($"{nameof(TestMode)} is already set");
                }
                _testMode = value;
            }
        }

        internal static string BaseUrl =>
            TestMode == true ? "https://api-test.vipps.no" : "https://api.vipps.no";

        private static IVippsClient? _vippsClient;
        public static IVippsClient VippsClient
        {
            internal get
            {
                if (_vippsClient is null)
                {
                    _vippsClient = CreateDefaultVippsClient();
                }

                return _vippsClient;
            }
            set
            {
                if (_vippsClient is not null)
                {
                    throw new InvalidOperationException(
                        "Once created, VippsClient cannot be modified"
                    );
                }
                _vippsClient = value;
            }
        }

        private static IVippsClient CreateDefaultVippsClient()
        {
            return new VippsClient();
        }
    }
}
