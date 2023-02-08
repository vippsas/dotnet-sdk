using System.Text.Json.Serialization;

namespace Vipps.Models.Checkout.InitiateSession
{
    /// <summary>
    /// Request to set up a Checkout session
    /// </summary>
    /// <param name="MerchantInfo"></param>
    /// <param name="Transaction"></param>
    /// <param name="Logistics"></param>
    /// <param name="PrefillCustomer">If customer information is known, it can be prefilled.</param>
    /// <param name="Configuration"></param>
    public class InitiateSessionRequest
    {
        public PaymentMerchantInfo MerchantInfo { get; init; }
        public PaymentTransaction Transaction { get; init; }
        public Logistics? Logistics { get; init; }
        public PrefillCustomer? PrefillCustomer { get; init; }
        public CheckoutConfig? Configuration { get; init; }
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="CustomerInteraction">If customer is physically present: "customer_present", otherwise: "customer_not_present".</param>
    /// <param name="Elements">Adjust the fields and values present in the Checkout.</param>
    /// <param name="Countries">Countries to allow during session</param>
    /// <param name="UserFlow">One of the following: "WEB_REDIRECT", "NATIVE_REDIRECT". To ensure having a return URL based on an app URL, use "NATIVE_REDIRECT".</param>
    /// <param name="RequireUserInfo">Requires the customer to consent to share their email and openid sub with the merchant to be able to make a wallet payment {default: false).</param>
    public class CheckoutConfig
    {
        public CustomerInteraction? CustomerInteraction { get; init; }
        public Elements? Elements { get; init; }
        public Countries? Countries { get; init; }
        public UserFlow? UserFlow { get; init; }
        public bool? RequireUserInfo { get; init; }
    }

    public enum UserFlow
    {
        WEB_REDIRECT,
        NATIVE_REDIRECT
    }

    public enum CustomerInteraction
    {
        CUSTOMER_PRESENT,
        CUSTOMER_NOT_PRESENT
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="Supported">List of allowed countries in ISO-3166 Alpha 2. If specified, the customer will only be able to select these countries. Example ["NO", "SE", "DK"]</param>
    public class Countries
    {
        public List<string> Supported { get; init; }
    }

    public enum Elements
    {
        Full,
        PaymentAndContactInfo,
        PaymentOnly
    }

    /// <param name="CallbackUrl">Complete URL for receiving callbacks. Example: "https://exmaple.com/vipps/payment-callback/</param>
    /// <param name="ReturnUrl">Complete URL for redirecting customers to when the checkout is finished. Example: "https://example.com/vipps".</param>
    /// <param name="CallbackAuthorizationToken">The token will be supplied by the callback to the merchant as a header. Example: "iOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImllX3FXQ1hoWHh0MXpJ".</param>
    /// <param name="TermsAndConditionsUrl">Complete URL to the merchant's terms and conditions. Example: "https://example.com/vipps/termsAndConditions".</param>
    public class PaymentMerchantInfo
    {
        public string CallbackUrl { get; init; }
        public string ReturnUrl { get; init; }
        public string CallbackAuthorizationToken { get; init; }
        public string? TermsAndConditionsUrl { get; init; }
    }

    /// <param name="Amount"></param>
    /// <param name="Reference">The merchant's unique reference for the transaction. Also known as OrderId. Example: "acme-shop-123-order123abc". See https://vippsas.github.io/vipps-developer-docs/docs/vipps-developers/common-topics/orderid</param>
    /// <param name="PaymentDescription">Description visible to the customer during payment. Example: "One pair of Vipps socks".</param>
    /// <param name="OrderSummary">Contain descriptions of each item present in the order, and an order bottom line for information regarding the order as a whole.</param>
    public class PaymentTransaction
    {
        public Amount Amount { get; init; }
        public string Reference { get; init; }
        public string PaymentDescription { get; init; }
        public OrderSummary? OrderSummary { get; init; }
    }

