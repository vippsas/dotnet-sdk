using Vipps.net.Models.Autogen.Epayment;
using Vipps.net.Services;

namespace Vipps.net.IntegrationTests
{
    [TestClass]
    public class EpaymentServiceTests
    {
        private const string _customerPhoneNumber = "4747753942";

        [TestMethod]
        public async Task Can_Create_Get_Cancel_Payment()
        {
            var reference = Guid.NewGuid().ToString();
            var createPaymentRequest = GetCreatePaymentRequest(reference);

            var createPaymentResponse = await EpaymentService.CreatePayment(createPaymentRequest);
            Assert.IsNotNull(createPaymentResponse);
            Assert.AreEqual(reference, createPaymentResponse.Reference);

            var modificationResponse = await EpaymentService.CancelPayment(reference);
            Assert.IsNotNull(modificationResponse);
            Assert.AreEqual(reference, modificationResponse.Reference);
            Assert.AreEqual(State.TERMINATED, modificationResponse.State);

            var getPaymentResponse = await EpaymentService.GetPayment(reference);
            Assert.AreEqual(reference, getPaymentResponse.Reference);
            Assert.AreEqual(State.TERMINATED, getPaymentResponse.State);
        }

        [TestMethod]
        public async Task Can_Create_Approve_Capture_Refund_Payment()
        {
            var reference = Guid.NewGuid().ToString();
            var createPaymentRequest = GetCreatePaymentRequest(reference);

            var createPaymentResponse = await EpaymentService.CreatePayment(createPaymentRequest);
            Assert.IsNotNull(createPaymentResponse);
            Assert.AreEqual(reference, createPaymentResponse.Reference);

            await EpaymentService.ForceApprovePayment(
                reference,
                new ForceApprove { Customer = new Customer { PhoneNumber = _customerPhoneNumber } }
            );

            var captureResponse = await EpaymentService.CapturePayment(
                reference,
                new CaptureModificationRequest { ModificationAmount = createPaymentRequest.Amount }
            );
            Assert.IsNotNull(captureResponse);
            Assert.AreEqual(reference, captureResponse.Reference);
            Assert.AreEqual(State.AUTHORIZED, captureResponse.State);

            var refundResponse = await EpaymentService.RefundPayment(
                reference,
                new RefundModificationRequest { ModificationAmount = createPaymentRequest.Amount }
            );
            Assert.IsNotNull(refundResponse);
            Assert.AreEqual(reference, refundResponse.Reference);
            Assert.AreEqual(State.AUTHORIZED, refundResponse.State);

            var paymentEvents = await EpaymentService.GetPaymentEventLog(reference);
            Assert.IsNotNull(paymentEvents);
            Assert.AreEqual(1, paymentEvents.Count(r => r.Name == PaymentEventName.CREATED));
            Assert.AreEqual(1, paymentEvents.Count(r => r.Name == PaymentEventName.CAPTURED));
            Assert.AreEqual(1, paymentEvents.Count(r => r.Name == PaymentEventName.REFUNDED));
            Assert.AreEqual(1, paymentEvents.Count(r => r.Name == PaymentEventName.AUTHORIZED));
        }

        private static CreatePaymentRequest GetCreatePaymentRequest(string reference)
        {
            return new Models.Autogen.Epayment.CreatePaymentRequest
            {
                Amount = new Models.Autogen.Epayment.Amount
                {
                    Currency = Models.Autogen.Epayment.Currency.NOK,
                    Value = 100 // 100 øre = 1 KR
                },
                PaymentMethod = new Models.Autogen.Epayment.PaymentMethod
                {
                    Type = Models.Autogen.Epayment.PaymentMethodType.WALLET
                },
                UserFlow = Models.Autogen.Epayment.CreatePaymentRequestUserFlow.WEB_REDIRECT,
                Reference = reference,
                PaymentDescription = nameof(CheckoutServiceTests.Can_Create_And_Get_Session),
                ReturnUrl = $"https://no.where.com/{reference}",
                Customer = new Customer { PhoneNumber = _customerPhoneNumber }
            };
        }
    }
}
