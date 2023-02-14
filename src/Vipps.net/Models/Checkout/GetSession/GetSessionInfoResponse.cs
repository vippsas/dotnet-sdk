using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Vipps.Models.Checkout.InitiateSession;

namespace Vipps.Models.Checkout.GetSession
{
    /// <summary>
    /// Session information
    /// </summary>
    /// <param name="SessionId">The Id of the session. Example: "v52EtjZriRmGiKiAKHByK2".</param>
    /// <param name="Reference">The merchant's unique reference for the transaction. Also known as OrderId. Example: "acme-shop-123-order123abc". See https://vippsas.github.io/vipps-developer-docs/docs/vipps-developers/common-topics/orderid</param>
    /// <param name="MerchantSerialNumber">The merchant's serial number. Example: "123456" </param>
    /// <param name="SessionState">The state of the session. Example: "SessionStarted". The state of the payment is in PaymentDetails.State.</param>
    /// <param name="PaymentMethod"></param>
    /// <param name="PaymentDetails"></param>
    /// <param name="UserInfo"></param>
    /// <param name="ShippingDetails"></param>
    /// <param name="BillingDetails"></param>
    public class GetSessionInfoResponse : VippsResponse
    {
        [Required]
        public string SessionId { get; private set; }
        public string MerchantSerialNumber { get; private set; }

        [Required]
        public string Reference { get; private set; }

        [Required]
        public ExternalSessionState SessionState { get; private set; }
        public PaymentMethod? PaymentMethod { get; private set; }
        public ResponsePaymentDetails PaymentDetails { get; private set; }
        public UserInfo UserInfo { get; private set; }
        public ShippingDetails ShippingDetails { get; private set; }
        public BillingDetails BillingDetails { get; private set; }
    }

    public class BillingDetails
    {
        [property: JsonPropertyName("firstName")]
        public string FirstName { get; private set; }

        [property: JsonPropertyName("lastName")]
        public string LastName { get; private set; }

        [property: JsonPropertyName("email")]
        public string Email { get; private set; }

        [property: JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; private set; }

        [property: JsonPropertyName("streetAddress")]
        public string StreetAddress { get; private set; }

        [property: JsonPropertyName("postalCode")]
        public string PostalCode { get; private set; }

        [property: JsonPropertyName("region")]
        public string Region { get; private set; }

        [property: JsonPropertyName("country")]
        public string Country { get; private set; }
    }

    public enum PaymentState
    {
        CREATED,
        AUTHORIZED,
        TERMINATED
    }

    public class PickupPoint
    {
        [property: JsonPropertyName("id")]
        public string Id { get; private set; }

        [property: JsonPropertyName("name")]
        public string Name { get; private set; }

        [property: JsonPropertyName("postalCode")]
        public string PostalCode { get; private set; }

        [property: JsonPropertyName("city")]
        public string City { get; private set; }

        [property: JsonPropertyName("country")]
        public string Country { get; private set; }
    }

    public class ShippingDetails
    {
        [property: JsonPropertyName("firstName")]
        public string FirstName { get; private set; }

        [property: JsonPropertyName("lastName")]
        public string LastName { get; private set; }

        [property: JsonPropertyName("email")]
        public string Email { get; private set; }

        [property: JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; private set; }

        [property: JsonPropertyName("streetAddress")]
        public string StreetAddress { get; private set; }

        [property: JsonPropertyName("postalCode")]
        public string PostalCode { get; private set; }

        [property: JsonPropertyName("region")]
        public string Region { get; private set; }

        [property: JsonPropertyName("country")]
        public string Country { get; private set; }

        [property: JsonPropertyName("shippingMethodId")]
        public string ShippingMethodId { get; private set; }

        [property: JsonPropertyName("pickupPoint")]
        public PickupPoint PickupPoint { get; private set; }
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
    ///
    /// </summary>
    /// <param name="Sub">The openid sub that uniquely identifies a Vipps user.</param>
    /// <param name="Email">Example: "user@example.com"</param>
    public class UserInfo
    {
        [Required]
        public string Sub { get; private set; }
        public string Email { get; private set; }
    }

    /// <summary>
    /// Defines the details of the payment.
    /// </summary>
    /// <param name="Amount"></param>
    /// <param name="State"></param>
    /// <param name="Aggregate"></param>
    public class ResponsePaymentDetails
    {
        [Required]
        public Amount Amount { get; private set; }

        [Required]
        public PaymentState State { get; private set; }
        public TransactionAggregate Aggregate { get; private set; }
    }

    /// <summary>
    /// Defines the details of the transaction
    /// </summary>
    /// <param name="CancelledAmount"></param>
    /// <param name="CapturedAmount"></param>
    /// <param name="RefundedAmount"></param>
    /// <param name="AuthorizedAmount"></param>
    public class TransactionAggregate
    {
        public Amount CancelledAmount { get; private set; }
        public Amount CapturedAmount { get; private set; }
        public Amount RefundedAmount { get; private set; }
        public Amount AuthorizedAmount { get; private set; }
    }
}
