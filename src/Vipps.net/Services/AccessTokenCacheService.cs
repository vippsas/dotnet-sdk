using System.Runtime.Caching;
using System.Security.Cryptography;
using System.Text;
using Vipps.Models.Epayment.AccessToken;

namespace Vipps.net.Services
{
    internal static class AccessTokenCacheService
    {
        private static readonly AccessTokenLifetimeService _lifetimeService = new();
        private static MemoryCache _memoryCache = new(nameof(AccessTokenCacheService));
        private static readonly TimeSpan _backoffTimespan;
        private const string KeyPrefix = "access-token-";

        public static void Add(string key, AccessToken token)
        {
            var tokenValidTo = _lifetimeService.GetValidTo(token.Token);
            TimeSpan? remainingTimeToLive = tokenValidTo.HasValue && tokenValidTo.Value.Subtract(DateTimeOffset.Now) > _backoffTimespan ? tokenValidTo.Value.Subtract(DateTimeOffset.Now).Subtract(_backoffTimespan) : null;
            if (remainingTimeToLive.HasValue && remainingTimeToLive.Value.TotalSeconds > 1)
            {
                _memoryCache.Set(GetPrefixedHashedKey(key), token, DateTimeOffset.Now.Add(remainingTimeToLive.Value));
            }
        }

        public static AccessToken? Get(string key)
        {
            return _memoryCache.Get(GetPrefixedHashedKey(key)) as AccessToken;
        }

        private static string GetPrefixedHashedKey(string key)
        {
            return $"{KeyPrefix}{GetHashedKey(key)}";
        }

        private static string GetHashedKey(string key)
        {
            var hash = SHA256.HashData(Encoding.UTF8.GetBytes(key));
            return Convert.ToHexString(hash);
        }
    }
}
