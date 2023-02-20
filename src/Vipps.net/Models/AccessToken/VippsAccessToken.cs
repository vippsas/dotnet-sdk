using Newtonsoft.Json;

namespace Vipps.Models.Epayment.AccessToken
{
    public class AccessToken
    {
        [property: JsonProperty("token_type")]
        public string TokenType { get; set; }

        [property: JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }

        [property: JsonProperty("ext_expires_in")]
        public string ExtExpiresIn { get; set; }

        [property: JsonProperty("expires_on")]
        public string ExpiresOn { get; set; }

        [property: JsonProperty("not_before")]
        public string NotBefore { get; set; }

        [property: JsonProperty("resource")]
        public string Resource { get; set; }

        [property: JsonProperty("access_token")]
        public string Token { get; set; }
    }
}
