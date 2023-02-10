namespace Vipps.net.Infrastructure
{
    internal static class VippsServices
    {
        private static EpaymentServiceClient _epaymentServiceClient;
        internal static EpaymentServiceClient EpaymentServiceClient
        {
            get
            {
                if (_epaymentServiceClient == null)
                {
                    _epaymentServiceClient = new EpaymentServiceClient(
                        VippsConfiguration.VippsHttpClient
                    );
                }

                return _epaymentServiceClient;
            }
        }

        private static AccessTokenServiceClient _accessTokenServiceClient;
        internal static AccessTokenServiceClient AccessTokenServiceClient
        {
            get
            {
                if (_accessTokenServiceClient == null)
                {
                    _accessTokenServiceClient = new AccessTokenServiceClient(
                        VippsConfiguration.VippsHttpClient
                    );
                }

                return _accessTokenServiceClient;
            }
        }

        private static CheckoutServiceClient _checkoutServiceClient;
        internal static CheckoutServiceClient CheckoutServiceClient
        {
            get
            {
                if (_checkoutServiceClient == null)
                {
                    _checkoutServiceClient = new CheckoutServiceClient(
                        VippsConfiguration.VippsHttpClient
                    );
                }

                return _checkoutServiceClient;
            }
        }
    }
}
