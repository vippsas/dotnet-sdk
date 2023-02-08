using Vipps.Models.Checkout.GetSession;
using Vipps.Models.Checkout.InitiateSession;
using Vipps.net.Helpers;
using Vipps.net.Infrastructure;
using Vipps.net.Models.Base;

namespace Vipps.Services
{
    public static class CheckoutService
    {
        public static async Task<InitiateSessionResponse> InitiateSession(InitiateSessionRequest initiateSessionRequest)
        {
            var requestPath = $"{VippsConfigurationHolder.VippsConfiguration.BaseUrl}/checkout/v3/session";
            var sessionInitiationResult = await VippsConfigurationHolder.VippsClient.ExecuteRequest<InitiateSessionRequest, InitiateSessionResponse>(requestPath, HttpMethod.Post, initiateSessionRequest, GetHeaders(), null);
            if (sessionInitiationResult is null)
            {
                throw new Exception("Failed response from session initiation");
            }
            return sessionInitiationResult;
        }

        public static async Task<GetSessionInfoResponse> GetSessionInfo(string reference)
        {
            var requestPath = $"{VippsConfigurationHolder.VippsConfiguration.BaseUrl}/checkout/v3/session/{reference}";
            var getSessionResult = await VippsConfigurationHolder.VippsClient.ExecuteRequest<VoidType, GetSessionInfoResponse>(requestPath, HttpMethod.Get, null, GetHeaders(), null);
            if (getSessionResult is null)
            {
                throw new Exception("Failed response from session polling");
            }
            return getSessionResult;
        }

        private static Dictionary<string, string> GetHeaders()
        {
            return new Dictionary<string, string>
            {
                { Constants.HeaderNameClientId, VippsConfigurationHolder.VippsConfiguration.ClientId },
                { Constants.HeaderNameClientSecret, VippsConfigurationHolder.VippsConfiguration.ClientSecret }
            };
        }
    }
}
