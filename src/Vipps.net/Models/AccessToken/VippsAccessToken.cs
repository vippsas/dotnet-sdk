using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.AccessToken
{
    public record AccessToken(
        [property: JsonPropertyName("token_type")] string TokenType,
        [property: JsonPropertyName("expires_in")] string ExpiresIn,
        [property: JsonPropertyName("ext_expires_in")] string ExtExpiresIn,
        [property: JsonPropertyName("expires_on")] string ExpiresOn,
        [property: JsonPropertyName("not_before")] string NotBefore,
        [property: JsonPropertyName("resource")] string Resource,
        [property: JsonPropertyName("access_token")] string Token
    );

}
