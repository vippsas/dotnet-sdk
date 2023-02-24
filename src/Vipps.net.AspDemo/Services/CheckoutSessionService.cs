using System;
using System.Threading.Tasks;
using Vipps.Models.Autogen.Checkout;
using Vipps.Services;

namespace Vipps.net.AspDemo.Services
{
    internal static class CheckoutSessionService
    {
        internal static async Task<string> CreateSession()
        {
            var request = new InitiateSessionRequest
            {
                MerchantInfo = new PaymentMerchantInfo
                {
                    CallbackAuthorizationToken = Guid.NewGuid().ToString(),
                    CallbackUrl = "https://your-url-here.com:3000",
                    ReturnUrl = "https://your-url-here.com:3000",
                },
                Transaction = new PaymentTransaction
                {
                    Amount = new Amount { Currency = "NOK", Value = 10000 },
                    PaymentDescription = "test",
                    Reference = Guid.NewGuid().ToString()
                }
            };

            var result = await CheckoutService.InitiateSession(request);
            return result.PollingUrl;
        }
    }
}
