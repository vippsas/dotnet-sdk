using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.ForceApprove
{
    public class ForceApproveRequest : VippsRequest
    {
        [property: JsonPropertyName("customer")]
        public Customer Customer { get; set; }

        [property: JsonPropertyName("token")]
        public string Token { get; set; }
    }

    public class Customer
    {
        [property: JsonPropertyName("phoneNumber")]
        public long PhoneNumber { get; set; }
    }
}
