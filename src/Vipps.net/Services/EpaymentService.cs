using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Vipps.Models.Autogen.Epayment;
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
            CaptureModificationRequest capturePaymentRequest,
            CancellationToken cancellationToken = default
        )
        {
            return await VippsServices.EpaymentServiceClient.ExecuteRequest<
                CaptureModificationRequest,
                ModificationResponse
            >(
                GetRequestPath(null, "capture"),
                HttpMethod.Post,
                capturePaymentRequest,
                cancellationToken
            );
        }

        public static async Task<ModificationResponse> RefundPayment(
            string reference,
            CancellationToken cancellationToken = default
        )
        {
            return await VippsServices.EpaymentServiceClient.ExecuteRequest<ModificationResponse>(
                GetRequestPath(reference, "refund"),
                HttpMethod.Post,
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
