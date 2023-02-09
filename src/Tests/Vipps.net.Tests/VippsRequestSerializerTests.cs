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
            InitiateSessionRequest initiateSessionRequest = new()
            {
                Transaction = new PaymentTransaction()
                {
                    Amount = new Amount()
                    {
                        Currency = "NOK",
                        Value = 49000
                    },
                    PaymentDescription = "Hei"
                },
                ExtraParameters = new
                {
                    Transaction = new
                    {
                        Metadata = new
                        {
                            KID = "100001"
                        }
                    }
                }
            };
            string serializedRequest = VippsRequestSerializer.SerializeVippsRequest(initiateSessionRequest);
            Assert.IsNotNull(serializedRequest);
            Assert.AreNotEqual("", serializedRequest);
            JsonElement deserialized = JsonSerializer.Deserialize<JsonElement>(serializedRequest);
            deserialized.TryGetProperty("ExtraParameters", out JsonElement deserializedExtraParameters);
            Assert.AreEqual(deserializedExtraParameters.ValueKind, JsonValueKind.Null);
            Assert.AreEqual(deserialized.GetProperty("Transaction").GetProperty("Metadata").GetProperty("KID").GetString(), "100001");
        }

        [TestMethod]
        public void Can_Serialize_Without_Extra_Parameters()
        {
            InitiateSessionRequest initiateSessionRequest = new()
            {
                Transaction = new PaymentTransaction()
                {
                    Amount = new Amount()
                    {
                        Currency = "NOK",
                        Value = 49000
                    },
                    PaymentDescription = "Hei"
                }
            };
            string serializedRequest = VippsRequestSerializer.SerializeVippsRequest(initiateSessionRequest);
            Assert.IsNotNull(serializedRequest);
            Assert.AreNotEqual("", serializedRequest);
            InitiateSessionRequest? deserialized = JsonSerializer.Deserialize<InitiateSessionRequest>(serializedRequest);
            Assert.IsNotNull(deserialized);
            Assert.IsNull(deserialized?.ExtraParameters);
        }
    }
}
