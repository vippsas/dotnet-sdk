using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.ForceApprove
{
    public record ForceApproveRequest(
        [property: JsonPropertyName("customer")] Customer Customer,
        [property: JsonPropertyName("token")] string Token
    );

    public record Customer(
        [property: JsonPropertyName("phoneNumber")] long PhoneNumber
    );
}
