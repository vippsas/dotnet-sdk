﻿using Vipps.Models.Epayment.AccessToken;
using Vipps.net.Infrastructure;

namespace Vipps.Services
{
    public static class AccessTokenService
    {
        public static async Task<AccessToken> GetAccessToken(
            CancellationToken cancellationToken = default
        )
        {
            var key = $"{VippsConfiguration.ClientId}{VippsConfiguration.ClientSecret}";
            var cachedToken = AccessTokenCacheService.Get(key);
            if (cachedToken is not null)
            {
                return cachedToken;
            }

            var requestPath = $"{VippsConfiguration.BaseUrl}/accesstoken/get";
            var accessToken =
                await VippsConfiguration.AccessTokenServiceClient.ExecuteRequest<AccessToken>(
                    requestPath,
                    HttpMethod.Post,
                    cancellationToken
                );
            AccessTokenCacheService.Add(key, accessToken);
            return accessToken;
        }
    }
}
