using Newtonsoft.Json;
using Vipps.Models.Checkout.InitiateSession;

namespace Vipps.Models.Checkout.GetSession
{
    /// <summary>
    /// Session information
    /// </summary>
    public class GetSessionInfoResponse : VippsResponse
    {
        /// <summary>
        /// The Id of the session. Example: "v52EtjZriRmGiKiAKHByK2".
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// The merchant's serial number. Example: "123456"
        /// </summary>
        public string MerchantSerialNumber { get; set; }

        /// <summary>
        /// The merchant's unique reference for the transaction. Also known as OrderId. Example: "acme-shop-123-order123abc". See https://vippsas.github.io/vipps-developer-docs/docs/vipps-developers/common-topics/orderid
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// The state of the session. Example: "SessionStarted". The state of the payment is in PaymentDetails.State.
        /// </summary>
        public ExternalSessionState SessionState { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public ResponsePaymentDetails PaymentDetails { get; set; }
        public UserInfo UserInfo { get; set; }
        public ShippingDetails ShippingDetails { get; set; }
        public BillingDetails BillingDetails { get; set; }
    }

    public class BillingDetails
    {
        [property: JsonProperty("firstName")]
        public string FirstName { get; set; }

        [property: JsonProperty("lastName")]
        public string LastName { get; set; }

        [property: JsonProperty("email")]
        public string Email { get; set; }

        [property: JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [property: JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }

        [property: JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [property: JsonProperty("region")]
        public string Region { get; set; }

        [property: JsonProperty("country")]
        public string Country { get; set; }
    }

    public enum PaymentState
    {
        CREATED,
        AUTHORIZED,
        TERMINATED
    }

    public class PickupPoint
    {
        [property: JsonProperty("id")]
        public string Id { get; set; }

        [property: JsonProperty("name")]
        public string Name { get; set; }

        [property: JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [property: JsonProperty("city")]
        public string City { get; set; }

        [property: JsonProperty("country")]
        public string Country { get; set; }
    }

    public class ShippingDetails
    {
        [property: JsonProperty("firstName")]
        public string FirstName { get; set; }

        [property: JsonProperty("lastName")]
        public string LastName { get; set; }

        [property: JsonProperty("email")]
        public string Email { get; set; }

        [property: JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [property: JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }

        [property: JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [property: JsonProperty("region")]
        public string Region { get; set; }

        [property: JsonProperty("country")]
        public string Country { get; set; }

        [property: JsonProperty("shippingMethodId")]
        public string ShippingMethodId { get; set; }

        [property: JsonProperty("pickupPoint")]
        public PickupPoint PickupPoint { get; set; }
    }

    public enum ExternalSessionState
    {
        SessionCreated,
        PaymentInitiated,
        SessionExpired,
        PaymentSuccessful,
        PaymentTerminated
    }

    public enum PaymentMethod
    {
        Wallet,
        Card
    }

    /// <summary>
    /// Data from the UserInfo endpoint. Will only be present if UserInfo flow is used.
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// The openid sub that uniquely identifies a Vipps user.
        /// </summary>
        public string Sub { get; set; }

        /// <summary>
        /// Example: "user@example.com"
        /// </summary>
        public string Email { get; set; }
    }

    /// <summary>
    /// Defines the details of the payment.
    /// </summary>
    public class ResponsePaymentDetails
    {
        public Amount Amount { get; set; }
        public PaymentState State { get; set; }
        public TransactionAggregate Aggregate { get; set; }
    }

    /// <summary>
    /// Defines the details of the transaction
    /// </summary>
    public class TransactionAggregate
    {
        public Amount CancelledAmount { get; set; }
        public Amount CapturedAmount { get; set; }
        public Amount RefundedAmount { get; set; }
        public Amount AuthorizedAmount { get; set; }
    }
}
