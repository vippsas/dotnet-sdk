using System.Text.Json.Serialization;

namespace Vipps.Models.Checkout.InitiateSession
{
    public record InitiateSessionResponse(
        [property: JsonPropertyName("token")] string Token,
        [property: JsonPropertyName("checkoutFrontendUrl")] string CheckoutFrontendUrl,
        [property: JsonPropertyName("pollingUrl")] string PollingUrl
    );


}
