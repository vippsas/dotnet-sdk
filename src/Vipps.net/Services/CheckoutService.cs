using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Vipps.Models.Checkout.GetSession;
using Vipps.Models.Checkout.InitiateSession;
using Vipps.net.Exceptions;
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
            if (sessionInitiationResult is null)
            {
                throw new VippsTechnicalException("Failed response from session initiation");
            }
            return sessionInitiationResult;
        }

        public static async Task<GetSessionInfoResponse> GetSessionInfo(
            string reference,
            CancellationToken cancellationToken = default
        )
        {
            var requestPath = $"{VippsConfiguration.BaseUrl}/checkout/v3/session/{reference}";
            var getSessionResult =
                await VippsServices.CheckoutServiceClient.ExecuteRequest<GetSessionInfoResponse>(
                    requestPath,
                    HttpMethod.Get,
                    cancellationToken
                );
            if (getSessionResult is null)
            {
                throw new VippsTechnicalException("Failed response from session polling");
            }
            return getSessionResult;
        }
    }
}
