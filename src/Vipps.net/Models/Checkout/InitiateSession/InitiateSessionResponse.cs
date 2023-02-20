using Newtonsoft.Json;

namespace Vipps.Models.Checkout.InitiateSession
{
    public class InitiateSessionResponse : VippsResponse
    {
        [property: JsonProperty("token")]
        public string Token { get; set; }

        [property: JsonProperty("checkoutFrontendUrl")]
        public string CheckoutFrontendUrl { get; set; }

        [property: JsonProperty("pollingUrl")]
        public string PollingUrl { get; set; }
    }
}
