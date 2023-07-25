namespace Vipps.net.Helpers
{
    public class UrlHelper
    {
        public static string GetBaseUrl(bool isTestMode)
        {
            return isTestMode ? "https://apitest.vipps.no" : "https://api.vipps.no";
        }
    }
}
