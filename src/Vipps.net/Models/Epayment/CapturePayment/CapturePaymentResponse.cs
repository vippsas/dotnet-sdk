using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.CapturePayment
{
    public record CapturePaymentResponse(
        [property: JsonPropertyName("amount")] Amount Amount,
        [property: JsonPropertyName("state")] string State,
        [property: JsonPropertyName("aggregate")] Aggregate Aggregate,
        [property: JsonPropertyName("pspReference")] string PspReference,
        [property: JsonPropertyName("reference")] string Reference
    );

    public record Aggregate(
        [property: JsonPropertyName("authorizedAmount")] AuthorizedAmount AuthorizedAmount,
        [property: JsonPropertyName("cancelledAmount")] CancelledAmount CancelledAmount,
        [property: JsonPropertyName("capturedAmount")] CapturedAmount CapturedAmount,
        [property: JsonPropertyName("refundedAmount")] RefundedAmount RefundedAmount
    );

    public record Amount(
        [property: JsonPropertyName("currency")] string Currency,
        [property: JsonPropertyName("value")] int Value
    );

    public record AuthorizedAmount(
        [property: JsonPropertyName("currency")] string Currency,
        [property: JsonPropertyName("value")] int Value
    );

    public record CancelledAmount(
        [property: JsonPropertyName("currency")] string Currency,
        [property: JsonPropertyName("value")] int Value
    );

    public record CapturedAmount(
        [property: JsonPropertyName("currency")] string Currency,
        [property: JsonPropertyName("value")] int Value
    );

    public record RefundedAmount(
        [property: JsonPropertyName("currency")] string Currency,
        [property: JsonPropertyName("value")] int Value
    );
}
