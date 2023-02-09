using Vipps.Models;
using Vipps.Models.Epayment.CancelPayment;
using Vipps.Models.Epayment.CapturePayment;
using Vipps.Models.Epayment.CreatePayment;
using Vipps.Models.Epayment.CreatePaymentRequest;
using Vipps.Models.Epayment.ForceApprove;
using Vipps.Models.Epayment.GetPaymentEventLog;
using Vipps.Models.Epayment.GetPaymentResponse;
using Vipps.Models.Epayment.RefundPayment;
using Vipps.net.Helpers;
using Vipps.net.Infrastructure;
using Vipps.net.Models.Base;

namespace Vipps.Services
{
    public static class EpaymentService
    {
        public static async Task<CreatePaymentResponse> CreatePayment(
            CreatePaymentRequest createPaymentRequest,
            CancellationToken? cancellationToken
        )
        {
            return await ExecuteEpaymentRequest<CreatePaymentRequest, CreatePaymentResponse>(
                HttpMethod.Post,
                null,
                null,
                createPaymentRequest,
                cancellationToken
            );
        }

        public static async Task<GetPaymentResponse> GetPayment(
            string reference,
            CancellationToken? cancellationToken
        )
        {
            return await ExecuteEpaymentRequest<GetPaymentResponse>(
                HttpMethod.Get,
                null,
                reference,
                cancellationToken
            );
        }

        public static async Task<IEnumerable<GetPaymentEventLog>> GetPaymentEventLog(
            string reference,
            CancellationToken? cancellationToken
        )
        {
            return await ExecuteEpaymentRequest<IEnumerable<GetPaymentEventLog>>(
                HttpMethod.Get,
                "events",
                reference,
                cancellationToken
            );
        }

        public static async Task<CancelPaymentResponse> CancelPayment(
            string reference,
            CancellationToken? cancellationToken
        )
        {
            return await ExecuteEpaymentRequest<CancelPaymentResponse>(
                HttpMethod.Post,
                "cancel",
                reference,
                cancellationToken
            );
        }

        public static async Task<CapturePaymentResponse> CapturePayment(
            CapturePaymentRequest capturePaymentRequest,
            CancellationToken? cancellationToken
        )
        {
            return await ExecuteEpaymentRequest<CapturePaymentRequest, CapturePaymentResponse>(
                HttpMethod.Post,
                "capture",
                null,
                capturePaymentRequest,
                cancellationToken
            );
        }

        public static async Task<RefundPaymentResponse> RefundPayment(
            string reference,
            CancellationToken? cancellationToken
        )
        {
            return await ExecuteEpaymentRequest<RefundPaymentResponse>(
                HttpMethod.Post,
                "refund",
                reference,
                cancellationToken
            );
        }

        public static async Task ForceApprovePayment(
            string reference,
            ForceApproveRequest forceApproveRequest,
            CancellationToken? cancellationToken
        )
        {
            await ExecuteEpaymentRequest<ForceApproveRequest, VoidType>(
                HttpMethod.Post,
                "approve",
                reference,
                forceApproveRequest,
                cancellationToken
            );
        }

        private static async Task<TResponse> ExecuteEpaymentRequest<TRequest, TResponse>(
            HttpMethod httpMethod,
            string? path,
            string? reference,
            TRequest? data,
            CancellationToken? cancellationToken
        )
            where TRequest : VippsRequest
        {
            var requestPath = GetRequestPath(reference, path);
            var headers = await GetHeaders(cancellationToken);
            var response = await VippsConfiguration.VippsClient.ExecuteRequest<TRequest, TResponse>(
                requestPath,
                httpMethod,
                data,
                headers,
                cancellationToken
            );
            return response;
        }

        private static async Task<TResponse> ExecuteEpaymentRequest<TResponse>(
            HttpMethod httpMethod,
            string? path,
            string? reference,
            CancellationToken? cancellationToken
        )
        {
            var requestPath = GetRequestPath(reference, path);
            var headers = await GetHeaders(cancellationToken);
            var response = await VippsConfiguration.VippsClient.ExecuteRequest<TResponse>(
                requestPath,
                httpMethod,
                headers,
                cancellationToken
            );
            return response;
        }

        private static string GetRequestPath(string? reference, string? path)
        {
            var requestPath = $"{VippsConfiguration.BaseUrl}/epayment/v1/payments";
            if (reference is not null)
            {
                requestPath += reference;
            }
            if (path is not null)
            {
                requestPath += path;
            }

            return requestPath;
        }

        private static async Task<Dictionary<string, string>> GetHeaders(
            CancellationToken? cancellationToken
        )
        {
            var authToken = await AccessTokenService.GetAccessToken(cancellationToken);
            var headers = new Dictionary<string, string>
            {
                {
                    Constants.HeaderNameAuthorization,
                    $"{Constants.AuthorizationSchemeNameBearer} {authToken.Token}"
                }
            };
            return headers;
        }
    }
}
