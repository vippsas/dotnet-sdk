using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Vipps.net.Infrastructure;
using Vipps.net.Models.AccessToken;

namespace Vipps.net.Services
{
    public interface IVippsAccessTokenService
    {
        Task<AccessToken> GetAccessToken(CancellationToken cancellationToken = default);
    }

    internal sealed class VippsAccessTokenService : IVippsAccessTokenService
    {
        private readonly VippsConfigurationOptions _vippsConfigurationOptions;
        private readonly AccessTokenServiceClient _accessTokenServiceClient;
        private readonly AccessTokenCacheService _accessTokenCacheService;

        public VippsAccessTokenService(
            VippsConfigurationOptions vippsConfigurationOptions,
            AccessTokenServiceClient accessTokenServiceClient,
            AccessTokenCacheService accessTokenCacheService
        )
        {
            _vippsConfigurationOptions = vippsConfigurationOptions;
            _accessTokenServiceClient = accessTokenServiceClient;
            _accessTokenCacheService = accessTokenCacheService;
        }

        public async Task<AccessToken> GetAccessToken(CancellationToken cancellationToken = default)
        {
            var key =
                $"{_vippsConfigurationOptions.ClientId}{_vippsConfigurationOptions.ClientSecret}";
            var cachedToken = _accessTokenCacheService.Get(key);
            if (cachedToken != null)
            {
                return cachedToken;
            }

            var accessToken = await _accessTokenServiceClient.ExecuteRequest<AccessToken>(
                "/accesstoken/get",
                HttpMethod.Post,
                cancellationToken
            );
            _accessTokenCacheService.Add(key, accessToken);
            return accessToken;
        }
    }
}
