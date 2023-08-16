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
            var sessionInitiationRequest = new Models.Checkout.InitiateSessionRequest
            {
                Transaction = new Models.Checkout.PaymentTransaction
                {
                    Amount = new Models.Checkout.Amount { Currency = "NOK", Value = 1000 },
                    Reference = reference,
                    PaymentDescription = nameof(CheckoutServiceTests.Can_Create_And_Get_Session),
                },
                MerchantInfo = new Models.Checkout.PaymentMerchantInfo
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
                Models.Checkout.ExternalSessionState.SessionCreated,
                sessionPolledResponse.SessionState
            );
        }
    }
}
