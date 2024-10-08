using Vipps.net.Models.Checkout;
using Vipps.net.Models.Checkout.Model;

namespace Vipps.net.IntegrationTests
{
    [TestClass]
    public class CheckoutServiceTests
    {
        [TestMethod]
        public async Task Can_Create_And_Get_Session()
        {
            var vippsApi = TestSetup.CreateVippsAPI();
            var reference = Guid.NewGuid().ToString();
            var sessionInitiationRequest = new InitiatePaymentSessionRequest
            {
                Transaction = new PaymentTransaction
                {
                    Amount = new Amount { Currency = "NOK", Value = 1000 },
                    Reference = reference,
                    PaymentDescription = nameof(Can_Create_And_Get_Session),
                },
                MerchantInfo = new MerchantInfo
                {
                    CallbackAuthorizationToken = Guid.NewGuid().ToString(),
                    CallbackUrl = "https://no.where.com/callback",
                    ReturnUrl = "https://no.where.com/return",
                    TermsAndConditionsUrl = "https://no.where.com/terms"
                }
            };

            var sessionResponse = await vippsApi.CheckoutService.InitiateSession(
                sessionInitiationRequest
            );
            Assert.IsNotNull(sessionResponse);
            var sessionPolledResponse = await vippsApi.CheckoutService.GetSessionInfo(reference);
            Assert.AreEqual(
                ExternalSessionState.SessionCreated,
                sessionPolledResponse.SessionState
            );
        }
    }
}
