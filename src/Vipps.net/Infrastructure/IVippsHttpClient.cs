﻿using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Vipps.net.Infrastructure
{
    internal interface IVippsHttpClient
    {
        Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        );

        Uri BaseAddress { get; }
    }
}
