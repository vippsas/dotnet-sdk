using System;
using System.Linq;
using System.Runtime.Caching;
using System.Security.Cryptography;
using System.Text;
using Vipps.Models.Epayment.AccessToken;

namespace Vipps.Services
{
    public static class AccessTokenCacheService
    {
#pragma warning disable IDE0090 // Use 'new(...)'
        private static readonly AccessTokenLifetimeService _lifetimeService =
            new AccessTokenLifetimeService();
        private static readonly MemoryCache _memoryCache = new MemoryCache(
            nameof(AccessTokenCacheService)
        );
#pragma warning restore IDE0090 // Use 'new(...)'
        private static readonly TimeSpan _backoffTimespan = TimeSpan.FromMinutes(2);
        private const string KeyPrefix = "access-token-";

        public static void Add(string key, AccessToken token)
        {
            var tokenValidTo = _lifetimeService.GetValidTo(token.Token);
            var tokenValidToWithBackoff = tokenValidTo.HasValue
                ? tokenValidTo.Value.Subtract(_backoffTimespan)
                : (DateTimeOffset?)null;
            if (
                tokenValidToWithBackoff.HasValue
                && tokenValidToWithBackoff.Value > DateTimeOffset.Now
            )
            {
                _memoryCache.Set(GetPrefixedHashedKey(key), token, tokenValidToWithBackoff.Value);
            }
        }

        public static AccessToken Get(string key)
        {
            return _memoryCache.Get(GetPrefixedHashedKey(key)) as AccessToken;
        }

        private static string GetPrefixedHashedKey(string key)
        {
            return $"{KeyPrefix}{GetHashedKey(key)}";
        }

        private static string GetHashedKey(string key)
        {
            // Not fully compatible with all target frameworks
            //var hash = SHA256.HashData(Encoding.UTF8.GetBytes(key));
            //return Convert.ToHexString(hash);

#pragma warning disable CA1850 // Prefer static 'System.Security.Cryptography.SHA256.HashData' method over 'ComputeHash'
            byte[] hash = null;
            using (var sha256 = SHA256.Create())
            {
                hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
            }
#pragma warning restore CA1850 // Prefer static 'System.Security.Cryptography.SHA256.HashData' method over 'ComputeHash'

            return string.Join(string.Empty, hash.Select(x => x.ToString("X2")));
        }
    }
}
