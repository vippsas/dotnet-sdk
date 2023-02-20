using Newtonsoft.Json;

namespace Vipps.Models.Epayment.CapturePayment
{
    public class CapturePaymentRequest : VippsRequest
    {
        [property: JsonProperty("modificationAmount")]
        public ModificationAmount ModificationAmount { get; set; }
    }

    public class ModificationAmount
    {
        [property: JsonProperty("currency")]
        public string Currency { get; set; }

        [property: JsonProperty("value")]
        public int Value { get; set; }
    }
}
