using Microsoft.Extensions.Logging;
using Vipps.net.Helpers;
using Vipps.Services;

namespace Vipps.net.Infrastructure
{
    internal sealed class EpaymentServiceClient : BaseServiceClient
    {
        internal EpaymentServiceClient(IVippsHttpClient vippsHttpClient) : base(vippsHttpClient)
        {
            Logger = VippsLogging.LoggerFactory.CreateLogger<EpaymentServiceClient>();
        }

        protected override async Task<Dictionary<string, string>?> GetHeaders(
            CancellationToken cancellationToken
        )
        {
            var authToken = await AccessTokenService.GetAccessToken(cancellationToken);
            var headers = new Dictionary<string, string>
            {
                {
                    Constants.HeaderNameAuthorization,
                    $"{Constants.AuthorizationSchemeNameBearer} {authToken.Token}"
                },
                { "Idempotency-Key", Guid.NewGuid().ToString() }
            };
            return headers;
        }
    }
}
