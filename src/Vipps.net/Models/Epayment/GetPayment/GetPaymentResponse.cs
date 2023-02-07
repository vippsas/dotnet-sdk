using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.GetPaymentResponse
{
    public class Aggregate
    {
        [property: JsonPropertyName("authorizedAmount")] public AuthorizedAmount AuthorizedAmount { get; init; }
        [property: JsonPropertyName("cancelledAmount")] public CancelledAmount CancelledAmount { get; init; }
        [property: JsonPropertyName("capturedAmount")] public CapturedAmount CapturedAmount { get; init; }
        [property: JsonPropertyName("refundedAmount")] public RefundedAmount RefundedAmount { get; init; }
    }


    public class AuthorizedAmount
    {
        [property: JsonPropertyName("currency")] public string Currency { get; init; }
        [property: JsonPropertyName("value")] public int? Value { get; init; }
    }

    public class CancelledAmount
    {
        [property: JsonPropertyName("currency")] public string Currency { get; init; }
        [property: JsonPropertyName("value")] public int? Value { get; init; }
    }

    public class CapturedAmount
    {
        [property: JsonPropertyName("currency")] public string Currency { get; init; }
        [property: JsonPropertyName("value")] public int? Value { get; init; }
    }


    public class RefundedAmount
    {
        [property: JsonPropertyName("currency")] public string Currency { get; init; }
        [property: JsonPropertyName("value")] public int? Value { get; init; }
    }

    public class GetPaymentResponse
    {
        [property: JsonPropertyName("aggregate")] public Aggregate Aggregate { get; init; }
        [property: JsonPropertyName("amount")] public Amount Amount { get; init; }
        [property: JsonPropertyName("state")] public string State { get; init; }
        [property: JsonPropertyName("paymentMethod")] public PaymentMethod PaymentMethod { get; init; }
        [property: JsonPropertyName("profile")] public Profile Profile { get; init; }
        [property: JsonPropertyName("pspReference")] public string PspReference { get; init; }
        [property: JsonPropertyName("redirectUrl")] public string RedirectUrl { get; init; }
        [property: JsonPropertyName("reference")] public string Reference { get; init; }
    }

    public class Amount
    {
        [property: JsonPropertyName("currency")] public string Currency { get; init; }
        [property: JsonPropertyName("value")] public int? Value { get; init; }
    }

    public class PaymentMethod
    {
        [property: JsonPropertyName("type")] public string Type { get; init; }
        [property: JsonPropertyName("cardBin")] public string CardBin { get; init; }
    }

    public class Profile
    {
        [property: JsonPropertyName("sub")]
        public string Sub { get; init; }
    }

}
