
using Vipps.net;
using Vipps.net.Infrastructure;
using Checkout = Vipps.net.Models.Checkout;
using Epayment = Vipps.net.Models.Epayment;

const string CustomerPhoneNumber = "YOUR-TEST-PHONENUMBER";

var vippsConfigurationOptions = new VippsConfigurationOptions
{
    ClientId = "YOUR-CLIENT-ID",
    ClientSecret = "YOUR-SECRET",
    MerchantSerialNumber = "YOUR-MSN",
    SubscriptionKey = "YOUR-SUBSCRIPTION-KEY",
    PluginName = "acme-plugin",
    PluginVersion = "1.0",
    UseTestMode = true
};

var vippsApi = new VippsApi(vippsConfigurationOptions);

var checkoutRequest = new Checkout.InitiateSessionRequest
{
    MerchantInfo = new Checkout.PaymentMerchantInfo
    {
        CallbackAuthorizationToken = Guid.NewGuid().ToString(),
        CallbackUrl = "https://example.com/callbacks-for-checkout",
        ReturnUrl = "https://example.com/fallback-result-page-for-both-success-and-failure",
    },
    Transaction = new Checkout.PaymentTransaction
    {
        Amount = new Checkout.Amount { Currency = "NOK", Value = 10000 },
        PaymentDescription = "Checkout description",
        Reference = Guid.NewGuid().ToString()
    }
};

var checkoutResult = await vippsApi.CheckoutService.InitiateSession(checkoutRequest);

Console.WriteLine("Here is the response from the checkout service:");
Console.WriteLine("Token:" + checkoutResult.Token);
Console.WriteLine("AdditionalProperties:" + checkoutResult.AdditionalProperties);
Console.WriteLine("PollingUrl:" + checkoutResult.PollingUrl);
Console.WriteLine("CheckoutFrontendUrl:" + checkoutResult.CheckoutFrontendUrl);


var ePaymentReference = Guid.NewGuid().ToString();

var epaymentRequest = new Epayment.CreatePaymentRequest
{
    Amount = new Epayment.Amount
    {
        Currency = Epayment.Currency.NOK,
        Value = 100 // 100 øre = 1 KR
    },
    PaymentMethod = new Epayment.PaymentMethod { Type = Epayment.PaymentMethodType.WALLET },
    UserFlow = Epayment.CreatePaymentRequestUserFlow.WEB_REDIRECT,
    Reference = ePaymentReference,
    PaymentDescription = "Pair of socks",
    ReturnUrl = "https://example.com/fallback-result-page-for-both-success-and-failure",
    Customer = new Epayment.Customer { PhoneNumber = CustomerPhoneNumber }
};

var epaymentResult = await vippsApi.EpaymentService.CreatePayment(epaymentRequest);

Console.WriteLine("Open this link and approve the payment:" + epaymentResult.RedirectUrl);



