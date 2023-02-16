using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.AccessToken
{
    public class AccessToken
    {
        [property: JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [property: JsonPropertyName("expires_in")]
        public string ExpiresIn { get; set; }

        [property: JsonPropertyName("ext_expires_in")]
        public string ExtExpiresIn { get; set; }

        [property: JsonPropertyName("expires_on")]
        public string ExpiresOn { get; set; }

        [property: JsonPropertyName("not_before")]
        public string NotBefore { get; set; }

        [property: JsonPropertyName("resource")]
        public string Resource { get; set; }

        [property: JsonPropertyName("access_token")]
        public string Token { get; set; }
    }
}
