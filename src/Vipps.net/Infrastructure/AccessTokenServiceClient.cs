﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Vipps.net.Helpers;

namespace Vipps.net.Infrastructure
{
    internal sealed class AccessTokenServiceClient : BaseServiceClient
    {
        internal AccessTokenServiceClient(IVippsHttpClient vippsHttpClient)
            : base(vippsHttpClient) { }

        protected override async Task<Dictionary<string, string>> GetHeaders(
            CancellationToken cancellationToken
        )
        {
            return await Task.FromResult(
                new Dictionary<string, string>
                {
                    { Constants.HeaderNameClientId, VippsConfiguration.ClientId },
                    { Constants.HeaderNameClientSecret, VippsConfiguration.ClientSecret }
                }
            );
        }
    }
}
