using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Vipps.Models
{
    public class VippsResponse
    {
        [JsonIgnore]
        public JsonObject RawResponse { get; set; }
    }
}
