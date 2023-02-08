namespace Vipps.net.Infrastructure
{
    public class VippsHttpClient : IVippsHttpClient
    {
        private HttpClient? _httpClient;
        private TimeSpan DefaultTimeOut = TimeSpan.FromSeconds(100);

        public VippsHttpClient()
        {
        }

        public VippsHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            SetupHttpClientHeaders(httpClient);
        }

        private HttpClient HttpClient
        {
            get
            {
                if (_httpClient is null)
                {
                    _httpClient = CreateDefaultHttpClient();
                }

                return _httpClient;
            }
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            return response;
        }

        private HttpClient CreateDefaultHttpClient()
        {
            var httpClient = new HttpClient()
            {
                Timeout = DefaultTimeOut,
                BaseAddress = new Uri($"{VippsConfigurationHolder.VippsConfiguration.BaseUrl}")
            };

            SetupHttpClientHeaders(httpClient);
            return httpClient;
        }

        private void SetupHttpClientHeaders(HttpClient httpClient)
        {
            AddOrUpdateHeader(httpClient, "Ocp-Apim-Subscription-Key", VippsConfigurationHolder.VippsConfiguration.SubscriptionKey);
            AddOrUpdateHeader(httpClient, "Merchant-Serial-Number", VippsConfigurationHolder.VippsConfiguration.MerchantSerialNumber);
            AddOrUpdateHeader(httpClient, "Vipps-System-Name", "checkout-sandbox");
            AddOrUpdateHeader(httpClient, "Vipps-System-Version", "0.9");
            AddOrUpdateHeader(httpClient, "Vipps-System-Plugin-Name", "checkout-sandbox");
            AddOrUpdateHeader(httpClient, "Vipps-System-Plugin-Version", "0.9");
        }

        private void AddOrUpdateHeader(HttpClient httpClient, string key, string value)
        {
            if (httpClient.DefaultRequestHeaders.Contains(key))
            {
                httpClient.DefaultRequestHeaders.Remove(key);
            }

            httpClient.DefaultRequestHeaders.Add(key, value);
        }
    }
}
