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
    public record InitiateSessionRequest(
        PaymentMerchantInfo MerchantInfo,
        PaymentTransaction Transaction,
        Logistics? Logistics,
        PrefillCustomer? PrefillCustomer,
        CheckoutConfig? Configuration
    );

    /// <summary>
    ///
    /// </summary>
    /// <param name="CustomerInteraction">If customer is physically present: "customer_present", otherwise: "customer_not_present".</param>
    /// <param name="Elements">Adjust the fields and values present in the Checkout.</param>
    /// <param name="Countries">Countries to allow during session</param>
    /// <param name="UserFlow">One of the following: "WEB_REDIRECT", "NATIVE_REDIRECT". To ensure having a return URL based on an app URL, use "NATIVE_REDIRECT".</param>
    /// <param name="RequireUserInfo">Requires the customer to consent to share their email and openid sub with the merchant to be able to make a wallet payment (default: false).</param>
    public record CheckoutConfig(
        CustomerInteraction? CustomerInteraction = null,
        Elements? Elements = null,
        Countries? Countries = null,
        UserFlow? UserFlow = null,
        bool? RequireUserInfo = null
    );

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
    public record Countries(List<string> Supported);

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
    public record PaymentMerchantInfo(
        string CallbackUrl,
        string ReturnUrl,
        string CallbackAuthorizationToken,
        string? TermsAndConditionsUrl
    );

    /// <param name="Amount"></param>
    /// <param name="Reference">The merchant's unique reference for the transaction. Also known as OrderId. Example: "acme-shop-123-order123abc". See https://vippsas.github.io/vipps-developer-docs/docs/vipps-developers/common-topics/orderid</param>
    /// <param name="PaymentDescription">Description visible to the customer during payment. Example: "One pair of Vipps socks".</param>
    /// <param name="OrderSummary">Contain descriptions of each item present in the order, and an order bottom line for information regarding the order as a whole.</param>
    public record PaymentTransaction(
        Amount Amount,
        string Reference,
        string PaymentDescription,
        OrderSummary? OrderSummary
    );

    /// <summary>
    /// Amounts are specified in minor units. For Norwegian kroner (NOK) that means 1 kr = 100 øre. Example: 499 kr = 49900 øre.
    /// </summary>
    /// <param name="Currency">The currency identifier according to ISO 4217. Example: "NOK"</param>
    /// <param name="Value">Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.</param>
    public record Amount(int Value, string Currency);

    /// <param name="OrderLines">The order lines contain descriptions of each item present in the order.</param>
    /// <param name="OrderBottomLine">Contains information regarding the order as a whole.</param>
    public record OrderSummary(OrderLine[] OrderLines, OrderBottomLine OrderBottomLine);

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
    public record OrderLine(
        string Name,
        string Id,
        long TotalAmount,
        long TotalAmountExcludingTax,
        long TotalTaxAmount,
        int TaxPercentage,
        OrderUnitInfo? UnitInfo,
        long? Discount,
        string? ProductUrl,
        bool? IsReturn,
        bool? IsShipping
    );

    /// <param name="Currency">The currency identifier according to ISO 4217. Example: "NOK".</param>
    /// <param name="TipAmount">Tip amount for the order. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.</param>
    /// <param name="GiftCardAmount">Amount paid by gift card or coupon. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.</param>
    /// <param name="TerminalId">Identifier of the terminal / point of sale.</param>
    public record OrderBottomLine(
        string Currency,
        long? TipAmount,
        long? GiftCardAmount,
        string? TerminalId
    );

    /// <param name="UnitPrice">Total price per unit, including tax and excluding discount. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.</param>
    /// <param name="Quantity">Quantity given as a integer or fraction (only for cosmetics).</param>
    /// <param name="QuantityUnit">Available units for quantity. Will default to PCS if not set.</param>
    public record OrderUnitInfo(long UnitPrice, string Quantity, QuantityUnit QuantityUnit);

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
    public record Logistics(
        string? DynamicOptionsCallback,
        List<LogisticsOptionBase>? FixedOptions,
        Integrations? Integrations = null
    );

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
    public record PrefillCustomer(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string StreetAddress,
        string City,
        string PostalCode,
        string Country
    );

    public record Integrations(Porterbuddy? Porterbuddy, Instabox? Instabox, Helthjem? Helthjem);

    /// <summary>
    /// Configuration required to enable Porterbuddy logistics options
    /// </summary>
    /// <param name="PublicToken">The public key provided to you by Porterbuddy</param>
    /// <param name="ApiKey">The API key provided to you by Porterbuddy</param>
    /// <param name="Origin">Information about the sender</param>
    public record Porterbuddy(string PublicToken, string ApiKey, PorterbuddyOrigin Origin);

    /// <summary>
    /// Details about the sender of the Porterbuddy parcels
    /// </summary>
    /// <param name="Name">The name of your store</param>
    /// <param name="Email">Your email address where Porterbuddy booking confirmation will be sent</param>
    /// <param name="PhoneNumber">Your phone number where Porterbuddy may send you important messages. Format must be MSISDN (including country code). Example: "4791234567"</param>
    /// <param name="Address">Your address where Porterbuddy will pick up the parcels</param>
    public record PorterbuddyOrigin(
        string Name,
        string Email,
        string PhoneNumber,
        PorterbuddyOriginAddress Address
    );

    /// <param name="StreetAddress">Example: "Robert Levins gate 5"</param>
    /// <param name="PostalCode">Example: "0154"</param>
    /// <param name="City">Example: "Oslo"</param>
    /// <param name="Country">The ISO-3166-1 Alpha-2 representation of the country. Example: "NO"</param>
    public record PorterbuddyOriginAddress(
        string StreetAddress,
        string PostalCode,
        string City,
        string Country
    );

    /// <summary>
    /// Configuration required to enable Instabox logistics options
    /// </summary>
    /// <param name="ClientId">The client id provided to you by Instabox</param>
    /// <param name="ClientSecret">The client secret provided to you by Instabox</param>
    public record Instabox(string ClientId, string ClientSecret);

    /// <summary>
    /// Configuration required to enable Helthjem logistics options
    /// </summary>
    /// <param name="Username">The Username provided to you by Helthjem</param>
    /// <param name="Password">The Password provided to you by Helthjem</param>
    /// <param name="ShopId">The ShopId provided to you by Helthjem</param>
    public record Helthjem(string Username, string Password, int ShopId);
}
