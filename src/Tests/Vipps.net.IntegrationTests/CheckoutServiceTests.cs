using Vipps.net.Services;

namespace Vipps.net.IntegrationTests
{
    [TestClass]
    public class CheckoutServiceTests
    {
        [TestMethod]
        public async Task Can_Create_And_Get_Session()
        {
            var reference = Guid.NewGuid().ToString();
            var sessionInitiationRequest = new Models.Autogen.Checkout.InitiateSessionRequest
            {
                Transaction = new Models.Autogen.Checkout.PaymentTransaction
                {
                    Amount = new Models.Autogen.Checkout.Amount { Currency = "NOK", Value = 1000 },
                    Reference = reference,
                    PaymentDescription = nameof(CheckoutServiceTests.Can_Create_And_Get_Session),
                },
                MerchantInfo = new Models.Autogen.Checkout.PaymentMerchantInfo
                {
                    CallbackAuthorizationToken = Guid.NewGuid().ToString(),
                    CallbackUrl = "https://no.where.com/callback",
                    ReturnUrl = "https://no.where.com/return",
                    TermsAndConditionsUrl = "https://no.where.com/terms"
                }
            };

            var sessionResponse = await CheckoutService.InitiateSession(sessionInitiationRequest);
            Assert.IsNotNull(sessionResponse);
            var sessionPolledResponse = await CheckoutService.GetSessionInfo(reference);
            Assert.AreEqual(
                Models.Autogen.Checkout.ExternalSessionState.SessionCreated,
                sessionPolledResponse.SessionState
            );
        }
    }
}
