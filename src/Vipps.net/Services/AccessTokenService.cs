using Vipps.Models.Epayment.AccessToken;
using Vipps.net.Helpers;
using Vipps.net.Infrastructure;

namespace Vipps.Services
{
    public static class AccessTokenService
    {
        public static async Task<AccessToken> GetAccessToken(CancellationToken? cancellationToken)
        {
            var key = $"{VippsConfiguration.ClientId}{VippsConfiguration.ClientSecret}";
            var cachedToken = AccessTokenCacheService.Get(key);
            if (cachedToken is not null)
            {
                return cachedToken;
            }

            var requestPath = $"{VippsConfiguration.BaseUrl}/accesstoken/get";
            var accessToken = await VippsConfiguration.VippsClient.ExecuteRequest<AccessToken>(
                requestPath,
                HttpMethod.Post,
                GetHeaders(),
                cancellationToken
            );
            AccessTokenCacheService.Add(key, accessToken);
            return accessToken;
        }

        private static Dictionary<string, string> GetHeaders()
        {
            return new Dictionary<string, string>
            {
                { Constants.HeaderNameClientId, VippsConfiguration.ClientId },
                { Constants.HeaderNameClientSecret, VippsConfiguration.ClientSecret }
            };
        }
    }
}
