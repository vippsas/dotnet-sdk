namespace Vipps.net.Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly ILogger<CheckoutController> _logger;
        private readonly IOptions<VippsConfigurationSection> _options;
        private readonly HttpClient _httpClient;

        public CheckoutController(
            ILogger<CheckoutController> logger,
            IOptions<VippsConfigurationSection> vippsConfigurationOptions,
            HttpClient httpClient
        )
        {
            _logger = logger;
            _options = vippsConfigurationOptions;
            _httpClient = httpClient;
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

            var service = new CheckoutService(GetFromSection(), _httpClient);
            var result = await service.InitiateSession(request);

            _logger.LogInformation(
                "Created session with reference {reference}",
                request.Transaction.Reference
            );
            return Ok(result);
        }

        private VippsConfiguration GetFromSection()
        {
            return new VippsConfiguration
            {
                TestMode = _options.Value.UseTestMode,
                ClientId = _options.Value.ClientId,
                ClientSecret = _options.Value.ClientSecret,
                MerchantSerialNumber = _options.Value.MerchantSerialNumber,
                SubscriptionKey = _options.Value.SubscriptionKey,
            };
        }
    }
}