    /// <summary>
    /// Amounts are specified in minor units. For Norwegian kroner (NOK) that means 1 kr = 100 øre. Example: 499 kr = 49900 øre.
    /// </summary>
    /// <param name="Currency">The currency identifier according to ISO 4217. Example: "NOK"</param>
    /// <param name="Value">Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.</param>
    public class Amount
    {
        public int Value { get; init; }
        public string Currency { get; init; }
    }

    /// <param name="OrderLines">The order lines contain descriptions of each item present in the order.</param>
    /// <param name="OrderBottomLine">Contains information regarding the order as a whole.</param>
    public class OrderSummary
    {
        public OrderLine[] OrderLines { get; init; }
        public OrderBottomLine OrderBottomLine { get; init; }
    }

    /// <param name="Name">The name of the product in the order line.</param>
    /// <param name="Id">The product ID.</param>
    /// <param name="TotalAmount">Total amount of the order line, including tax and discount. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.</param>
    /// <param name="TotalAmountExcludingTax">Total amount of order line with discount excluding tax. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.</param>
    /// <param name="TotalTaxAmount">Total tax amount paid for the order line. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.</param>
    /// <param name="TaxPercentage">Tax percentage for the order line.</param>
    /// <param name="UnitInfo">If no quantity info is provided the order line will default to 1 pcs.</param>
    /// <param name="Discount">Total discount for the order line. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.</param>
    /// <param name="ProductUrl">URL linking back to the product at the merchant.</param>
    /// <param name="IsReturn">Flag for marking the orderline as returned. This will make it count negative towards all the sums in BottomLine.</param>
    /// <param name="IsShipping">Flag for marking the orderline as a shipping line. This will be shown differently in the app.</param>
    public class OrderLine
    {
        public string Name { get; init; }
        public string Id { get; init; }
        public long TotalAmount { get; init; }
        public long TotalAmountExcludingTax { get; init; }
        public long TotalTaxAmount { get; init; }
        public int TaxPercentage { get; init; }
        public OrderUnitInfo? UnitInfo { get; init; }
        public long? Discount { get; init; }
        public string? ProductUrl { get; init; }
        public bool? IsReturn { get; init; }
        public bool? IsShipping { get; init; }
    }

    /// <param name="Currency">The currency identifier according to ISO 4217. Example: "NOK".</param>
    /// <param name="TipAmount">Tip amount for the order. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.</param>
    /// <param name="GiftCardAmount">Amount paid by gift card or coupon. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.</param>
    /// <param name="TerminalId">Identifier of the terminal / popublic int of sale.</param>
    public class OrderBottomLine
    {
        public string Currency { get; init; }
        public long? TipAmount { get; init; }
        public long? GiftCardAmount { get; init; }
        public string? TerminalId { get; init; }
    }

    /// <param name="UnitPrice">Total price per unit, including tax and excluding discount. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.</param>
    /// <param name="Quantity">Quantity given as a public integer or fraction {only for cosmetics).</param>
    /// <param name="QuantityUnit">Available units for quantity. Will default to PCS if not set.</param>
    public class OrderUnitInfo
    {
        public long UnitPrice { get; init; }
        public string Quantity { get; init; }
        public QuantityUnit QuantityUnit { get; init; }
    }

    public enum QuantityUnit
    {
        PCS,
        KG,
        KM,
        MINUTE,
        LITRE
    }

    /// <summary>
    /// If both dynamic and fixed options are specified, dynamic options is provided to the user.
    /// If no DynamicOptionsCallback is provided, only fixed logistics options will be used.
    /// When using dynamic shipping we recommend that you define logistics.fixedOptions as a backup.
    /// If the callback does not resolve successfully within 8 seconds, returns null or an empty list the system will fall back to static options.
    /// If no fallback options are provided, the user will be presented with an error and will not be able to continue with the checkout.
    /// </summary>
    /// <param name="DynamicOptionsCallback">Merchant's Callback URL for providing dynamic logistics options based on customer address. Example: "https://example.com/vipps/dynamiclogisticsoption". Can not be used with AddressFields set to false.</param>
    /// <param name="FixedOptions">Fixed list of logistics options.</param>
    /// <param name="Integrations">Some optional checkout features require carrier-specific configuration. Can not be used with AddressFields set to false.</param>
    public class Logistics
    {
        public string? DynamicOptionsCallback { get; init; }
        public List<LogisticsOptionBase>? FixedOptions { get; init; }
        public Integrations? Integrations { get; init; }
    }

