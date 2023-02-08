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
            var key = $"{VippsConfigurationHolder.VippsConfiguration.ClientId}{VippsConfigurationHolder.VippsConfiguration.ClientSecret}";
            var cachedToken = AccessTokenCacheService.Get(key);
            if (cachedToken is not null)
            {
                return cachedToken;
            }

            var requestPath = $"{VippsConfigurationHolder.VippsConfiguration.BaseUrl}/accesstoken/get";
            var accessToken = await VippsConfigurationHolder.VippsClient.ExecuteRequest<VoidType, AccessToken>(requestPath, HttpMethod.Post, null, GetHeaders(), null);
            AccessTokenCacheService.Add(key, accessToken);
            return accessToken;
        }

        private static Dictionary<string, string> GetHeaders()
        {
            return new Dictionary<string, string>
            {
                { Constants.HeaderNameClientId, VippsConfigurationHolder.VippsConfiguration.ClientId },
                { Constants.HeaderNameClientSecret, VippsConfigurationHolder.VippsConfiguration.ClientSecret }
            };
        }
    }
}
