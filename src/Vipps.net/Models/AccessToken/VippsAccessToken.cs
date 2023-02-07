using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.AccessToken
{
    public class AccessToken
    {
        [property: JsonPropertyName("token_type")] public string TokenType { get; init; }
        [property: JsonPropertyName("expires_in")] public string ExpiresIn { get; init; }
        [property: JsonPropertyName("ext_expires_in")] public string ExtExpiresIn { get; init; }
        [property: JsonPropertyName("expires_on")] public string ExpiresOn { get; init; }
        [property: JsonPropertyName("not_before")] public string NotBefore { get; init; }
        [property: JsonPropertyName("resource")] public string Resource { get; init; }
        [property: JsonPropertyName("access_token")] public string Token { get; init; }
    }
}
