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

        public static IVippsApi Create(
            VippsConfigurationOptions options,
            ILoggerFactory loggerFactory = null
        )
        {
            return new VippsApi(options, loggerFactory);
        }

        private VippsApi(
            VippsConfigurationOptions configurationOptions,
            ILoggerFactory loggerFactory = null
        )
        {
            _loggerFactory = loggerFactory ?? NullLoggerFactory.Instance;
            this._vippsConfigurationOptions = configurationOptions;
            _vippsHttpClient = new VippsHttpClient(new HttpClient(), configurationOptions);

            _accessTokenService = new VippsAccessTokenService(
                configurationOptions,
                new AccessTokenServiceClient(_vippsHttpClient, configurationOptions),
                new AccessTokenCacheService()
            );
        }

        public IVippsAccessTokenService AccessTokenService()
        {
            return this._accessTokenService;
        }

        public IVippsEpaymentService EpaymentService()
        {
            return new VippsEpaymentService(
                new EpaymentServiceClient(
                    _vippsHttpClient,
                    _vippsConfigurationOptions,
                    _accessTokenService
                )
            );
        }

        public IVippsCheckoutService CheckoutService()
        {
            return new VippsCheckoutService(
                new CheckoutServiceClient(_vippsHttpClient, _vippsConfigurationOptions)
            );
        }
    }
}
