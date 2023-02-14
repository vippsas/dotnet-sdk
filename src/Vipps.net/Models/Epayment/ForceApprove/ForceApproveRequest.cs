using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.ForceApprove
{
    public class ForceApproveRequest : VippsRequest
    {
        [property: JsonPropertyName("customer")]
        public Customer Customer { get; private set; }

        [property: JsonPropertyName("token")]
        public string Token { get; private set; }
    }

    public class Customer
    {
        [property: JsonPropertyName("phoneNumber")]
        public long PhoneNumber { get; private set; }
    }
}
