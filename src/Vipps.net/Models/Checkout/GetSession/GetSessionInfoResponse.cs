using System.Text.Json.Serialization;
using Vipps.Models.Checkout.InitiateSession;

namespace Vipps.Models.Checkout.GetSession
{
    public record BillingDetails(
        [property: JsonPropertyName("firstName")] string FirstName,
        [property: JsonPropertyName("lastName")] string LastName,
        [property: JsonPropertyName("email")] string Email,
        [property: JsonPropertyName("phoneNumber")] string PhoneNumber,
        [property: JsonPropertyName("streetAddress")] string StreetAddress,
        [property: JsonPropertyName("postalCode")] string PostalCode,
        [property: JsonPropertyName("region")] string Region,
        [property: JsonPropertyName("country")] string Country
    );

    public enum PaymentState
    {
        CREATED,
        AUTHORIZED,
        TERMINATED
    }

    public record PickupPoint(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("address")] string Address,
        [property: JsonPropertyName("postalCode")] string PostalCode,
        [property: JsonPropertyName("city")] string City,
        [property: JsonPropertyName("country")] string Country
    );

    public record ShippingDetails(
        [property: JsonPropertyName("firstName")] string FirstName,
        [property: JsonPropertyName("lastName")] string LastName,
        [property: JsonPropertyName("email")] string Email,
        [property: JsonPropertyName("phoneNumber")] string PhoneNumber,
        [property: JsonPropertyName("streetAddress")] string StreetAddress,
        [property: JsonPropertyName("postalCode")] string PostalCode,
        [property: JsonPropertyName("region")] string Region,
        [property: JsonPropertyName("country")] string Country,
        [property: JsonPropertyName("shippingMethodId")] string ShippingMethodId,
        [property: JsonPropertyName("pickupPoint")] PickupPoint PickupPoint
    );

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
    public record GetSessionInfoResponse(
        string SessionId,
        string? MerchantSerialNumber,
        string Reference,
        ExternalSessionState SessionState,
        PaymentMethod? PaymentMethod,
        ResponsePaymentDetails? PaymentDetails,
        UserInfo? UserInfo,
        ShippingDetails? ShippingDetails,
        BillingDetails? BillingDetails
    );
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
    public record UserInfo(string Sub, string? Email);

    /// <summary>
    /// Defines the details of the payment.
    /// </summary>
    /// <param name="Amount"></param>
    /// <param name="State"></param>
    /// <param name="Aggregate"></param>
    public record ResponsePaymentDetails(
        Amount Amount,
        PaymentState State,
        TransactionAggregate? Aggregate
    );

    /// <summary>
    /// Defines the details of the transaction
    /// </summary>
    /// <param name="CancelledAmount"></param>
    /// <param name="CapturedAmount"></param>
    /// <param name="RefundedAmount"></param>
    /// <param name="AuthorizedAmount"></param>
    public record TransactionAggregate(
        Amount? CancelledAmount,
        Amount? CapturedAmount,
        Amount? RefundedAmount,
        Amount? AuthorizedAmount
    );

}
