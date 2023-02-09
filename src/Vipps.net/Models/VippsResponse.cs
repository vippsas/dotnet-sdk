using System.Text.Json.Serialization;

namespace Vipps.Models
{
    public class VippsResponse
    {
        [JsonIgnore]
        public dynamic? ExtraParameters { get; set; }
    }
}
