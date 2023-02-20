using Newtonsoft.Json;

namespace Vipps.Models.Epayment.CancelPayment
{
    public class CancelPaymentResponse : VippsResponse
    {
        [property: JsonProperty("amount")]
        public Amount Amount { get; set; }

        [property: JsonProperty("state")]
        public string State { get; set; }

        [property: JsonProperty("aggregate")]
        public Aggregate Aggregate { get; set; }

        [property: JsonProperty("pspReference")]
        public string PspReference { get; set; }

        [property: JsonProperty("reference")]
        public string Reference { get; set; }
    }

    public class Aggregate
    {
        [property: JsonProperty("authorizedAmount")]
        public AuthorizedAmount AuthorizedAmount { get; set; }

        [property: JsonProperty("cancelledAmount")]
        public CancelledAmount CancelledAmount { get; set; }

        [property: JsonProperty("capturedAmount")]
        public CapturedAmount CapturedAmount { get; set; }

        [property: JsonProperty("refundedAmount")]
        public RefundedAmount RefundedAmount { get; set; }
    }

    public class Amount
    {
        [property: JsonProperty("currency")]
        public string Currency { get; set; }

        [property: JsonProperty("value")]
        public int Value { get; set; }
    }

    public class AuthorizedAmount
    {
        [property: JsonProperty("currency")]
        public string Currency { get; set; }

        [property: JsonProperty("value")]
        public int Value { get; set; }
    }

    public class CancelledAmount
    {
        [property: JsonProperty("currency")]
        public string Currency { get; set; }

        [property: JsonProperty("value")]
        public int Value { get; set; }
    }

    public class CapturedAmount
    {
        [property: JsonProperty("currency")]
        public string Currency { get; set; }

        [property: JsonProperty("value")]
        public int Value { get; set; }
    }

    public class RefundedAmount
    {
        [property: JsonProperty("currency")]
        public string Currency { get; set; }

        [property: JsonProperty("value")]
        public int Value { get; set; }
    }
}
