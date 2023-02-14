using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.GetPaymentResponse
{
    public class GetPaymentResponse : VippsResponse
    {
        [property: JsonPropertyName("aggregate")]
        public Aggregate Aggregate { get; set; }

        [property: JsonPropertyName("amount")]
        public Amount Amount { get; set; }

        [property: JsonPropertyName("state")]
        public string State { get; set; }

        [property: JsonPropertyName("paymentMethod")]
        public PaymentMethod PaymentMethod { get; set; }

        [property: JsonPropertyName("profile")]
        public Profile Profile { get; set; }

        [property: JsonPropertyName("pspReference")]
        public string PspReference { get; set; }

        [property: JsonPropertyName("redirectUrl")]
        public string RedirectUrl { get; set; }

        [property: JsonPropertyName("reference")]
        public string Reference { get; set; }
    }

    public class Aggregate
    {
        [property: JsonPropertyName("authorizedAmount")]
        public AuthorizedAmount AuthorizedAmount { get; set; }

        [property: JsonPropertyName("cancelledAmount")]
        public CancelledAmount CancelledAmount { get; set; }

        [property: JsonPropertyName("capturedAmount")]
        public CapturedAmount CapturedAmount { get; set; }

        [property: JsonPropertyName("refundedAmount")]
        public RefundedAmount RefundedAmount { get; set; }
    }

    public class AuthorizedAmount
    {
        [property: JsonPropertyName("currency")]
        public string Currency { get; set; }

        [property: JsonPropertyName("value")]
        public int? Value { get; set; }
    }

    public class CancelledAmount
    {
        [property: JsonPropertyName("currency")]
        public string Currency { get; set; }

        [property: JsonPropertyName("value")]
        public int? Value { get; set; }
    }

    public class CapturedAmount
    {
        [property: JsonPropertyName("currency")]
        public string Currency { get; set; }

        [property: JsonPropertyName("value")]
        public int? Value { get; set; }
    }

    public class RefundedAmount
    {
        [property: JsonPropertyName("currency")]
        public string Currency { get; set; }

        [property: JsonPropertyName("value")]
        public int? Value { get; set; }
    }

    public class Amount
    {
        [property: JsonPropertyName("currency")]
        public string Currency { get; set; }

        [property: JsonPropertyName("value")]
        public int? Value { get; set; }
    }

    public class PaymentMethod
    {
        [property: JsonPropertyName("type")]
        public string Type { get; set; }

        [property: JsonPropertyName("cardBin")]
        public string CardBin { get; set; }
    }

    public class Profile
    {
        [property: JsonPropertyName("sub")]
        public string Sub { get; set; }
    }
}
