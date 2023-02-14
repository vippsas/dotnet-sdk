using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Microsoft.Extensions.Logging;
using Vipps.Helpers;
using Vipps.Models;
using Vipps.net.Helpers;

namespace Vipps.net.Infrastructure
{
    internal abstract class BaseServiceClient
    {
        protected virtual ILogger<BaseServiceClient> Logger { get; init; }
        protected readonly IVippsHttpClient _vippsHttpClient;

        protected BaseServiceClient(IVippsHttpClient vippsHttpClient)
        {
            _vippsHttpClient = vippsHttpClient;
        }

        public async Task<TResponse> ExecuteRequest<TRequest, TResponse>(
            string path,
            HttpMethod httpMethod,
            TRequest? data,
            CancellationToken cancellationToken = default
        ) where TRequest : VippsRequest
        {
            return await ExecuteRequestBaseAndParse<TResponse>(
                path,
                httpMethod,
                CreateRequestContent(data),
                cancellationToken
            );
        }

        public async Task ExecuteRequest<TRequest>(
            string path,
            HttpMethod httpMethod,
            TRequest? data,
            CancellationToken cancellationToken = default
        ) where TRequest : VippsRequest
        {
            await ExecuteRequestBase(
                path,
                httpMethod,
                CreateRequestContent(data),
                cancellationToken
            );
        }

        public async Task<TResponse> ExecuteRequest<TResponse>(
            string path,
            HttpMethod httpMethod,
            CancellationToken cancellationToken = default
        )
        {
            return await ExecuteRequestBaseAndParse<TResponse>(
                path,
                httpMethod,
                null,
                cancellationToken
            );
        }

        protected virtual async Task<Dictionary<string, string>?> GetHeaders(
            CancellationToken cancellationToken
        )
        {
            return await Task.FromResult((Dictionary<string, string>?)null);
        }

        private async Task<TResponse> ExecuteRequestBaseAndParse<TResponse>(
            string path,
            HttpMethod httpMethod,
            HttpContent? httpContent,
            CancellationToken cancellationToken
        )
        {
            var response = await ExecuteRequestBase(
                path,
                httpMethod,
                httpContent,
                cancellationToken
            );
            return await response.Content.ReadFromJsonAsync<TResponse>(
                    cancellationToken: cancellationToken
                ) ?? throw new Exception("Failed deserializing response");
        }

        private async Task<HttpResponseMessage> ExecuteRequestBase(
            string path,
            HttpMethod httpMethod,
            HttpContent? httpContent,
            CancellationToken cancellationToken
        )
        {
            var retryPolicy = PolicyHelper.GetRetryPolicyWithFallback(
                Logger,
                $"Request for {path} failed even after retries"
            );
            var headers = await GetHeaders(cancellationToken);
            var response = await retryPolicy.ExecuteAsync(async () =>
            {
                var requestMessage = new HttpRequestMessage
                {
                    RequestUri = new Uri(path),
                    Method = httpMethod,
                    Content = httpContent,
                };
                if (headers is not null)
                {
                    foreach (var item in headers)
                    {
                        AddOrUpdateHeader(requestMessage.Headers, item.Key, item.Value);
                    }
                }
                return await _vippsHttpClient.SendAsync(requestMessage, cancellationToken);
            });

            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
                throw new Exception(
                    $"Request failed with status code {response.StatusCode}, content: '{responseContent}'"
                );
            }

            return response;
        }

        private static HttpContent? CreateRequestContent<TRequest>(TRequest? vippsRequest)
            where TRequest : VippsRequest
        {
            if (vippsRequest is null)
            {
                return null;
            }
            var serializedRequest = VippsRequestSerializer.SerializeVippsRequest(vippsRequest);
            return new StringContent(serializedRequest, Encoding.UTF8, "application/json");
        }

        private static void AddOrUpdateHeader(HttpRequestHeaders headers, string key, string value)
        {
            if (headers.Contains(key))
            {
                headers.Remove(key);
            }

            headers.Add(key, value);
        }
    }
}
