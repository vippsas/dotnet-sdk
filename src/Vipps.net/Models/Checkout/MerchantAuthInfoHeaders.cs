using System.Text.Json.Serialization;

namespace Vipps.Models.Checkout;

/// <summary>
/// Headers required to retrieve an access token.
/// </summary>
public class MerchantAuthInfoHeaders
{
    /// <summary>
    /// Client ID for the merchant (the "username"). Found in the Vipps portal. Example: "fb492b5e-7907-4d83-bc20-c7fb60ca35de".
    /// </summary>
    [property: JsonPropertyName("client_id")]
    public string ClientId { get; init; }

    /// <summary>
    /// Client Secret for the merchant (the "password"). Found in the Vipps portal. Example: "Y8Kteew6GE3ZmeycEt6egg==".
    /// </summary>
    [property: JsonPropertyName("client_secret")]
    public string ClientSecret { get; init; }

    /// <summary>
    /// Vipps Subscription key for the API product. Found in the Vipps portal. Example: "0f14ebcab0eb4b29ae0cb90d91b4a84a".
    /// </summary>
    [property: JsonPropertyName("Ocp-Apim-Subscription-Key")]
    public string OcpApimSubscriptionKey { get; init; }

    /// <summary>
    /// Vipps assigned unique number for a merchant. Found in the Vipps portal. Example: "123456".
    /// </summary>
    [property: JsonPropertyName("Merchant-Serial-Number")]
    public string MerchantSerialNumber { get; init; }
}
