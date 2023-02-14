using System;
using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.GetPaymentEventLog
{
    public class Amount
    {
        [property: JsonPropertyName("currency")]
        public string Currency { get; private set; }

        [property: JsonPropertyName("value")]
        public int Value { get; private set; }
    }

    public class GetPaymentEventLog
    {
        [property: JsonPropertyName("reference")]
        public string Reference { get; private set; }

        [property: JsonPropertyName("pspReference")]
        public string PspReference { get; private set; }

        [property: JsonPropertyName("name")]
        public string Name { get; private set; }

        [property: JsonPropertyName("paymentAction")]
        public string PaymentAction { get; private set; }

        [property: JsonPropertyName("amount")]
        public Amount Amount { get; private set; }

        [property: JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; private set; }

        [property: JsonPropertyName("processedAt")]
        public DateTime ProcessedAt { get; private set; }

        [property: JsonPropertyName("idempotencyKey")]
        public string IdempotencyKey { get; private set; }

        [property: JsonPropertyName("success")]
        public bool Success { get; private set; }
    }
}
