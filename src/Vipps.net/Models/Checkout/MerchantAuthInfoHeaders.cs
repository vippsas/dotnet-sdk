using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Vipps.Models.Checkout
{
    /// <summary>
    /// Headers required to retrieve an access token.
    /// </summary>
    /// <param name="ClientId">Client ID for the merchant (the "username"). Found in the Vipps portal. Example: "fb492b5e-7907-4d83-bc20-c7fb60ca35de".</param>
    /// <param name="ClientSecret">Client Secret for the merchant (the "password"). Found in the Vipps portal. Example: "Y8Kteew6GE3ZmeycEt6egg==".</param>
    /// <param name="OcpApimSubscriptionKey">Vipps Subscription key for the API product. Found in the Vipps portal. Example: "0f14ebcab0eb4b29ae0cb90d91b4a84a".</param>
    /// <param name="MerchantSerialNumber">Vipps assigned unique number for a merchant. Found in the Vipps portal. Example: "123456".</param>
    public record MerchantAuthInfoHeaders(
        [property: JsonPropertyName("client_id")] string ClientId,
        [property: JsonPropertyName("client_secret")] string ClientSecret,
        [property: JsonPropertyName("Ocp-Apim-Subscription-Key")] string OcpApimSubscriptionKey,
        [property: JsonPropertyName("Merchant-Serial-Number")] string MerchantSerialNumber
    );
}
