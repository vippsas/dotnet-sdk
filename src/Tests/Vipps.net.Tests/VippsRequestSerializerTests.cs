using System.Text.Json;
using Vipps.Models.Checkout.InitiateSession;
using Vipps.net.Helpers;

namespace Vipps.net.Tests
{
    [TestClass]
    public class VippsRequestSerializerTests
    {
        [TestMethod]
        public void Can_Serialize_With_Nested_Extra_Parameters()
        {
            InitiateSessionRequest initiateSessionRequest =
                new()
                {
                    Transaction = new PaymentTransaction()
                    {
                        Amount = new Amount() { Currency = "NOK", Value = 49000 },
                        PaymentDescription = "Hei"
                    },
                    ExtraParameters = new
                    {
                        Transaction = new { Metadata = new { KID = "100001" } }
                    }
                };
            var serializedRequest = VippsRequestSerializer.SerializeVippsRequest(
                initiateSessionRequest
            );
            Assert.IsNotNull(serializedRequest);
            Assert.AreNotEqual("", serializedRequest);
            var deserialized = JsonSerializer.Deserialize<JsonElement>(serializedRequest);
            deserialized.TryGetProperty("ExtraParameters", out var deserializedExtraParameters);
            Assert.AreEqual(JsonValueKind.Undefined, deserializedExtraParameters.ValueKind);
            Assert.AreEqual(
                initiateSessionRequest.ExtraParameters.Transaction.Metadata.KID,
                deserialized
                    .GetProperty("Transaction")
                    .GetProperty("Metadata")
                    .GetProperty("KID")
                    .GetString()
            );
        }

        [TestMethod]
        public void Can_Serialize_With_Extra_Parameters_Array()
        {
            InitiateSessionRequest initiateSessionRequest =
                new()
                {
                    Transaction = new PaymentTransaction()
                    {
                        Amount = new Amount() { Currency = "NOK", Value = 49000 },
                        PaymentDescription = "Hei"
                    },
                    Configuration = new CheckoutConfig() { Elements = Elements.PaymentOnly },
                    ExtraParameters = new
                    {
                        Configuration = new { AcceptedPaymentMethods = new[] { "WALLET", "CARD" } }
                    }
                };
            var serializedRequest = VippsRequestSerializer.SerializeVippsRequest(
                initiateSessionRequest
            );
            Assert.IsNotNull(serializedRequest);
            Assert.AreNotEqual("", serializedRequest);
            var deserialized = JsonSerializer.Deserialize<JsonElement>(serializedRequest);
            deserialized.TryGetProperty("ExtraParameters", out var deserializedExtraParameters);
            Assert.AreEqual(JsonValueKind.Undefined, deserializedExtraParameters.ValueKind);
            Assert.AreEqual(
                JsonValueKind.Array,
                deserialized
                    .GetProperty("Configuration")
                    .GetProperty("AcceptedPaymentMethods")
                    .ValueKind
            );
        }

        [TestMethod]
        public void Can_Serialize_Without_Extra_Parameters()
        {
            InitiateSessionRequest initiateSessionRequest =
                new()
                {
                    Transaction = new PaymentTransaction()
                    {
                        Amount = new Amount() { Currency = "NOK", Value = 49000 },
                        PaymentDescription = "Hei"
                    }
                };
            var serializedRequest = VippsRequestSerializer.SerializeVippsRequest(
                initiateSessionRequest
            );
            Assert.IsNotNull(serializedRequest);
            Assert.AreNotEqual("", serializedRequest);
            var deserialized = JsonSerializer.Deserialize<InitiateSessionRequest>(
                serializedRequest
            );
            Assert.IsNotNull(deserialized);
            Assert.IsNull(deserialized?.ExtraParameters);
        }
    }
}
