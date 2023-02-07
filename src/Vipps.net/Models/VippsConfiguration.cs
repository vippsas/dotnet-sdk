namespace Vipps.Models
{
    public class VippsConfiguration
    {
        public string ClientId { get; init; }
        public string ClientSecret { get; init; }
        public string SubscriptionKey { get; init; }
        public string MerchantSerialNumber { get; init; }
        public bool TestMode { get; init; } = false;
        public string BaseUrl => TestMode ? "https://api-test.vipps.no" : "https://api.vipps.no";
    }
}
