using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vipps.net.Models.Checkout;
using Vipps.net.Services;

namespace Vipps.net.AspCore31Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly ILogger<CheckoutController> _logger;

        public CheckoutController(ILogger<CheckoutController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<InitiateSessionResponse>> CreateSession()
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

            _logger.LogInformation(
                "Creating session with reference {reference}",
                request.Transaction.Reference
            );

            var result = await CheckoutService.InitiateSession(request);

            _logger.LogInformation(
                "Created session with reference {reference}",
                request.Transaction.Reference
            );
            return Ok(result);
        }
    }
}
