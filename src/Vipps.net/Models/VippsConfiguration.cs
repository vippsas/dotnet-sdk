namespace Vipps.Models
{
    public class VippsConfiguration
    {
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? SubscriptionKey { get; set; }
        public string? MerchantSerialNumber { get; set; }
        internal string BaseUrl { get; set; } = "https://api.vipps.no";
    }
}
