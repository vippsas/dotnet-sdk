﻿using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Microsoft.Extensions.Logging;
using Vipps.Helpers;
using Vipps.Models;
using Vipps.net.Helpers;
using Vipps.net.Models.Base;

namespace Vipps.net.Infrastructure
{
    public class VippsClient : IVippsClient
    {
        private readonly IVippsHttpClient _vippsHttpClient;
        private readonly ILogger<VippsClient> _logger = LoggerFactory
            .Create((ILoggingBuilder lb) => { })
            .CreateLogger<VippsClient>();

        public VippsClient()
        {
            _vippsHttpClient = new VippsHttpClient();
        }

        public VippsClient(HttpClient httpClient)
        {
            _vippsHttpClient = new VippsHttpClient(httpClient);
        }

        public async Task<TResponse> ExecuteRequest<TRequest, TResponse>(
            string path,
            HttpMethod httpMethod,
            TRequest? data,
            Dictionary<string, string>? headers,
            CancellationToken? cancellationToken
        )
            where TRequest : VippsRequest
        {
            return await ExecuteRequestBaseAndParse<TResponse>(
                path,
                httpMethod,
                CreateRequestContent(data),
                headers,
                cancellationToken
            );
        }

        public async Task<TResponse> ExecuteRequest<TResponse>(
            string path,
            HttpMethod httpMethod,
            Dictionary<string, string>? headers,
            CancellationToken? cancellationToken
        )
        {
            return await ExecuteRequestBaseAndParse<TResponse>(
                path,
                httpMethod,
                null,
                headers,
                cancellationToken
            );
        }

        private async Task<TResponse> ExecuteRequestBaseAndParse<TResponse>(
            string path,
            HttpMethod httpMethod,
            HttpContent? httpContent,
            Dictionary<string, string>? headers,
            CancellationToken? cancellationToken
        )
        {
            var response = await ExecuteRequestBase(
                path,
                httpMethod,
                httpContent,
                headers,
                cancellationToken
            );
            if (typeof(TResponse) != typeof(VoidType))
                return await response.Content.ReadFromJsonAsync<TResponse>()
                    ?? throw new Exception("Failed deserializing response");
            return default!;
        }

        private async Task<HttpResponseMessage> ExecuteRequestBase(
            string path,
            HttpMethod httpMethod,
            HttpContent? httpContent,
            Dictionary<string, string>? headers,
            CancellationToken? cancellationToken
        )
        {
            var idempotencyKey = Guid.NewGuid().ToString();
            var retryPolicy = PolicyHelper.GetRetryPolicyWithFallback(
                _logger,
                $"Request for {path} failed even after retries"
            );
            var response = await retryPolicy.ExecuteAsync(async () =>
            {
                var requestMessage = new HttpRequestMessage
                {
                    RequestUri = new Uri(path),
                    Method = httpMethod,
                    Content = httpContent,
                };
                requestMessage.Headers.Add("Idempotency-Key", idempotencyKey);
                if (headers is not null)
                {
                    foreach (var item in headers)
                    {
                        AddOrUpdateHeader(requestMessage.Headers, item.Key, item.Value);
                    }
                }
                return await _vippsHttpClient.SendAsync(
                    requestMessage,
                    cancellationToken ?? default
                );
            });

            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
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
