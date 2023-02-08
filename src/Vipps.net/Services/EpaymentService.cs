using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using Vipps.Helpers;
using Vipps.Models;
using Vipps.Models.Epayment.CancelPayment;
using Vipps.Models.Epayment.CapturePayment;
using Vipps.Models.Epayment.CreatePayment;
using Vipps.Models.Epayment.CreatePaymentRequest;
using Vipps.Models.Epayment.ForceApprove;
using Vipps.Models.Epayment.GetPaymentEventLog;
using Vipps.Models.Epayment.GetPaymentResponse;
using Vipps.Models.Epayment.RefundPayment;

namespace Vipps.Services
{
    public class EpaymentService
    {
        private readonly VippsConfiguration _vippsConfiguration;
        private readonly HttpClient _httpClient;
        private readonly ILogger<EpaymentService> _logger;

        public EpaymentService(VippsConfiguration vippsConfiguration, HttpClient httpClient, ILogger<EpaymentService> logger)
        {
            _vippsConfiguration = vippsConfiguration;
            _httpClient = httpClient;
            _logger = logger;

            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _vippsConfiguration.SubscriptionKey);
            _httpClient.DefaultRequestHeaders.Add("Merchant-Serial-Number", _vippsConfiguration.MerchantSerialNumber);
            _httpClient.DefaultRequestHeaders.Add("Vipps-System-Name", "checkout-sandbox");
            _httpClient.DefaultRequestHeaders.Add("Vipps-System-Version", "0.9");
            _httpClient.DefaultRequestHeaders.Add("Vipps-System-Plugin-Name", "checkout-sandbox");
            _httpClient.DefaultRequestHeaders.Add("Vipps-System-Plugin-Version", "0.9");

            _httpClient.BaseAddress = new Uri($"{vippsConfiguration.BaseUrl}/epayment/v1/test/payments");
        }

        public async Task<CreatePaymentResponse> CreatePayment(CreatePaymentRequest createPaymentRequest)
        {
            return await ExecuteEpaymentRequest<CreatePaymentRequest, CreatePaymentResponse>(HttpMethod.Post, null, null, createPaymentRequest);
        }
        public async Task<GetPaymentResponse> GetPayment(string reference)
        {
            return await ExecuteEpaymentRequest<VoidType, GetPaymentResponse>(HttpMethod.Get, null, reference, null);
        }
        public async Task<IEnumerable<GetPaymentEventLog>> GetPaymentEventLog(string reference)
        {
            return await ExecuteEpaymentRequest<ForceApproveRequest, IEnumerable<GetPaymentEventLog>>(HttpMethod.Get, "events", reference, null);
        }

        public async Task<CancelPaymentResponse> CancelPayment(string reference)
        {
            return await ExecuteEpaymentRequest<VoidType, CancelPaymentResponse>(HttpMethod.Post, "cancel", reference, null);
        }

        public async Task<CapturePaymentResponse> CapturePayment(CapturePaymentRequest capturePaymentRequest)
        {
            return await ExecuteEpaymentRequest<CapturePaymentRequest, CapturePaymentResponse>(HttpMethod.Post, "capture", null, capturePaymentRequest);
        }

        public async Task<RefundPaymentResponse> RefundPayment(string reference)
        {
            return await ExecuteEpaymentRequest<VoidType, RefundPaymentResponse>(HttpMethod.Post, "refund", reference, null);
        }

        public async Task ForceApprovePayment(string reference, ForceApproveRequest forceApproveRequest)
        {
            await ExecuteEpaymentRequest<ForceApproveRequest, VoidType>(HttpMethod.Post, "approve", reference, forceApproveRequest);
        }

        private async Task<TResponse> ExecuteEpaymentRequest<TRequest, TResponse>(
            HttpMethod httpMethod,
            string? reference,
            string? path,
            TRequest? data
            )
        {
            var retryPolicy = PolicyHelper.GetRetryPolicyWithFallback(
                _logger,
                $"Request for {path} failed even after retries"
            );

            var requestPath = $"{_httpClient.BaseAddress}/";
            if (reference is not null)
                requestPath += reference;
            if (path is not null)
                requestPath += path;

            var response = await retryPolicy.ExecuteAsync(async () =>
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(requestPath),
                    Method = httpMethod,
                    Content = data is not null ? JsonContent.Create(data) : null
                };

                return await _httpClient.SendAsync(request);
            });

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Request failed with status code {response.StatusCode}");
            }
            if (typeof(TResponse) != typeof(VoidType))
                return await response.Content.ReadFromJsonAsync<TResponse>() ?? throw new Exception("Failed deserializing response");
            return default!;
        }

        private class VoidType
        {
            public VoidType() { }
        }
    }
}
