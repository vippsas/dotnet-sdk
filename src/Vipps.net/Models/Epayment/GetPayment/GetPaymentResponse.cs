using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.GetPaymentResponse
{
    public record Aggregate(
        [property: JsonPropertyName("authorizedAmount")] AuthorizedAmount AuthorizedAmount,
        [property: JsonPropertyName("cancelledAmount")] CancelledAmount CancelledAmount,
        [property: JsonPropertyName("capturedAmount")] CapturedAmount CapturedAmount,
        [property: JsonPropertyName("refundedAmount")] RefundedAmount RefundedAmount
    );


    public record AuthorizedAmount(
        [property: JsonPropertyName("currency")] string Currency,
        [property: JsonPropertyName("value")] int? Value
    );

    public record CancelledAmount(
        [property: JsonPropertyName("currency")] string Currency,
        [property: JsonPropertyName("value")] int? Value
    );

    public record CapturedAmount(
        [property: JsonPropertyName("currency")] string Currency,
        [property: JsonPropertyName("value")] int? Value
    );


    public record RefundedAmount(
        [property: JsonPropertyName("currency")] string Currency,
        [property: JsonPropertyName("value")] int? Value
    );

    public record GetPaymentResponse(
        [property: JsonPropertyName("aggregate")] Aggregate Aggregate,
        [property: JsonPropertyName("amount")] Amount Amount,
        [property: JsonPropertyName("state")] string State,
        [property: JsonPropertyName("paymentMethod")] PaymentMethod PaymentMethod,
        [property: JsonPropertyName("profile")] Profile Profile,
        [property: JsonPropertyName("pspReference")] string PspReference,
        [property: JsonPropertyName("redirectUrl")] string RedirectUrl,
        [property: JsonPropertyName("reference")] string Reference
    );

    public record Amount(
        [property: JsonPropertyName("currency")] string Currency,
        [property: JsonPropertyName("value")] int? Value
    );

    public record PaymentMethod(
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("cardBin")] string CardBin
    );

    public record Profile(
        [property: JsonPropertyName("sub")] string Sub
    );

}
