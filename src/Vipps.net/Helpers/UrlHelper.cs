namespace Vipps.net.Helpers
{
    internal sealed class UrlHelper
    {
        internal static string GetBaseUrl(bool isTestMode)
        {
            return isTestMode ? "https://apitest.vipps.no" : "https://api.vipps.no";
        }
    }
}
