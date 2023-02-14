using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Vipps.Models.Epayment.CancelPayment;
using Vipps.Models.Epayment.CapturePayment;
using Vipps.Models.Epayment.CreatePayment;
using Vipps.Models.Epayment.CreatePaymentRequest;
using Vipps.Models.Epayment.ForceApprove;
using Vipps.Models.Epayment.GetPaymentEventLog;
using Vipps.Models.Epayment.GetPaymentResponse;
using Vipps.Models.Epayment.RefundPayment;
using Vipps.net.Infrastructure;

namespace Vipps.Services
{
    public static class EpaymentService
    {
        public static async Task<CreatePaymentResponse> CreatePayment(
            CreatePaymentRequest createPaymentRequest,
            CancellationToken cancellationToken = default
        )
        {
            return await VippsServices.EpaymentServiceClient.ExecuteRequest<
                CreatePaymentRequest,
                CreatePaymentResponse
            >(GetRequestPath(null, null), HttpMethod.Post, createPaymentRequest, cancellationToken);
        }

        public static async Task<GetPaymentResponse> GetPayment(
            string reference,
            CancellationToken cancellationToken = default
        )
        {
            return await VippsServices.EpaymentServiceClient.ExecuteRequest<GetPaymentResponse>(
                GetRequestPath(reference, null),
                HttpMethod.Get,
                cancellationToken
            );
        }

        public static async Task<IEnumerable<GetPaymentEventLog>> GetPaymentEventLog(
            string reference,
            CancellationToken cancellationToken = default
        )
        {
            return await VippsServices.EpaymentServiceClient.ExecuteRequest<
                IEnumerable<GetPaymentEventLog>
            >(GetRequestPath(reference, "events"), HttpMethod.Get, cancellationToken);
        }

        public static async Task<CancelPaymentResponse> CancelPayment(
            string reference,
            CancellationToken cancellationToken = default
        )
        {
            return await VippsServices.EpaymentServiceClient.ExecuteRequest<CancelPaymentResponse>(
                GetRequestPath(reference, "cancel"),
                HttpMethod.Post,
                cancellationToken
            );
        }

        public static async Task<CapturePaymentResponse> CapturePayment(
            CapturePaymentRequest capturePaymentRequest,
            CancellationToken cancellationToken = default
        )
        {
            return await VippsServices.EpaymentServiceClient.ExecuteRequest<
                CapturePaymentRequest,
                CapturePaymentResponse
            >(
                GetRequestPath(null, "capture"),
                HttpMethod.Post,
                capturePaymentRequest,
                cancellationToken
            );
        }

        public static async Task<RefundPaymentResponse> RefundPayment(
            string reference,
            CancellationToken cancellationToken = default
        )
        {
            return await VippsServices.EpaymentServiceClient.ExecuteRequest<RefundPaymentResponse>(
                GetRequestPath(reference, "refund"),
                HttpMethod.Post,
                cancellationToken
            );
        }

        public static async Task ForceApprovePayment(
            string reference,
            ForceApproveRequest forceApproveRequest,
            CancellationToken cancellationToken = default
        )
        {
            await VippsServices.EpaymentServiceClient.ExecuteRequest(
                GetRequestPath(reference, "approve"),
                HttpMethod.Post,
                forceApproveRequest,
                cancellationToken
            );
        }

        private static string GetRequestPath(string reference, string path)
        {
            var requestPath = $"{VippsConfiguration.BaseUrl}/epayment/v1/payments";
            if (reference != null)
            {
                requestPath += $"/{reference}";
            }
            if (path != null)
            {
                requestPath += $"/{path}";
            }

            return requestPath;
        }
    }
}
