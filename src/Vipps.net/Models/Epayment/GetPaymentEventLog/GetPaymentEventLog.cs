using System;
using Newtonsoft.Json;

namespace Vipps.Models.Epayment.GetPaymentEventLog
{
    public class Amount
    {
        [property: JsonProperty("currency")]
        public string Currency { get; set; }

        [property: JsonProperty("value")]
        public int Value { get; set; }
    }

    public class GetPaymentEventLog
    {
        [property: JsonProperty("reference")]
        public string Reference { get; set; }

        [property: JsonProperty("pspReference")]
        public string PspReference { get; set; }

        [property: JsonProperty("name")]
        public string Name { get; set; }

        [property: JsonProperty("paymentAction")]
        public string PaymentAction { get; set; }

        [property: JsonProperty("amount")]
        public Amount Amount { get; set; }

        [property: JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [property: JsonProperty("processedAt")]
        public DateTime ProcessedAt { get; set; }

        [property: JsonProperty("idempotencyKey")]
        public string IdempotencyKey { get; set; }

        [property: JsonProperty("success")]
        public bool Success { get; set; }
    }
}
