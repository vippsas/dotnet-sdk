using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.CancelPayment;

public class CancelPaymentResponse : VippsResponse
{
    [property: JsonPropertyName("amount")]
    public Amount Amount { get; init; }

    [property: JsonPropertyName("state")]
    public string State { get; init; }

    [property: JsonPropertyName("aggregate")]
    public Aggregate Aggregate { get; init; }

    [property: JsonPropertyName("pspReference")]
    public string PspReference { get; init; }

    [property: JsonPropertyName("reference")]
    public string Reference { get; init; }
}

public class Aggregate
{
    [property: JsonPropertyName("authorizedAmount")]
    public AuthorizedAmount AuthorizedAmount { get; init; }

    [property: JsonPropertyName("cancelledAmount")]
    public CancelledAmount CancelledAmount { get; init; }

    [property: JsonPropertyName("capturedAmount")]
    public CapturedAmount CapturedAmount { get; init; }

    [property: JsonPropertyName("refundedAmount")]
    public RefundedAmount RefundedAmount { get; init; }
}

public class Amount
{
    [property: JsonPropertyName("currency")]
    public string Currency { get; init; }

    [property: JsonPropertyName("value")]
    public int Value { get; init; }
}

public class AuthorizedAmount
{
    [property: JsonPropertyName("currency")]
    public string Currency { get; init; }

    [property: JsonPropertyName("value")]
    public int Value { get; init; }
}

public class CancelledAmount
{
    [property: JsonPropertyName("currency")]
    public string Currency { get; init; }

    [property: JsonPropertyName("value")]
    public int Value { get; init; }
}

public class CapturedAmount
{
    [property: JsonPropertyName("currency")]
    public string Currency { get; init; }

    [property: JsonPropertyName("value")]
    public int Value { get; init; }
}

public class RefundedAmount
{
    [property: JsonPropertyName("currency")]
    public string Currency { get; init; }

    [property: JsonPropertyName("value")]
    public int Value { get; init; }
}
