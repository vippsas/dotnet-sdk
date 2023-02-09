﻿namespace Vipps.Services
{
    internal sealed class AccessTokenLifetimeService
    {
        private readonly JwtSecurityTokenHandler _handler = new();

        public AccessTokenLifetimeService() { }

        public DateTimeOffset? GetValidTo(string token)
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
