using System.Text.Json.Serialization;

namespace Vipps.Models.Checkout.InitiateSession
{
    public class InitiateSessionResponse
    {
        [property: JsonPropertyName("token")]
        public string Token { get; init; }

        [property: JsonPropertyName("checkoutFrontendUrl")]
        public string CheckoutFrontendUrl { get; init; }

        [property: JsonPropertyName("pollingUrl")]
        public string PollingUrl { get; init; }
    }
}
