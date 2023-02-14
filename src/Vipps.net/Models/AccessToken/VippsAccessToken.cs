using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.AccessToken
{
    public class AccessToken
    {
        public AccessToken(
            string tokenType,
            string expiresIn,
            string extExpiresIn,
            string expiresOn,
            string notBefore,
            string resource,
            string token
        )
        {
            TokenType = tokenType;
            ExpiresIn = expiresIn;
            ExtExpiresIn = extExpiresIn;
            ExpiresOn = expiresOn;
            NotBefore = notBefore;
            Resource = resource;
            Token = token;
        }

        [property: JsonPropertyName("token_type")]
        public string TokenType { get; private set; }

        [property: JsonPropertyName("expires_in")]
        public string ExpiresIn { get; private set; }

        [property: JsonPropertyName("ext_expires_in")]
        public string ExtExpiresIn { get; private set; }

        [property: JsonPropertyName("expires_on")]
        public string ExpiresOn { get; private set; }

        [property: JsonPropertyName("not_before")]
        public string NotBefore { get; private set; }

        [property: JsonPropertyName("resource")]
        public string Resource { get; private set; }

        [property: JsonPropertyName("access_token")]
        public string Token { get; private set; }
    }
}
