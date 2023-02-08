namespace Vipps.Models
{
    public class VippsConfiguration
    {
        public string ClientId { get; init; }
        public string ClientSecret { get; init; }
        public string SubscriptionKey { get; init; }
        public string MerchantSerialNumber { get; init; }
        public bool TestMode { get; init; } = false;
        public string BaseUrl => TestMode ? "https://ece46ec4-6f9c-489b-8fe5-146a89e11635.tech-02.net" : "https://api.vipps.no";
    }
}
