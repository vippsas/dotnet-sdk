using System.Text.Json.Serialization;

namespace Vipps.Models
{
    public class VippsRequest
    {
        [JsonIgnore]
        public dynamic? ExtraParameters { get; set; }
    }
}
