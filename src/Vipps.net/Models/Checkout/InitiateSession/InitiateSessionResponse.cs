using System.Text.Json.Serialization;

namespace Vipps.Models.Checkout.InitiateSession
{
    public class InitiateSessionResponse : VippsResponse
    {
        public InitiateSessionResponse(string token, string checkoutFrontendUrl, string pollingUrl)
        {
            Token = token;
            CheckoutFrontendUrl = checkoutFrontendUrl;
            PollingUrl = pollingUrl;
        }

        [property: JsonPropertyName("token")]
        public string Token { get; private set; }

        [property: JsonPropertyName("checkoutFrontendUrl")]
        public string CheckoutFrontendUrl { get; private set; }

        [property: JsonPropertyName("pollingUrl")]
        public string PollingUrl { get; private set; }
    }
}
