using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Vipps.net.Infrastructure
{
    public class VippsHttpClient : IVippsHttpClient
    {
        private HttpClient _httpClient;
        private readonly TimeSpan DefaultTimeOut = TimeSpan.FromSeconds(100);

        public VippsHttpClient() { }

        public VippsHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        internal HttpClient HttpClient
        {
            get
            {
                if (_httpClient == null)
                {
                    _httpClient = CreateDefaultHttpClient();
                }

                return _httpClient;
            }
        }

        public async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            SetupHeaders(request.Headers);
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
                BaseAddress = new Uri($"{VippsConfiguration.BaseUrl}")
            };

            return httpClient;
        }

        private static void SetupHeaders(System.Net.Http.Headers.HttpRequestHeaders headers)
        {
            AddOrUpdateHeader(
                headers,
                "Ocp-Apim-Subscription-Key",
                VippsConfiguration.SubscriptionKey
            );
            AddOrUpdateHeader(
                headers,
                "Merchant-Serial-Number",
                VippsConfiguration.MerchantSerialNumber
            );
            AddOrUpdateHeader(headers, "Vipps-System-Name", ThisAssembly.AssemblyName);
            AddOrUpdateHeader(
                headers,
                "Vipps-System-Version",
                ThisAssembly.AssemblyInformationalVersion
            );
            AddOrUpdateHeader(headers, "Vipps-System-Plugin-Name", VippsConfiguration.PluginName);
            AddOrUpdateHeader(
                headers,
                "Vipps-System-Plugin-Version",
                VippsConfiguration.PluginVersion
            );
        }

        private static void AddOrUpdateHeader(
            System.Net.Http.Headers.HttpRequestHeaders headers,
            string key,
            string value
        )
        {
            if (headers.Contains(key))
            {
                headers.Remove(key);
            }

            headers.Add(key, value);
        }
    }
}
