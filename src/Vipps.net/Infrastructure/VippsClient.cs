using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using Vipps.Helpers;
using Vipps.net.Models.Base;

namespace Vipps.net.Infrastructure
{
    public class VippsClient : IVippsClient
    {
        private readonly IVippsHttpClient _vippsHttpClient;
        private readonly ILogger<VippsClient> _logger = LoggerFactory.Create((ILoggingBuilder lb) => { }).CreateLogger<VippsClient>();
        public VippsClient()
        {
            _vippsHttpClient = new VippsHttpClient();
        }

        public VippsClient(HttpClient httpClient)
        {
            _vippsHttpClient = new VippsHttpClient(httpClient);
        }

        public async Task<TResponse> ExecuteRequest<TRequest, TResponse>(string path, HttpMethod httpMethod, TRequest? data, Dictionary<string, string>? headers, CancellationToken? cancellationToken)
        {
            HttpResponseMessage response = await ExecuteRequestBase(path, httpMethod, data, headers, cancellationToken);
            if (typeof(TResponse) != typeof(VoidType))
                return await response.Content.ReadFromJsonAsync<TResponse>() ?? throw new Exception("Failed deserializing response");
            return default!;
        }

        public async Task<string> ExecuteRequest<TRequest>(string path, HttpMethod httpMethod, TRequest? data, Dictionary<string, string>? headers, CancellationToken? cancellationToken)
        {
            HttpResponseMessage response = await ExecuteRequestBase(path, httpMethod, data, headers, cancellationToken);
            return await response.Content.ReadAsStringAsync() ?? throw new Exception("Failed reading response");
        }

        private async Task<HttpResponseMessage> ExecuteRequestBase<TRequest>(string path, HttpMethod httpMethod, TRequest? data, Dictionary<string, string>? headers, CancellationToken? cancellationToken)
        {
            var retryPolicy = PolicyHelper.GetRetryPolicyWithFallback(
                           _logger,
                            $"Request for {path} failed even after retries"
                        );

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(path),
                Method = httpMethod,
                Content = data is not null ? JsonContent.Create(data) : null,
            };
            request.Headers.Add("Idempotency-Key", Guid.NewGuid().ToString());
            if (headers is not null)
            {
                request.Headers.Authorization = authorizationheader;
            }

            var response = await retryPolicy.ExecuteAsync(async () => await _vippsHttpClient.SendAsync(request, cancellationToken ?? default));

            if (!response.IsSuccessStatusCode)
            {
                // TODO: Read as problemdetails
                var responseContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Request failed with status code {response.StatusCode}, content: '{responseContent}'");
            }

            return response;
        }
    }
}
