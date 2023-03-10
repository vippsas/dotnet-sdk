using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Vipps.net.Infrastructure;
using Vipps.net.Models.Autogen.Epayment;

namespace Vipps.net.Services
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

        public static async Task<IEnumerable<PaymentEvent>> GetPaymentEventLog(
            string reference,
            CancellationToken cancellationToken = default
        )
        {
            return await VippsServices.EpaymentServiceClient.ExecuteRequest<
                IEnumerable<PaymentEvent>
            >(GetRequestPath(reference, "events"), HttpMethod.Get, cancellationToken);
        }

        public static async Task<ModificationResponse> CancelPayment(
            string reference,
            CancellationToken cancellationToken = default
        )
        {
            return await VippsServices.EpaymentServiceClient.ExecuteRequest<ModificationResponse>(
                GetRequestPath(reference, "cancel"),
                HttpMethod.Post,
                cancellationToken
            );
        }

        public static async Task<ModificationResponse> CapturePayment(
            string reference,
            CaptureModificationRequest capturePaymentRequest,
            CancellationToken cancellationToken = default
        )
        {
            return await VippsServices.EpaymentServiceClient.ExecuteRequest<
                CaptureModificationRequest,
                ModificationResponse
            >(
                GetRequestPath(reference, "capture"),
                HttpMethod.Post,
                capturePaymentRequest,
                cancellationToken
            );
        }

        public static async Task<ModificationResponse> RefundPayment(
            string reference,
            RefundModificationRequest refundModificationRequest,
            CancellationToken cancellationToken = default
        )
        {
            return await VippsServices.EpaymentServiceClient.ExecuteRequest<
                RefundModificationRequest,
                ModificationResponse
            >(
                GetRequestPath(reference, "refund"),
                HttpMethod.Post,
                refundModificationRequest,
                cancellationToken
            );
        }

        public static async Task ForceApprovePayment(
            string reference,
            ForceApprove forceApproveRequest,
            CancellationToken cancellationToken = default
        )
        {
            await VippsServices.EpaymentServiceClient.ExecuteRequest(
                $"/epayment/v1/test/payments/{reference}/approve",
                HttpMethod.Post,
                forceApproveRequest,
                cancellationToken
            );
        }

        private static string GetRequestPath(string reference, string path)
        {
            var requestPath = "/epayment/v1/payments";
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
