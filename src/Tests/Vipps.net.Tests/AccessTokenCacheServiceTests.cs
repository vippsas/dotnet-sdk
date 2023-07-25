using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Vipps.net.Models.AccessToken;
using Vipps.net.Services;

namespace Vipps.net.Tests
{
    [TestClass]
    public class AccessTokenCacheServiceTests
    {
        [TestMethod]
        public void Can_Retrieve_Saved_Valid()
        {
            var accessTokenCacheService = new AccessTokenCacheService();
            var key = Guid.NewGuid().ToString();
            var accessToken = GetToken(DateTime.Now.AddHours(-1), DateTime.Now.AddHours(1));
            accessTokenCacheService.Add(key, accessToken);
            var res = accessTokenCacheService.Get(key);
            Assert.AreEqual(accessToken, res);
        }

        [TestMethod]
        public void Can_Not_Retrieve_Saved_Expired()
        {
            AccessTokenCacheService accessTokenCacheService = new AccessTokenCacheService();
            var key = Guid.NewGuid().ToString();
            var accessToken = GetToken(DateTime.Now.AddHours(-2), DateTime.Now.AddHours(-1));
            accessTokenCacheService.Add(key, accessToken);
            var res = accessTokenCacheService.Get(key);
            Assert.IsNull(res);
        }

        [TestMethod]
        public void Can_Not_Retrieve_Saved_NotValidForLongEnough()
        {
            AccessTokenCacheService accessTokenCacheService = new AccessTokenCacheService();
            var key = Guid.NewGuid().ToString();
            var accessToken = GetToken(DateTime.Now.AddHours(-2), DateTime.Now.AddMinutes(1));
            accessTokenCacheService.Add(key, accessToken);
            var res = accessTokenCacheService.Get(key);
            Assert.IsNull(res);
        }

        private static AccessToken GetToken(DateTime? notBefore, DateTime? expiresAt)
        {
            var jwt = new JwtSecurityToken(
                new JwtHeader(),
                new JwtPayload(
                    "TestIssuer",
                    "TestAudience",
                    new List<Claim>(),
                    notBefore,
                    expiresAt,
                    notBefore
                )
            );
            var jwtString = new JwtSecurityTokenHandler().WriteToken(jwt);
            var accessToken = new AccessToken()
            {
                TokenType = "Bearer",
                ExpiresIn = "3600",
                ExtExpiresIn = "3600",
                ExpiresOn = "99675777281",
                NotBefore = "0",
                Resource = Guid.Empty.ToString(),
                Token = jwtString
            };
            return accessToken;
        }
    }
}
