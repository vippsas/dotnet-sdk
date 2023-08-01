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
        private readonly VippsHttpClient _vippsHttpClient;
        private readonly VippsAccessTokenService _accessTokenService;
        private readonly IVippsEpaymentService _epaymentService;
        private readonly IVippsCheckoutService _checkoutService;
        private readonly ILoggerFactory _loggerFactory;

        public VippsApi(
            VippsConfigurationOptions configurationOptions,
            HttpClient httpClient = null,
            ILoggerFactory loggerFactory = null
        )
        {
            _loggerFactory = loggerFactory ?? NullLoggerFactory.Instance;
            _vippsConfigurationOptions = configurationOptions;
            _vippsHttpClient = new VippsHttpClient(httpClient, configurationOptions);

            _accessTokenService = new VippsAccessTokenService(
                configurationOptions,
                new AccessTokenServiceClient(
                    _vippsHttpClient,
                    configurationOptions,
                    _loggerFactory
                ),
                new AccessTokenCacheService()
            );

            _epaymentService = new VippsEpaymentService(
                new EpaymentServiceClient(
                    _vippsHttpClient,
                    _vippsConfigurationOptions,
                    _accessTokenService,
                    _loggerFactory
                )
            );

            _checkoutService = new VippsCheckoutService(
                new CheckoutServiceClient(
                    _vippsHttpClient,
                    _vippsConfigurationOptions,
                    _loggerFactory
                )
            );
        }

        public IVippsAccessTokenService AccessTokenService()
        {
            return _accessTokenService;
        }

        public IVippsEpaymentService EpaymentService()
        {
            return _epaymentService;
        }

        public IVippsCheckoutService CheckoutService()
        {
            return _checkoutService;
        }
    }
}
