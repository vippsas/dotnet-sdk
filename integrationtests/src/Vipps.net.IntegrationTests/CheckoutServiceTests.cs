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
            var sessionInitiationRequest = new InitiatePaymentSessionRequest(
                new PaymentTransaction(
                    new Amount(1000, "NOK"),
                    reference,
                    nameof(Can_Create_And_Get_Session)
                ),
                null,
                "PAYMENT",
                null,
                new MerchantInfo(
                    "https://apitest.vipps.no/does-not-exist-callback",
                    "https://apitest.vipps.no/does-not-exist-return",
                    Guid.NewGuid().ToString(),
                    "https://apitest.vipps.no/does-not-exist-terms"
                )
            );

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
