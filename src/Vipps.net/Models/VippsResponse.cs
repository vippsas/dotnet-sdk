using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vipps.Models
{
    public class VippsResponse
    {
        [JsonIgnore]
        public JsonElement RawResponse { get; set; }
    }
}
