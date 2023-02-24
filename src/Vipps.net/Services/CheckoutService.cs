using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Vipps.Models.Autogen.Checkout;
using Vipps.net.Infrastructure;

namespace Vipps.Services
{
    public static class CheckoutService
    {
        public static async Task<InitiateSessionResponse> InitiateSession(
            InitiateSessionRequest initiateSessionRequest,
            CancellationToken cancellationToken = default
        )
        {
            var requestPath = $"{VippsConfiguration.BaseUrl}/checkout/v3/session";
            var sessionInitiationResult = await VippsServices.CheckoutServiceClient.ExecuteRequest<
                InitiateSessionRequest,
                InitiateSessionResponse
            >(requestPath, HttpMethod.Post, initiateSessionRequest, cancellationToken);

            return sessionInitiationResult;
        }

        public static async Task<SessionResponse> GetSessionInfo(
            string reference,
            CancellationToken cancellationToken = default
        )
        {
            var requestPath = $"{VippsConfiguration.BaseUrl}/checkout/v3/session/{reference}";
            var getSessionResult =
                await VippsServices.CheckoutServiceClient.ExecuteRequest<SessionResponse>(
                    requestPath,
                    HttpMethod.Get,
                    cancellationToken
                );

            return getSessionResult;
        }
    }
}
