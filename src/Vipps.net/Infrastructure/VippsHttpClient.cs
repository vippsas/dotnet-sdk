using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Vipps.net.Helpers;

namespace Vipps.net.Infrastructure
{
    public class VippsHttpClient : IVippsHttpClient
    {
        private HttpClient _httpClient;
        private readonly TimeSpan DefaultTimeOut = TimeSpan.FromSeconds(100);
        private readonly VippsConfigurationOptions _options;

        public VippsHttpClient(HttpClient httpClient, VippsConfigurationOptions options)
        {
            _httpClient = httpClient;
            _options = options;
        }

        public Uri BaseAddress
        {
            get { return HttpClient.BaseAddress; }
        }

        internal HttpClient HttpClient
        {
            get
            {
#pragma warning disable IDE0074 // Use compound assignment // Cannot, because of language level
                if (_httpClient == null)
                {
                    _httpClient = CreateDefaultHttpClient();
                }
#pragma warning restore IDE0074 // Use compound assignment

                return _httpClient;
            }
        }

        public async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            var headers = GetHeaders();
            foreach (var header in headers)
            {
                if (request.Headers.Contains(header.Key))
                {
                    request.Headers.Remove(header.Key);
                }

                request.Headers.Add(header.Key, header.Value);
            }

            var response = await HttpClient
                .SendAsync(request, cancellationToken)
                .ConfigureAwait(false);
            return response;
        }

        private HttpClient CreateDefaultHttpClient()
        {
            var httpClient = new HttpClient()
            {
                Timeout = DefaultTimeOut,
                BaseAddress = new Uri(UrlHelper.GetBaseUrl(_options.UseTestMode))
            };

            return httpClient;
        }

        private Dictionary<string, string> GetHeaders()
        {
            var assemblyName = typeof(VippsApi).Assembly.GetName();
            var assemblyVersion = assemblyName.Version?.ToString();
            return new Dictionary<string, string>
            {
                { "User-Agent", $"Vipps/DotNet SDK/{assemblyVersion}" },
                { "Vipps-System-Name", assemblyName.Name },
                { "Vipps-System-Version", assemblyVersion },
                { "Merchant-Serial-Number", _options.MerchantSerialNumber },
                {
                    "Vipps-System-Plugin-Name",
                    string.IsNullOrWhiteSpace(_options.PluginName) ? "acme-plugin" : _options.PluginName
                },
                {
                    "Vipps-System-Plugin-Version",
                    string.IsNullOrWhiteSpace(_options.PluginVersion) ? "0.0.1" : _options.PluginVersion
                }
            };
        }
    }
}
