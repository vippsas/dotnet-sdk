using System;
using System.Threading.Tasks;
using Vipps.Models.Checkout.InitiateSession;
using Vipps.Services;

namespace Vipps.net.WindowsFormsDemo
{
    internal static class CheckoutSessionCreator
    {
        internal static async Task<string> CreateSession()
        {
            var request = new InitiateSessionRequest(
                new PaymentMerchantInfo(
                    "https://your-url-here.com:3000",
                    "https://your-url-here.com:3000",
                    Guid.NewGuid().ToString(),
                    "https://your-url-here.com:3000"
                ),
                new PaymentTransaction(
                    new Amount(10000, "NOK"),
                    Guid.NewGuid().ToString(),
                    "test",
                    null
                ),
                null,
                null,
                null
            );

            var result = await CheckoutService.InitiateSession(request);
            return result.PollingUrl;
        }
    }
}
