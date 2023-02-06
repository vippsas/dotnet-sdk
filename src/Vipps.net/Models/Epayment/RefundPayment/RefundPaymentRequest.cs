using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.RefundPayment
{
    public record RefundPaymentRequest(
        [property: JsonPropertyName("modificationAmount")] ModificationAmount ModificationAmount
    );

    public record ModificationAmount(
        [property: JsonPropertyName("currency")] string Currency,
        [property: JsonPropertyName("value")] int Value
    );
}
