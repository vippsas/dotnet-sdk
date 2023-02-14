using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Vipps.Models.Epayment.AccessToken;
using Vipps.Services;

namespace Vipps.net.Tests
{
    [TestClass]
    public class AccessTokenCacheServiceTests
    {
        [TestMethod]
        public void Can_Retrieve_Saved_Valid()
        {
            var key = Guid.NewGuid().ToString();
            var accessToken = GetToken(DateTime.Now.AddHours(-1), DateTime.Now.AddHours(1));
            AccessTokenCacheService.Add(key, accessToken);
            var res = AccessTokenCacheService.Get(key);
            Assert.AreEqual(accessToken, res);
        }

        [TestMethod]
        public void Can_Not_Retrieve_Saved_Expired()
        {
            var key = Guid.NewGuid().ToString();
            var accessToken = GetToken(DateTime.Now.AddHours(-2), DateTime.Now.AddHours(-1));
            AccessTokenCacheService.Add(key, accessToken);
            var res = AccessTokenCacheService.Get(key);
            Assert.IsNull(res);
        }

        [TestMethod]
        public void Can_Not_Retrieve_Saved_NotValidForLongEnough()
        {
            var key = Guid.NewGuid().ToString();
            var accessToken = GetToken(DateTime.Now.AddHours(-2), DateTime.Now.AddMinutes(1));
            AccessTokenCacheService.Add(key, accessToken);
            var res = AccessTokenCacheService.Get(key);
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
            var accessToken = new AccessToken(
                "Bearer",
                "3600",
                "3600",
                "99675777281",
                "0",
                Guid.Empty.ToString(),
                jwtString
            );
            return accessToken;
        }
    }
}
