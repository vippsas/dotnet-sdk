using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.CapturePayment
{
    public record CapturePaymentRequest(
        [property: JsonPropertyName("modificationAmount")] ModificationAmount ModificationAmount
    );

    public record ModificationAmount(
        [property: JsonPropertyName("currency")] string Currency,
        [property: JsonPropertyName("value")] int Value
    );
}
