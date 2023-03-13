using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Vipps.net.Infrastructure;
using Vipps.net.Models.AccessToken;

namespace Vipps.net.Services
{
    public static class AccessTokenService
    {
        public static async Task<AccessToken> GetAccessToken(
            CancellationToken cancellationToken = default
        )
        {
            var key = $"{VippsConfiguration.ClientId}{VippsConfiguration.ClientSecret}";
            var cachedToken = AccessTokenCacheService.Get(key);
            if (cachedToken != null)
            {
                return cachedToken;
            }

            var accessToken =
                await VippsServices.AccessTokenServiceClient.ExecuteRequest<AccessToken>(
                    "/accesstoken/get",
                    HttpMethod.Post,
                    cancellationToken
                );
            AccessTokenCacheService.Add(key, accessToken);
            return accessToken;
        }
    }
}
