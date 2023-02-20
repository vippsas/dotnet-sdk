using Newtonsoft.Json;

namespace Vipps.Models.Epayment.CreatePayment
{
    public class CreatePaymentResponse : VippsResponse
    {
        [property: JsonProperty("redirectUrl")]
        public string RedirectUrl { get; set; }

        [property: JsonProperty("reference")]
        public string Reference { get; set; }
    }
}
