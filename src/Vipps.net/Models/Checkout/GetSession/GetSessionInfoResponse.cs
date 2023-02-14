using System.Text.Json.Serialization;
using Vipps.Models.Checkout.InitiateSession;

namespace Vipps.Models.Checkout.GetSession;

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
    public string SessionId { get; init; }
    public string? MerchantSerialNumber { get; init; }
    public string Reference { get; init; }
    public ExternalSessionState SessionState { get; init; }
    public PaymentMethod? PaymentMethod { get; init; }
    public ResponsePaymentDetails? PaymentDetails { get; init; }
    public UserInfo? UserInfo { get; init; }
    public ShippingDetails? ShippingDetails { get; init; }
    public BillingDetails? BillingDetails { get; init; }
}

public class BillingDetails
{
    [property: JsonPropertyName("firstName")]
    public string FirstName { get; init; }

    [property: JsonPropertyName("lastName")]
    public string LastName { get; init; }

    [property: JsonPropertyName("email")]
    public string Email { get; init; }

    [property: JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; init; }

    [property: JsonPropertyName("streetAddress")]
    public string StreetAddress { get; init; }

    [property: JsonPropertyName("postalCode")]
    public string PostalCode { get; init; }

    [property: JsonPropertyName("region")]
    public string Region { get; init; }

    [property: JsonPropertyName("country")]
    public string Country { get; init; }
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
    public string Id { get; init; }

    [property: JsonPropertyName("name")]
    public string Name { get; init; }

    [property: JsonPropertyName("postalCode")]
    public string PostalCode { get; init; }

    [property: JsonPropertyName("city")]
    public string City { get; init; }

    [property: JsonPropertyName("country")]
    public string Country { get; init; }
}

public class ShippingDetails
{
    [property: JsonPropertyName("firstName")]
    public string FirstName { get; init; }

    [property: JsonPropertyName("lastName")]
    public string LastName { get; init; }

    [property: JsonPropertyName("email")]
    public string Email { get; init; }

    [property: JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; init; }

    [property: JsonPropertyName("streetAddress")]
    public string StreetAddress { get; init; }

    [property: JsonPropertyName("postalCode")]
    public string PostalCode { get; init; }

    [property: JsonPropertyName("region")]
    public string Region { get; init; }

    [property: JsonPropertyName("country")]
    public string Country { get; init; }

    [property: JsonPropertyName("shippingMethodId")]
    public string ShippingMethodId { get; init; }

    [property: JsonPropertyName("pickupPoint")]
    public PickupPoint PickupPoint { get; init; }
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
    public string Sub { get; init; }
    public string? Email { get; init; }
}

/// <summary>
/// Defines the details of the payment.
/// </summary>
/// <param name="Amount"></param>
/// <param name="State"></param>
/// <param name="Aggregate"></param>
public class ResponsePaymentDetails
{
    public Amount Amount { get; init; }
    public PaymentState State { get; init; }
    public TransactionAggregate? Aggregate { get; init; }
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
    public Amount? CancelledAmount { get; init; }
    public Amount? CapturedAmount { get; init; }
    public Amount? RefundedAmount { get; init; }
    public Amount? AuthorizedAmount { get; init; }
}
