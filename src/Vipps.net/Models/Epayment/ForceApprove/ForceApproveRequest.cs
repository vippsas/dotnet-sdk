using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.ForceApprove
{
    public class ForceApproveRequest
    {
        [property: JsonPropertyName("customer")] public Customer Customer { get; init; }
        [property: JsonPropertyName("token")] public string Token { get; init; }
    }

    public class Customer
    {
        [property: JsonPropertyName("phoneNumber")] public long PhoneNumber { get; init; }
    }
}
