using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Vipps.net.Infrastructure;
using Vipps.net.Services;

namespace Vipps.net
{
    public interface IVippsApi
    {
        IVippsAccessTokenService AccessTokenService();
        IVippsEpaymentService EpaymentService();
        IVippsCheckoutService CheckoutService();
    }

    public class VippsApi : IVippsApi
    {
        private readonly VippsConfigurationOptions _vippsConfigurationOptions;
        private VippsHttpClient _vippsHttpClient;
        private ILoggerFactory _loggerFactory;
        private readonly VippsAccessTokenService _accessTokenService;
        private readonly IVippsEpaymentService _epaymentService;
        private readonly IVippsCheckoutService _checkoutService;

        public VippsApi(
            VippsConfigurationOptions configurationOptions,
            HttpClient httpClient = null,
            ILoggerFactory loggerFactory = null
        )
        {
            _loggerFactory = loggerFactory ?? NullLoggerFactory.Instance;
            this._vippsConfigurationOptions = configurationOptions;
            _vippsHttpClient = new VippsHttpClient(httpClient, configurationOptions);

            _accessTokenService = new VippsAccessTokenService(
                configurationOptions,
                new AccessTokenServiceClient(_vippsHttpClient, configurationOptions),
                new AccessTokenCacheService()
            );

            _epaymentService = new VippsEpaymentService(
                new EpaymentServiceClient(
                    _vippsHttpClient,
                    _vippsConfigurationOptions,
                    _accessTokenService
                )
            );

            _checkoutService = new VippsCheckoutService(
                new CheckoutServiceClient(_vippsHttpClient, _vippsConfigurationOptions)
            );
        }

        public IVippsAccessTokenService AccessTokenService()
        {
            return this._accessTokenService;
        }

        public IVippsEpaymentService EpaymentService()
        {
            return this._epaymentService;
        }

        public IVippsCheckoutService CheckoutService()
        {
            return this._checkoutService;
        }
    }
}
