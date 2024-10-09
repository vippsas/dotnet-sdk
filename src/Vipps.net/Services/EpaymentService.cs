using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Vipps.net.Infrastructure;
using Vipps.net.Models.Epayment.Model;

namespace Vipps.net.Services
{
    public interface IVippsEpaymentService
    {
        Task<CreatePaymentResponse> CreatePayment(
            CreatePaymentRequest createPaymentRequest,
            CancellationToken cancellationToken = default
        );

        Task<GetPaymentResponse> GetPayment(
            string reference,
            CancellationToken cancellationToken = default
        );

        Task<IEnumerable<PaymentEvent>> GetPaymentEventLog(
            string reference,
            CancellationToken cancellationToken = default
        );

        Task<ModificationResponse> CancelPayment(
            string reference,
            CancellationToken cancellationToken = default
        );

        Task<ModificationResponse> CapturePayment(
            string reference,
            CaptureModificationRequest capturePaymentRequest,
            CancellationToken cancellationToken = default
        );

        Task<ModificationResponse> RefundPayment(
            string reference,
            RefundModificationRequest refundModificationRequest,
            CancellationToken cancellationToken = default
        );

        Task ForceApprovePayment(
            string reference,
            ForceApprove forceApproveRequest,
            CancellationToken cancellationToken = default
        );
    }

    internal sealed class VippsEpaymentService : IVippsEpaymentService
    {
        private readonly EpaymentServiceClient _epaymentServiceClient;

        public VippsEpaymentService(EpaymentServiceClient epaymentServiceClient)
        {
            _epaymentServiceClient = epaymentServiceClient;
        }

        public async Task<CreatePaymentResponse> CreatePayment(
            CreatePaymentRequest createPaymentRequest,
            CancellationToken cancellationToken = default
        )
        {
            return await _epaymentServiceClient.ExecuteRequest<
                CreatePaymentRequest,
                CreatePaymentResponse
            >(GetRequestPath(null, null), HttpMethod.Post, createPaymentRequest, cancellationToken);
        }

        public async Task<GetPaymentResponse> GetPayment(
            string reference,
            CancellationToken cancellationToken = default
        )
        {
            return await _epaymentServiceClient.ExecuteRequest<GetPaymentResponse>(
                GetRequestPath(reference, null),
                HttpMethod.Get,
                cancellationToken
            );
        }

        public async Task<IEnumerable<PaymentEvent>> GetPaymentEventLog(
            string reference,
            CancellationToken cancellationToken = default
        )
        {
            return await _epaymentServiceClient.ExecuteRequest<IEnumerable<PaymentEvent>>(
                GetRequestPath(reference, "events"),
                HttpMethod.Get,
                cancellationToken
            );
        }

        public async Task<ModificationResponse> CancelPayment(
            string reference,
            CancellationToken cancellationToken = default
        )
        {
            return await _epaymentServiceClient.ExecuteRequest<ModificationResponse>(
                GetRequestPath(reference, "cancel"),
                HttpMethod.Post,
                cancellationToken
            );
        }

        public async Task<ModificationResponse> CapturePayment(
            string reference,
            CaptureModificationRequest capturePaymentRequest,
            CancellationToken cancellationToken = default
        )
        {
            return await _epaymentServiceClient.ExecuteRequest<
                CaptureModificationRequest,
                ModificationResponse
            >(
                GetRequestPath(reference, "capture"),
                HttpMethod.Post,
                capturePaymentRequest,
                cancellationToken
            );
        }

        public async Task<ModificationResponse> RefundPayment(
            string reference,
            RefundModificationRequest refundModificationRequest,
            CancellationToken cancellationToken = default
        )
        {
            return await _epaymentServiceClient.ExecuteRequest<
                RefundModificationRequest,
                ModificationResponse
            >(
                GetRequestPath(reference, "refund"),
                HttpMethod.Post,
                refundModificationRequest,
                cancellationToken
            );
        }

        public async Task ForceApprovePayment(
            string reference,
            ForceApprove forceApproveRequest,
            CancellationToken cancellationToken = default
        )
        {
            await _epaymentServiceClient.ExecuteRequest(
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
