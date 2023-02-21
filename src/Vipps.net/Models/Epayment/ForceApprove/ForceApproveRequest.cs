using Newtonsoft.Json;

namespace Vipps.Models.Epayment.ForceApprove
{
    public class ForceApproveRequest : VippsRequest
    {
        [property: JsonProperty("customer")]
        public Customer Customer { get; set; }

        [property: JsonProperty("token")]
        public string Token { get; set; }
    }

    public class Customer
    {
        [property: JsonProperty("phoneNumber")]
        public long PhoneNumber { get; set; }
    }
}
