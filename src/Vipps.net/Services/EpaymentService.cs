using Vipps.Models.Epayment.CancelPayment;
using Vipps.Models.Epayment.CapturePayment;
using Vipps.Models.Epayment.CreatePayment;
using Vipps.Models.Epayment.CreatePaymentRequest;
using Vipps.Models.Epayment.ForceApprove;
using Vipps.Models.Epayment.GetPaymentEventLog;
using Vipps.Models.Epayment.GetPaymentResponse;
using Vipps.Models.Epayment.RefundPayment;
using Vipps.net.Infrastructure;
using Vipps.net.Models.Base;

namespace Vipps.Services
{
    public static class EpaymentService
    {
        public static async Task<CreatePaymentResponse> CreatePayment(CreatePaymentRequest createPaymentRequest)
        {
            return await ExecuteEpaymentRequest<CreatePaymentRequest, CreatePaymentResponse>(HttpMethod.Post, null, null, createPaymentRequest);
        }
        public static async Task<GetPaymentResponse> GetPayment(string reference)
        {
            return await ExecuteEpaymentRequest<VoidType, GetPaymentResponse>(HttpMethod.Get, null, reference, null);
        }
        public static async Task<IEnumerable<GetPaymentEventLog>> GetPaymentEventLog(string reference)
        {
            return await ExecuteEpaymentRequest<ForceApproveRequest, IEnumerable<GetPaymentEventLog>>(HttpMethod.Get, "events", reference, null);
        }

        public static async Task<CancelPaymentResponse> CancelPayment(string reference)
        {
            return await ExecuteEpaymentRequest<VoidType, CancelPaymentResponse>(HttpMethod.Post, "cancel", reference, null);
        }

        public static async Task<CapturePaymentResponse> CapturePayment(CapturePaymentRequest capturePaymentRequest)
        {
            return await ExecuteEpaymentRequest<CapturePaymentRequest, CapturePaymentResponse>(HttpMethod.Post, "capture", null, capturePaymentRequest);
        }

        public static async Task<RefundPaymentResponse> RefundPayment(string reference)
        {
            return await ExecuteEpaymentRequest<VoidType, RefundPaymentResponse>(HttpMethod.Post, "refund", reference, null);
        }

        public static async Task ForceApprovePayment(string reference, ForceApproveRequest forceApproveRequest)
        {
            await ExecuteEpaymentRequest<ForceApproveRequest, VoidType>(HttpMethod.Post, "approve", reference, forceApproveRequest);
        }

        private static async Task<TResponse> ExecuteEpaymentRequest<TRequest, TResponse>(
            HttpMethod httpMethod,
            string? reference,
            string? path,
            TRequest? data
            )
        {
            var requestPath = $"{VippsConfigurationHolder.VippsConfiguration.BaseUrl}/";
            if (reference is not null)
            {
                requestPath += reference;
            }
            if (path is not null)
            {
                requestPath += path;
            }

            var authToken = await AccessTokenService.GetAccessToken();
            System.Net.Http.Headers.AuthenticationHeaderValue? authorizationheader = new System.Net.Http.Headers.AuthenticationHeaderValue(Vipps.net.Helpers.Constants.Bearer, authToken.Token);
            var response = await VippsConfigurationHolder.VippsClient.ExecuteRequest<TRequest, TResponse>(requestPath, httpMethod, data, authorizationheader, null);
            return response;
        }
    }
}
