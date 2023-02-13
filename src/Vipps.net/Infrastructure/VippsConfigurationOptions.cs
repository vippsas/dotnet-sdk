namespace Vipps.Infrastructure;

public class VippsConfigurationOptions
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string SubscriptionKey { get; set; }
    public string MerchantSerialNumber { get; set; }
    public bool UseTestMode { get; set; }
}
