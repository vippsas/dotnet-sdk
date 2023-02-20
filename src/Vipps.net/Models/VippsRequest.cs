using Newtonsoft.Json;

namespace Vipps.Models
{
    public class VippsRequest
    {
        [JsonIgnore]
        public dynamic ExtraParameters { get; set; }
    }
}
