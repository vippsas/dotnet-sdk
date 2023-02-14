using System.Text.Json.Serialization;

namespace Vipps.Models.Checkout.InitiateSession
{
    public class InitiateSessionResponse : VippsResponse
    {
        [property: JsonPropertyName("token")]
        public string Token { get; set; }

        [property: JsonPropertyName("checkoutFrontendUrl")]
        public string CheckoutFrontendUrl { get; set; }

        [property: JsonPropertyName("pollingUrl")]
        public string PollingUrl { get; set; }
    }
}
