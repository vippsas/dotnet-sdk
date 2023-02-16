using System.Text.Json.Serialization;
using Vipps.Models.Checkout.InitiateSession;

namespace Vipps.Models.Checkout.GetSession;

/// <summary>
/// Session information
/// </summary>
public class GetSessionInfoResponse : VippsResponse
{
    /// <summary>
    /// The Id of the session. Example: "v52EtjZriRmGiKiAKHByK2".
    /// </summary>
    public string SessionId { get; init; }

    /// <summary>
    /// The merchant's serial number. Example: "123456"
    /// </summary>
    public string? MerchantSerialNumber { get; init; }

    /// <summary>
    /// The merchant's unique reference for the transaction. Also known as OrderId. Example: "acme-shop-123-order123abc". See https://vippsas.github.io/vipps-developer-docs/docs/vipps-developers/common-topics/orderid
    /// </summary>
    public string Reference { get; init; }

    /// <summary>
    /// The state of the session. Example: "SessionStarted". The state of the payment is in PaymentDetails.State.
    /// </summary>
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
/// </summary>
public class UserInfo
{
    /// <summary>
    /// The openid sub that uniquely identifies a Vipps user.
    /// </summary>
    public string Sub { get; init; }

    /// <summary>
    /// Example: "user@example.com"
    /// </summary>
    public string? Email { get; init; }
}

/// <summary>
/// Defines the details of the payment.
/// </summary>
public class ResponsePaymentDetails
{
    public Amount Amount { get; init; }
    public PaymentState State { get; init; }
    public TransactionAggregate? Aggregate { get; init; }
}

/// <summary>
/// Defines the details of the transaction
/// </summary>
public class TransactionAggregate
{
    public Amount? CancelledAmount { get; init; }
    public Amount? CapturedAmount { get; init; }
    public Amount? RefundedAmount { get; init; }
    public Amount? AuthorizedAmount { get; init; }
}
