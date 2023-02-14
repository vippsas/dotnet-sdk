using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.GetPaymentResponse
{
    public class GetPaymentResponse : VippsResponse
    {
        [property: JsonPropertyName("aggregate")]
        public Aggregate Aggregate { get; private set; }

        [property: JsonPropertyName("amount")]
        public Amount Amount { get; private set; }

        [property: JsonPropertyName("state")]
        public string State { get; private set; }

        [property: JsonPropertyName("paymentMethod")]
        public PaymentMethod PaymentMethod { get; private set; }

        [property: JsonPropertyName("profile")]
        public Profile Profile { get; private set; }

        [property: JsonPropertyName("pspReference")]
        public string PspReference { get; private set; }

        [property: JsonPropertyName("redirectUrl")]
        public string RedirectUrl { get; private set; }

        [property: JsonPropertyName("reference")]
        public string Reference { get; private set; }
    }

    public class Aggregate
    {
        [property: JsonPropertyName("authorizedAmount")]
        public AuthorizedAmount AuthorizedAmount { get; private set; }

        [property: JsonPropertyName("cancelledAmount")]
        public CancelledAmount CancelledAmount { get; private set; }

        [property: JsonPropertyName("capturedAmount")]
        public CapturedAmount CapturedAmount { get; private set; }

        [property: JsonPropertyName("refundedAmount")]
        public RefundedAmount RefundedAmount { get; private set; }
    }

    public class AuthorizedAmount
    {
        [property: JsonPropertyName("currency")]
        public string Currency { get; private set; }

        [property: JsonPropertyName("value")]
        public int? Value { get; private set; }
    }

    public class CancelledAmount
    {
        [property: JsonPropertyName("currency")]
        public string Currency { get; private set; }

        [property: JsonPropertyName("value")]
        public int? Value { get; private set; }
    }

    public class CapturedAmount
    {
        [property: JsonPropertyName("currency")]
        public string Currency { get; private set; }

        [property: JsonPropertyName("value")]
        public int? Value { get; private set; }
    }

    public class RefundedAmount
    {
        [property: JsonPropertyName("currency")]
        public string Currency { get; private set; }

        [property: JsonPropertyName("value")]
        public int? Value { get; private set; }
    }

    public class Amount
    {
        [property: JsonPropertyName("currency")]
        public string Currency { get; private set; }

        [property: JsonPropertyName("value")]
        public int? Value { get; private set; }
    }

    public class PaymentMethod
    {
        [property: JsonPropertyName("type")]
        public string Type { get; private set; }

        [property: JsonPropertyName("cardBin")]
        public string CardBin { get; private set; }
    }

    public class Profile
    {
        [property: JsonPropertyName("sub")]
        public string Sub { get; private set; }
    }
}
