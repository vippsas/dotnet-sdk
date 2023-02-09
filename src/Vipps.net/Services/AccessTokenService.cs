using Vipps.Models.Epayment.AccessToken;
using Vipps.net.Helpers;
using Vipps.net.Infrastructure;
using Vipps.net.Models.Base;

namespace Vipps.Services
{
    public static class AccessTokenService
    {
        public static async Task<AccessToken> GetAccessToken()
        {
            var key = $"{VippsConfiguration.ClientId}{VippsConfiguration.ClientSecret}";
            var cachedToken = AccessTokenCacheService.Get(key);
            if (cachedToken is not null)
            {
                return cachedToken;
            }

            var requestPath = $"{VippsConfiguration.BaseUrl}/accesstoken/get";
            var accessToken = await VippsConfiguration.VippsClient.ExecuteRequest<
                VoidType,
                AccessToken
            >(requestPath, HttpMethod.Post, null, GetHeaders(), null);
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
