using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.CreatePayment
{
    public record CreatePaymentResponse(
        [property: JsonPropertyName("redirectUrl")] string RedirectUrl,
        [property: JsonPropertyName("reference")] string Reference
    );
}
