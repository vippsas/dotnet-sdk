using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.GetPaymentEventLog
{
    public class Amount
    {
        [property: JsonPropertyName("currency")]
        public string Currency { get; init; }

        [property: JsonPropertyName("value")]
        public int Value { get; init; }
    }

    public class GetPaymentEventLog
    {
        [property: JsonPropertyName("reference")]
        public string Reference { get; init; }

        [property: JsonPropertyName("pspReference")]
        public string PspReference { get; init; }

        [property: JsonPropertyName("name")]
        public string Name { get; init; }

        [property: JsonPropertyName("paymentAction")]
        public string PaymentAction { get; init; }

        [property: JsonPropertyName("amount")]
        public Amount Amount { get; init; }

        [property: JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }

        [property: JsonPropertyName("processedAt")]
        public DateTime ProcessedAt { get; init; }

        [property: JsonPropertyName("idempotencyKey")]
        public string IdempotencyKey { get; init; }

        [property: JsonPropertyName("success")]
        public bool Success { get; init; }
    }
}
