using Microsoft.Extensions.Logging;
using Vipps.net.Helpers;

namespace Vipps.net.Infrastructure
{
    internal sealed class CheckoutServiceClient : BaseServiceClient
    {
        internal CheckoutServiceClient(IVippsHttpClient vippsHttpClient)
            : base(vippsHttpClient)
        {
            Logger = VippsLogging.LoggerFactory.CreateLogger<CheckoutServiceClient>();
        }

        protected override async Task<Dictionary<string, string>?> GetHeaders(
            CancellationToken cancellationToken
        )
        {
            return await Task.FromResult(
                new Dictionary<string, string>
                {
                    { Constants.HeaderNameClientId, VippsConfiguration.ClientId },
                    { Constants.HeaderNameClientSecret, VippsConfiguration.ClientSecret }
                }
            );
        }
    }
}