    /// <summary>
    /// Information about the customer to be prefilled
    ///
    /// If any of the customer information is invalid such as the phone number,
    /// the customer will be prompted to input new user information.
    /// </summary>
    /// <param name="FirstName">Example: "Ada"</param>
    /// <param name="LastName">Example: "Lovelace"</param>
    /// <param name="Email">Example: "user@example.com"</param>
    /// <param name="PhoneNumber">Format must be MSISDN (including country code). Example: "4791234567"</param>
    /// <param name="StreetAddress">Example: "Robert Levins gate 5"</param>
    /// <param name="PostalCode">Example: "0154"</param>
    /// <param name="City">Example: "Oslo"</param>
    /// <param name="Country">The ISO-3166-1 Alpha-2 representation of the country. Example: "NO"</param>
    public class PrefillCustomer
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public string StreetAddress { get; init; }
        public string City { get; init; }
        public string PostalCode { get; init; }
        public string Country { get; init; }
    }

    public class Integrations
    {
        public Porterbuddy? Porterbuddy { get; init; }
        public Instabox? Instabox { get; init; }
        public Helthjem? Helthjem { get; init; }
    }

    /// <summary>
    /// Configuration required to enable Porterbuddy logistics options
    /// </summary>
    /// <param name="PublicToken">The public key provided to you by Porterbuddy</param>
    /// <param name="ApiKey">The API key provided to you by Porterbuddy</param>
    /// <param name="Origin">Information about the sender</param>
    public class Porterbuddy
    {
        public string PublicToken { get; init; }
        public string ApiKey { get; init; }
        public PorterbuddyOrigin Origin { get; init; }
    }

    /// <summary>
    /// Details about the sender of the Porterbuddy parcels
    /// </summary>
    /// <param name="Name">The name of your store</param>
    /// <param name="Email">Your email address where Porterbuddy booking confirmation will be sent</param>
    /// <param name="PhoneNumber">Your phone number where Porterbuddy may send you important messages. Format must be MSISDN (including country code). Example: "4791234567"</param>
    /// <param name="Address">Your address where Porterbuddy will pick up the parcels</param>
    public class PorterbuddyOrigin
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public PorterbuddyOriginAddress Address { get; init; }
    }

    /// <param name="StreetAddress">Example: "Robert Levins gate 5"</param>
    /// <param name="PostalCode">Example: "0154"</param>
    /// <param name="City">Example: "Oslo"</param>
    /// <param name="Country">The ISO-3166-1 Alpha-2 representation of the country. Example: "NO"</param>
    public class PorterbuddyOriginAddress
    {
        public string StreetAddress { get; init; }
        public string PostalCode { get; init; }
        public string City { get; init; }
        public string Country { get; init; }
    }

    /// <summary>
    /// Configuration required to enable Instabox logistics options
    /// </summary>
    /// <param name="ClientId">The client id provided to you by Instabox</param>
    /// <param name="ClientSecret">The client secret provided to you by Instabox</param>
    public class Instabox
    {
        public string ClientId { get; init; }
        public string ClientSecret { get; init; }
    }

    /// <summary>
    /// Configuration required to enable Helthjem logistics options
    /// </summary>
    /// <param name="Username">The Username provided to you by Helthjem</param>
    /// <param name="Password">The Password provided to you by Helthjem</param>
    /// <param name="ShopId">The ShopId provided to you by Helthjem</param>
    public class Helthjem
    {
        public string Username { get; init; }
        public string Password { get; init; }
        public int ShopId { get; init; }
    }
}
