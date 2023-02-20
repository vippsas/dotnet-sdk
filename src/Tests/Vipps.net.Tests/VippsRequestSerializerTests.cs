using System.Text.Json;
using Newtonsoft.Json.Linq;
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
        public void Can_Serialize_With_Extra_Parameters_On_Undefined_Receiver()
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

        [TestMethod]
        public void Can_Deserialize_Response_Without_Extra_Properties()
        {
            InitiateSessionResponse initiateSessionResponse =
                new()
                {
                    CheckoutFrontendUrl = "https://vipps.no/checkout-frontend",
                    PollingUrl = "https://api.vipps.no/checkout/v3/session/reference101",
                    Token = "eynghsvdsjhkfgasf"
                };
            var serializedResponse = JsonSerializer.Serialize(initiateSessionResponse);
            var deserializedResponse =
                VippsRequestSerializer.DeserializeVippsResponse<InitiateSessionResponse>(
                    serializedResponse
                );
            Assert.IsNotNull(deserializedResponse);
        }

        [TestMethod]
        public void Can_Deserialize_Response_With_Extra_Properties()
        {
            dynamic initiateSessionResponse = new
            {
                checkoutFrontendUrl = "https://vipps.no/checkout-frontend",
                pollingUrl = "https://api.vipps.no/checkout/v3/session/reference101",
                token = "eynghsvdsjhkfgasf",
                cancellationUrl = "https://api.vipps.no/checkout/v3/session/reference101/cancel"
            };
            var serializedResponse = JsonSerializer.Serialize(initiateSessionResponse);
            InitiateSessionResponse deserializedResponse =
                VippsRequestSerializer.DeserializeVippsResponse<InitiateSessionResponse>(
                    serializedResponse
                );
            Assert.IsNotNull(deserializedResponse);
            Assert.IsNotNull(deserializedResponse.RawResponse);
            Assert.AreEqual(
                initiateSessionResponse.cancellationUrl,
                deserializedResponse.RawResponse.GetValue("cancellationUrl")?.ToString()
            );
        }

        [TestMethod]
        public void Can_Deserialize_Response_With_Nested_Extra_Properties()
        {
            dynamic initiateSessionResponse = new
            {
                checkoutFrontendUrl = "https://vipps.no/checkout-frontend",
                pollingUrl = "https://api.vipps.no/checkout/v3/session/reference101",
                token = "eynghsvdsjhkfgasf",
                epayment = new
                {
                    pollingUrl = "https://api.vipps.no/epayment/v1/payment/reference101",
                    captureUrl = "https://api.vipps.no/epayment/v1/payment/reference101/capture"
                }
            };
            var serializedResponse = JsonSerializer.Serialize(initiateSessionResponse);
            InitiateSessionResponse deserializedResponse =
                VippsRequestSerializer.DeserializeVippsResponse<InitiateSessionResponse>(
                    serializedResponse
                );
            Assert.IsNotNull(deserializedResponse);
            Assert.IsNotNull(deserializedResponse.RawResponse);
            var epaymentObject = deserializedResponse.RawResponse.GetValue("epayment")?.ToObject<JObject>();
            Assert.AreEqual(
                initiateSessionResponse.epayment.pollingUrl,
                epaymentObject?.GetValue("pollingUrl")?.ToString()
            );
            Assert.AreEqual(
                initiateSessionResponse.epayment.captureUrl,
                epaymentObject?.GetValue("captureUrl")?.ToString()
            );
        }
    }
}
