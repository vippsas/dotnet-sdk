using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Vipps.net.Infrastructure;
using Vipps.net.Services;

namespace Vipps.net
{
    public interface IVippsApi
    {
        IVippsAccessTokenService AccessTokenService { get; }
        IVippsEpaymentService EpaymentService { get; }
        IVippsCheckoutService CheckoutService { get; }
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
                    configurationOptions,
                    _vippsHttpClient,
                    _loggerFactory
                ),
                new AccessTokenCacheService()
            );

            _epaymentService = new VippsEpaymentService(
                new EpaymentServiceClient(
                    _vippsConfigurationOptions,
                    _vippsHttpClient,
                    _accessTokenService,
                    _loggerFactory
                )
            );

            _checkoutService = new VippsCheckoutService(
                new CheckoutServiceClient(
                    _vippsConfigurationOptions,
                    _vippsHttpClient,
                    _loggerFactory
                )
            );
        }

        public IVippsAccessTokenService AccessTokenService
        {
            get { return _accessTokenService; }
        }

        public IVippsEpaymentService EpaymentService
        {
            get { return _epaymentService; }
        }

        public IVippsCheckoutService CheckoutService
        {
            get { return _checkoutService; }
        }
    }
}
