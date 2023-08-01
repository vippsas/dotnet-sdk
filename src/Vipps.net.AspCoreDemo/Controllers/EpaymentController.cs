using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vipps.net.Models.Epayment;
using Vipps.net.Services;

namespace Vipps.net.AspCore31Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EpaymentController
    {
        private readonly IVippsEpaymentService _epaymentService;

        public EpaymentController(IVippsApi vippsApi)
        {
            _epaymentService = vippsApi.EpaymentService();
        }

        [HttpPost]
        public async Task<string> CreatePayment()
        {
            var request = new CreatePaymentRequest
            {
                Amount = new Amount { Value = 1000, Currency = Currency.NOK },
                PaymentMethod = new PaymentMethod { Type = PaymentMethodType.WALLET },
                Customer = new Customer { },
                Reference = Guid.NewGuid().ToString(),
                UserFlow = CreatePaymentRequestUserFlow.WEB_REDIRECT,
                ReturnUrl = $"http://localhost:3000",
                PaymentDescription = "paymentDescription",
                Profile = new ProfileRequest { Scope = "name phoneNumber address birthDate email" },
            };

            var result = await _epaymentService.CreatePayment(request);
            return result?.RedirectUrl.ToString();
        }
    }
}
