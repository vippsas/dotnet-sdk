using System.Text.Json.Serialization;

namespace Vipps.Models.Checkout.Callbacks
{
    public record LogisticsCallbackRequest(
        [property: JsonPropertyName("StreetAddress")] string StreetAddress,
        [property: JsonPropertyName("PostalCode")] string PostalCode,
        [property: JsonPropertyName("Region")] string Region,
        [property: JsonPropertyName("Country")] string Country
    );
}
