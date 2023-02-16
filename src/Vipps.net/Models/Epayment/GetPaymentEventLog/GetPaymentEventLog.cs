using System;
using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.GetPaymentEventLog
{
    public class Amount
    {
        [property: JsonPropertyName("currency")]
        public string Currency { get; set; }

        [property: JsonPropertyName("value")]
        public int Value { get; set; }
    }

    public class GetPaymentEventLog
    {
        [property: JsonPropertyName("reference")]
        public string Reference { get; set; }

        [property: JsonPropertyName("pspReference")]
        public string PspReference { get; set; }

        [property: JsonPropertyName("name")]
        public string Name { get; set; }

        [property: JsonPropertyName("paymentAction")]
        public string PaymentAction { get; set; }

        [property: JsonPropertyName("amount")]
        public Amount Amount { get; set; }

        [property: JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [property: JsonPropertyName("processedAt")]
        public DateTime ProcessedAt { get; set; }

        [property: JsonPropertyName("idempotencyKey")]
        public string IdempotencyKey { get; set; }

        [property: JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
