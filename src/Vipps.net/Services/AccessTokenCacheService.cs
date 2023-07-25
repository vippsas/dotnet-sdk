using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Vipps.net.Models.AccessToken;

namespace Vipps.net.Services
{
    public class AccessTokenCacheService
    {
        private readonly AccessTokenLifetimeService _lifetimeService;
        private readonly TimeSpan _backoffTimespan = TimeSpan.FromMinutes(2);
        private readonly ConcurrentDictionary<
            string,
            (AccessToken token, DateTimeOffset validTo)
        > _dictionary;
        private const string KeyPrefix = "access-token-";

        public AccessTokenCacheService()
        {
            _lifetimeService = new AccessTokenLifetimeService();
            _dictionary =
                new ConcurrentDictionary<string, (AccessToken token, DateTimeOffset validTo)>();
        }

        public void Add(string key, AccessToken token)
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
                _dictionary.AddOrUpdate(
                    GetPrefixedHashedKey(key),
                    (token, tokenValidToWithBackoff.Value),
                    (oldToken, oldValidTo) => (token, tokenValidToWithBackoff.Value)
                );
            }
        }

        public AccessToken Get(string key)
        {
            if (_dictionary.TryGetValue(GetPrefixedHashedKey(key), out var values))
            {
                if (values.validTo < DateTimeOffset.Now)
                {
                    _dictionary.TryRemove(key, out _);
                    return null;
                }

                return values.token;
            }

            return null;
        }

        private static string GetPrefixedHashedKey(string key)
        {
            return $"{KeyPrefix}{GetHashedKey(key)}";
        }

        private static string GetHashedKey(string key)
        {
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
