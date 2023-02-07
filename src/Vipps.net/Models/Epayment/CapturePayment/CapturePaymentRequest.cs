using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.CapturePayment
{
    public class CapturePaymentRequest
    {
        [property: JsonPropertyName("modificationAmount")] public ModificationAmount ModificationAmount { get; init; }
    }

    public class ModificationAmount
    {
        [property: JsonPropertyName("currency")] public string Currency { get; init; }
        [property: JsonPropertyName("value")] public int Value { get; init; }
    }
}
