using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Vipps.net.Infrastructure;
using Vipps.net.Models.Checkout;
using Vipps.net.Models.Checkout.Model;

namespace Vipps.net.Services
{
    public interface IVippsCheckoutService
    {
        Task<InitiateSessionResponse> InitiateSession(
            InitiatePaymentSessionRequest initiateSessionRequest,
            CancellationToken cancellationToken = default
        );

        Task<SessionResponse> GetSessionInfo(
            string reference,
            CancellationToken cancellationToken = default
        );
    }

    internal sealed class VippsCheckoutService : IVippsCheckoutService
    {
        private readonly CheckoutServiceClient _checkoutServiceClient;

        public VippsCheckoutService(CheckoutServiceClient checkoutServiceClient)
        {
            _checkoutServiceClient = checkoutServiceClient;
        }

        public async Task<InitiateSessionResponse> InitiateSession(
            InitiatePaymentSessionRequest initiateSessionRequest,
            CancellationToken cancellationToken = default
        )
        {
            var requestPath = $"/checkout/v3/session";
            var sessionInitiationResult = await _checkoutServiceClient.ExecuteRequest<
                InitiatePaymentSessionRequest,
                InitiateSessionResponse
            >(requestPath, HttpMethod.Post, initiateSessionRequest, cancellationToken);

            return sessionInitiationResult;
        }

        public async Task<SessionResponse> GetSessionInfo(
            string reference,
            CancellationToken cancellationToken = default
        )
        {
            var requestPath = $"/checkout/v3/session/{reference}";
            var getSessionResult = await _checkoutServiceClient.ExecuteRequest<SessionResponse>(
                requestPath,
                HttpMethod.Get,
                cancellationToken
            );

            return getSessionResult;
        }
    }
}
