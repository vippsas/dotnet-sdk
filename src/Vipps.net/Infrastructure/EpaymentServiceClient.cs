using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Vipps.net.Helpers;
using Vipps.net.Services;

namespace Vipps.net.Infrastructure
{
    internal sealed class EpaymentServiceClient : BaseServiceClient
    {
        private readonly VippsConfigurationOptions _vippsConfigurationOptions;
        private readonly VippsAccessTokenService _accessTokenService;

        internal EpaymentServiceClient(
            VippsConfigurationOptions vippsConfigurationOptions,
            IVippsHttpClient vippsHttpClient,
            VippsAccessTokenService accessTokenService,
            ILoggerFactory loggerFactory
        )
            : base(vippsHttpClient, loggerFactory)
        {
            _vippsConfigurationOptions = vippsConfigurationOptions;
            _accessTokenService = accessTokenService;
        }

        protected override async Task<Dictionary<string, string>> GetHeaders(
            CancellationToken cancellationToken
        )
        {
            var authToken = await _accessTokenService.GetAccessToken(cancellationToken);
            var headers = new Dictionary<string, string>
            {
                {
                    Constants.HeaderNameAuthorization,
                    $"{Constants.AuthorizationSchemeNameBearer} {authToken.Token}"
                },
                { "Idempotency-Key", Guid.NewGuid().ToString() },
                { Constants.SubscriptionKey, _vippsConfigurationOptions.SubscriptionKey },
            };
            return headers;
        }
    }
}
