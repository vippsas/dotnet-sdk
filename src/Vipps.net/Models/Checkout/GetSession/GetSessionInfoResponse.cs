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
        public string SessionId { get; set; }
        public string MerchantSerialNumber { get; set; }

        [Required]
        public string Reference { get; set; }

        [Required]
        public ExternalSessionState SessionState { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public ResponsePaymentDetails PaymentDetails { get; set; }
        public UserInfo UserInfo { get; set; }
        public ShippingDetails ShippingDetails { get; set; }
        public BillingDetails BillingDetails { get; set; }
    }

    public class BillingDetails
    {
        [property: JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [property: JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [property: JsonPropertyName("email")]
        public string Email { get; set; }

        [property: JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [property: JsonPropertyName("streetAddress")]
        public string StreetAddress { get; set; }

        [property: JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        [property: JsonPropertyName("region")]
        public string Region { get; set; }

        [property: JsonPropertyName("country")]
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
        [property: JsonPropertyName("id")]
        public string Id { get; set; }

        [property: JsonPropertyName("name")]
        public string Name { get; set; }

        [property: JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        [property: JsonPropertyName("city")]
        public string City { get; set; }

        [property: JsonPropertyName("country")]
        public string Country { get; set; }
    }

    public class ShippingDetails
    {
        [property: JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [property: JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [property: JsonPropertyName("email")]
        public string Email { get; set; }

        [property: JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [property: JsonPropertyName("streetAddress")]
        public string StreetAddress { get; set; }

        [property: JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        [property: JsonPropertyName("region")]
        public string Region { get; set; }

        [property: JsonPropertyName("country")]
        public string Country { get; set; }

        [property: JsonPropertyName("shippingMethodId")]
        public string ShippingMethodId { get; set; }

        [property: JsonPropertyName("pickupPoint")]
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
    ///
    /// </summary>
    /// <param name="Sub">The openid sub that uniquely identifies a Vipps user.</param>
    /// <param name="Email">Example: "user@example.com"</param>
    public class UserInfo
    {
        [Required]
        public string Sub { get; set; }
        public string Email { get; set; }
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
        public Amount Amount { get; set; }

        [Required]
        public PaymentState State { get; set; }
        public TransactionAggregate Aggregate { get; set; }
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
        public Amount CancelledAmount { get; set; }
        public Amount CapturedAmount { get; set; }
        public Amount RefundedAmount { get; set; }
        public Amount AuthorizedAmount { get; set; }
    }
}
