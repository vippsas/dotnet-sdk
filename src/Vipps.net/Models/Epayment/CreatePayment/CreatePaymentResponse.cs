using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.CreatePayment
{
    public class CreatePaymentResponse : VippsResponse
    {
        [property: JsonPropertyName("redirectUrl")]
        public string RedirectUrl { get; private set; }

        [property: JsonPropertyName("reference")]
        public string Reference { get; private set; }
    }
}
