using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Vipps.net.Helpers;

namespace Vipps.net.Infrastructure
{
    internal sealed class AccessTokenServiceClient : BaseServiceClient
    {
        private readonly VippsConfigurationOptions _vippsConfigurationOptions;

        internal AccessTokenServiceClient(
            IVippsHttpClient vippsHttpClient,
            VippsConfigurationOptions vippsConfigurationOptions
        )
            : base(vippsHttpClient)
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
                    { Constants.SubscriptionKey, _vippsConfigurationOptions.SubscriptionKey }
                }
            );
        }
    }
}
