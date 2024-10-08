using Vipps.net.Models.Epayment.Model;

namespace Vipps.net.IntegrationTests
{
    [TestClass]
    public class EpaymentServiceTests
    {
        private const string CustomerPhoneNumber = "4747753942";

        [TestMethod]
        public async Task Can_Create_Get_Cancel_Payment()
        {
            var vippsApi = TestSetup.CreateVippsAPI();
            var reference = Guid.NewGuid().ToString();
            var createPaymentRequest = GetCreatePaymentRequest(reference);

            var createPaymentResponse = await vippsApi.EpaymentService.CreatePayment(
                createPaymentRequest
            );
            Assert.IsNotNull(createPaymentResponse);
            Assert.AreEqual(reference, createPaymentResponse.Reference);

            var modificationResponse = await vippsApi.EpaymentService.CancelPayment(reference);
            Assert.IsNotNull(modificationResponse);
            Assert.AreEqual(reference, modificationResponse.Reference);
            Assert.AreEqual(State.TERMINATED, modificationResponse.State);

            var getPaymentResponse = await vippsApi.EpaymentService.GetPayment(reference);
            Assert.AreEqual(reference, getPaymentResponse.Reference);
            Assert.AreEqual(State.TERMINATED, getPaymentResponse.State);
        }

        [TestMethod]
        public async Task Can_Create_Approve_Capture_Refund_Payment()
        {
            IVippsApi vippsApi = TestSetup.CreateVippsAPI();
            var reference = Guid.NewGuid().ToString();
            var createPaymentRequest = GetCreatePaymentRequest(reference);

            var createPaymentResponse = await vippsApi.EpaymentService.CreatePayment(
                createPaymentRequest
            );
            Assert.IsNotNull(createPaymentResponse);
            Assert.AreEqual(reference, createPaymentResponse.Reference);

            await vippsApi.EpaymentService.ForceApprovePayment(
                reference,
                new ForceApprove
                {
                    Customer = new Customer(
                        new CustomerPhoneNumber { PhoneNumber = CustomerPhoneNumber }
                    )
                }
            );

            var captureResponse = await vippsApi.EpaymentService.CapturePayment(
                reference,
                new CaptureModificationRequest { ModificationAmount = createPaymentRequest.Amount }
            );
            Assert.IsNotNull(captureResponse);
            Assert.AreEqual(reference, captureResponse.Reference);
            Assert.AreEqual(State.AUTHORIZED, captureResponse.State);

            var refundResponse = await vippsApi.EpaymentService.RefundPayment(
                reference,
                new RefundModificationRequest { ModificationAmount = createPaymentRequest.Amount }
            );
            Assert.IsNotNull(refundResponse);
            Assert.AreEqual(reference, refundResponse.Reference);
            Assert.AreEqual(State.AUTHORIZED, refundResponse.State);

            var paymentEvents = await vippsApi.EpaymentService.GetPaymentEventLog(reference);
            Assert.IsNotNull(paymentEvents);
            AssertOneEvent(paymentEvents, PaymentEventName.CREATED);
            AssertOneEvent(paymentEvents, PaymentEventName.CAPTURED);
            AssertOneEvent(paymentEvents, PaymentEventName.REFUNDED);
            AssertOneEvent(paymentEvents, PaymentEventName.AUTHORIZED);
        }

        private static void AssertOneEvent(
            IEnumerable<PaymentEvent> paymentEvents,
            PaymentEventName paymentEventName
        )
        {
            Assert.AreEqual(1, paymentEvents.Count(r => r.Name == paymentEventName));
        }

        private static CreatePaymentRequest GetCreatePaymentRequest(string reference)
        {
            return new CreatePaymentRequest(
                new Amount
                {
                    Currency = Currency.NOK,
                    Value = 100 // 100 øre = 1 KR
                },
                new Customer(new CustomerPhoneNumber { PhoneNumber = CustomerPhoneNumber }),
                null,
                null,
                null,
                new PaymentMethod { Type = PaymentMethodType.WALLET },
                null,
                reference,
                $"https://no.where.com/{reference}",
                CreatePaymentRequest.UserFlowEnum.WEB_REDIRECT,
                null,
                null,
                nameof(CheckoutServiceTests.Can_Create_And_Get_Session)
            );
        }
    }
}
