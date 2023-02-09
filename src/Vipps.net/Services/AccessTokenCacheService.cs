﻿using System.Runtime.Caching;
using System.Security.Cryptography;
using System.Text;
using Vipps.Models.Epayment.AccessToken;

namespace Vipps.Services
{
    public static class AccessTokenCacheService
    {
        private static readonly AccessTokenLifetimeService _lifetimeService = new();
        private static readonly MemoryCache _memoryCache = new(nameof(AccessTokenCacheService));
        private static readonly TimeSpan _backoffTimespan = TimeSpan.FromMinutes(2);
        private const string KeyPrefix = "access-token-";

        public static void Add(string key, AccessToken token)
        {
            var tokenValidTo = _lifetimeService.GetValidTo(token.Token);
            var tokenValidToWithBackoff = tokenValidTo.HasValue ? tokenValidTo.Value.Subtract(_backoffTimespan) : (DateTimeOffset?)null;
            if (tokenValidToWithBackoff.HasValue && tokenValidToWithBackoff.Value > DateTimeOffset.Now)
            {
                _memoryCache.Set(
                    GetPrefixedHashedKey(key),
                    token,
                    tokenValidToWithBackoff.Value
                );
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
