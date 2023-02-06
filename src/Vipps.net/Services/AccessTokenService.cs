using System.Net.Http.Json;
using Vipps.Models;
using Vipps.Models.Epayment.AccessToken;

namespace Vipps.Services
{
    public class AccessTokenService
    {
        private VippsConfiguration _vippsConfiguration;
        private HttpClient _httpClient;

        public AccessTokenService(VippsConfiguration vippsConfiguration, HttpClient httpClient)
        {
            _vippsConfiguration = vippsConfiguration;
            _httpClient = httpClient;

            _httpClient.DefaultRequestHeaders.Add("client_id", vippsConfiguration.ClientId);
            _httpClient.DefaultRequestHeaders.Add("client_secret", vippsConfiguration.ClientSecret);
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", vippsConfiguration.SubscriptionKey);
        }

        public async Task<AccessToken> GetAccessToken()
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(_vippsConfiguration.BaseUrl + "/accesstoken/get"),
                Method = HttpMethod.Get
            };

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Request failed with status code {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<AccessToken>() ?? throw new Exception("Failed deserializing access token");
        }
    }
}
