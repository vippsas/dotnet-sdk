using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Vipps.net.Helpers;

namespace Vipps.net.Infrastructure
{
    internal sealed class CheckoutServiceClient : BaseServiceClient
    {
        private readonly VippsConfigurationOptions _vippsConfigurationOptions;

        internal CheckoutServiceClient(
            IVippsHttpClient vippsHttpClient,
            VippsConfigurationOptions vippsConfigurationOptions,
            ILoggerFactory loggerFactory
        )
            : base(vippsHttpClient, loggerFactory)
        {
            _vippsConfigurationOptions = vippsConfigurationOptions;
        }

        protected override async Task<Dictionary<string, string>> GetHeaders(
            CancellationToken cancellationToken
        )
        {
            return await Task.FromResult(
                new Dictionary<string, string>
                {
                    { Constants.HeaderNameClientId, _vippsConfigurationOptions.ClientId },
                    { Constants.HeaderNameClientSecret, _vippsConfigurationOptions.ClientSecret },
                    { Constants.SubscriptionKey, _vippsConfigurationOptions.SubscriptionKey },
                }
            );
        }
    }
}
