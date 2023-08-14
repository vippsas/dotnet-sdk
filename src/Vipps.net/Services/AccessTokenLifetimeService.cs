using System;
using System.IdentityModel.Tokens.Jwt;

namespace Vipps.net.Services
{
    internal sealed class AccessTokenLifetimeService
    {
        private readonly JwtSecurityTokenHandler _handler = new JwtSecurityTokenHandler();

        internal AccessTokenLifetimeService() { }

        internal DateTimeOffset? GetValidTo(string token)
        {
            try
            {
                var jwt = _handler.ReadToken(token);
                return jwt.ValidTo;
            }
            catch
            {
                return null;
            }
        }
    }
}
