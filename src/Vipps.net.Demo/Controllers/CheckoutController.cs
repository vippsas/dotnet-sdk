using Microsoft.AspNetCore.Mvc;
using Vipps.Models.Checkout.InitiateSession;
using Vipps.Services;

namespace Vipps.net.Demo.Controllers
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
