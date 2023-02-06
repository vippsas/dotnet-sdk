using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.GetPaymentEventLog
{
    public record Amount(
    [property: JsonPropertyName("currency")] string Currency,
    [property: JsonPropertyName("value")] int Value
);

    public record GetPaymentEventLog(
        [property: JsonPropertyName("reference")] string Reference,
        [property: JsonPropertyName("pspReference")] string PspReference,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("paymentAction")] string PaymentAction,
        [property: JsonPropertyName("amount")] Amount Amount,
        [property: JsonPropertyName("timestamp")] DateTime Timestamp,
        [property: JsonPropertyName("processedAt")] DateTime ProcessedAt,
        [property: JsonPropertyName("idempotencyKey")] string IdempotencyKey,
        [property: JsonPropertyName("success")] bool Success
    );
}
