using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vipps.net.Models.Epayment.Model;
using Vipps.net.Services;
using Amount = Vipps.net.Models.Epayment.Model.Amount;
using PaymentMethod = Vipps.net.Models.Epayment.Model.PaymentMethod;

namespace Vipps.net.AspCoreDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EpaymentController
    {
        private readonly IVippsEpaymentService _epaymentService;

        public EpaymentController(IVippsApi vippsApi)
        {
            _epaymentService = vippsApi.EpaymentService;
        }

        [HttpPost]
        public async Task<string> CreatePayment()
        {
            var request = new CreatePaymentRequest
            {
                Amount = new Amount { Value = 1000, Currency = Currency.NOK },
                PaymentMethod = new PaymentMethod { Type = PaymentMethodType.WALLET },
                Customer = new Customer(new CustomerPhoneNumber { PhoneNumber = "4747375750" }),
                Reference = Guid.NewGuid().ToString(),
                UserFlow = CreatePaymentRequest.UserFlowEnum.WEB_REDIRECT,
                ReturnUrl = $"http://localhost:3000",
                PaymentDescription = "paymentDescription",
                Profile = new ProfileRequest { Scope = "name phoneNumber address birthDate email" }
            };

            var result = await _epaymentService.CreatePayment(request);
            return result?.RedirectUrl.ToString();
        }
    }
}
