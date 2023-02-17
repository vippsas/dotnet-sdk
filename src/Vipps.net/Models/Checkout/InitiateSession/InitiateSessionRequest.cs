using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vipps.Models.Checkout.InitiateSession
{
    /// <summary>
    /// Request to set up a Checkout session
    /// </summary>
    public class InitiateSessionRequest : VippsRequest
    {
        [Required]
        public PaymentMerchantInfo MerchantInfo { get; set; }

        [Required]
        public PaymentTransaction Transaction { get; set; }
        public Logistics Logistics { get; set; }

        /// <summary>
        /// If customer information is known, it can be prefilled.
        /// </summary>
        public PrefillCustomer PrefillCustomer { get; set; }
        public CheckoutConfig Configuration { get; set; }
    }

    public class CheckoutConfig
    {
        /// <summary>
        /// If customer is physically present: "customer_present", otherwise: "customer_not_present".
        /// </summary>
        public CustomerInteraction CustomerInteraction { get; set; }

        /// <summary>
        /// Adjust the fields and values present in the Checkout.
        /// </summary>
        public Elements Elements { get; set; }

        /// <summary>
        /// Countries to allow during session
        /// </summary>
        public Countries Countries { get; set; }

        /// <summary>
        /// One of the following: "WEB_REDIRECT", "NATIVE_REDIRECT". To ensure having a return URL based on an app URL, use "NATIVE_REDIRECT".
        /// </summary>
        public UserFlow UserFlow { get; set; }

        /// <summary>
        /// Requires the customer to consent to share their email and openid sub with the merchant to be able to make a wallet payment {default: false).
        /// </summary>
        public bool? RequireUserInfo { get; set; }
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
    public class Countries
    {
        /// <summary>
        /// List of allowed countries in ISO-3166 Alpha 2. If specified, the customer will only be able to select these countries. Example ["NO", "SE", "DK"]
        /// </summary>
        public List<string> Supported { get; set; }
    }

    public enum Elements
    {
        Full,
        PaymentAndContactInfo,
        PaymentOnly
    }

    public class PaymentMerchantInfo
    {
        /// <summary>
        /// Complete URL for receiving callbacks. Example: "https://exmaple.com/vipps/payment-callback/
        /// </summary>
        [Required]
        public string CallbackUrl { get; set; }

        /// <summary>
        /// Complete URL for redirecting customers to when the checkout is finished. Example: "https://example.com/vipps".
        /// </summary>
        [Required]
        public string ReturnUrl { get; set; }

        /// <summary>
        /// The token will be supplied by the callback to the merchant as a header. Example: "iOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImllX3FXQ1hoWHh0MXpJ".
        /// </summary>
        [Required]
        public string CallbackAuthorizationToken { get; set; }

        /// <summary>
        /// Complete URL to the merchant's terms and conditions. Example: "https://example.com/vipps/termsAndConditions".
        /// </summary>
        public string TermsAndConditionsUrl { get; set; }
    }

    public class PaymentTransaction
    {
        [Required]
        public Amount Amount { get; set; }

        /// <summary>
        /// The merchant's unique reference for the transaction. Also known as OrderId. Example: "acme-shop-123-order123abc". See https://vippsas.github.io/vipps-developer-docs/docs/vipps-developers/common-topics/orderid
        /// </summary>
        [Required]
        public string Reference { get; set; }

        /// <summary>
        /// Description visible to the customer during payment. Example: "One pair of Vipps socks".
        /// </summary>
        [Required]
        public string PaymentDescription { get; set; }

        /// <summary>
        /// Contain descriptions of each item present in the order, and an order bottom line for information regarding the order as a whole.
        /// </summary>
        public OrderSummary OrderSummary { get; set; }
    }

    /// <summary>
    /// Amounts are specified in minor units. For Norwegian kroner (NOK) that means 1 kr = 100 øre. Example: 499 kr = 49900 øre.
    /// </summary>
    public class Amount
    {
        /// <summary>
        /// Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// The currency identifier according to ISO 4217. Example: "NOK"
        /// </summary>
        public string Currency { get; set; }
    }

    public class OrderSummary
    {
        /// <summary>
        /// The order lines contain descriptions of each item present in the order.
        /// </summary>
        public OrderLine[] OrderLines { get; set; }

        /// <summary>
        /// Contains information regarding the order as a whole.
        /// </summary>
        public OrderBottomLine OrderBottomLine { get; set; }
    }

    public class OrderLine
    {
        /// <summary>
        /// The name of the product in the order line.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The product ID.
        /// </summary>
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// Total amount of the order line, including tax and discount. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.
        /// </summary>
        [Required]
        public long TotalAmount { get; set; }

        /// <summary>
        /// Total amount of order line with discount excluding tax. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.
        /// </summary>
        [Required]
        public long TotalAmountExcludingTax { get; set; }

        /// <summary>
        /// Total tax amount paid for the order line. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.
        /// </summary>
        [Required]
        public long TotalTaxAmount { get; set; }

        /// <summary>
        /// Tax percentage for the order line.
        /// </summary>
        [Required]
        public int TaxPercentage { get; set; }

        /// <summary>
        /// If no quantity info is provided the order line will default to 1 pcs.
        /// </summary>
        public OrderUnitInfo UnitInfo { get; set; }

        /// <summary>
        /// Total discount for the order line. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.
        /// </summary>
        public long? Discount { get; set; }

        /// <summary>
        /// URL linking back to the product at the merchant.
        /// </summary>
        public string ProductUrl { get; set; }

        /// <summary>
        /// Flag for marking the orderline as returned. This will make it count negative towards all the sums in BottomLine.
        /// </summary>
        public bool? IsReturn { get; set; }

        /// <summary>
        /// Flag for marking the orderline as a shipping line. This will be shown differently in the app.
        /// </summary>
        public bool? IsShipping { get; set; }
    }

    public class OrderBottomLine
    {
        /// <summary>
        /// The currency identifier according to ISO 4217. Example: "NOK".
        /// </summary>
        [Required]
        public string Currency { get; set; }

        /// <summary>
        /// Tip amount for the order. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.
        /// </summary>
        public long? TipAmount { get; set; }

        /// <summary>
        /// Amount paid by gift card or coupon. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.
        /// </summary>
        public long? GiftCardAmount { get; set; }

        /// <summary>
        /// Identifier of the terminal / popublic int of sale.
        /// </summary>
        public string TerminalId { get; set; }
    }

    public class OrderUnitInfo
    {
        /// <summary>
        /// Total price per unit, including tax and excluding discount. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.
        /// </summary>
        public long UnitPrice { get; set; }

        /// <summary>
        /// Quantity given as a public integer or fraction {only for cosmetics).
        /// </summary>
        public string Quantity { get; set; }

        /// <summary>
        /// Available units for quantity. Will default to PCS if not set.
        /// </summary>
        public QuantityUnit QuantityUnit { get; set; }
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
    public class Logistics
    {
        /// <summary>
        /// Merchant's Callback URL for providing dynamic logistics options based on customer address. Example: "https://example.com/vipps/dynamiclogisticsoption". Can not be used with AddressFields set to false.
        /// </summary>
        public string DynamicOptionsCallback { get; set; }

        /// <summary>
        /// Fixed list of logistics options.
        /// </summary>
        public List<LogisticsOptionBase> FixedOptions { get; set; }

        /// <summary>
        /// Some optional checkout features require carrier-specific configuration. Can not be used with AddressFields set to false.
        /// </summary>
        public Integrations Integrations { get; set; }
    }

    /// <summary>
    /// Information about the customer to be prefilled
    ///
    /// If any of the customer information is invalid such as the phone number,
    /// the customer will be prompted to input new user information.
    /// </summary>
    public class PrefillCustomer
    {
        /// <summary>
        /// Example: "Ada"
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Example: "Lovelace"
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Example: "user@example.com"
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Format must be MSISDN (including country code). Example: "4791234567"
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Example: "Robert Levins gate 5"
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// Example: "Oslo"
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Example: "0154"
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// The ISO-3166-1 Alpha-2 representation of the country. Example: "NO"
        /// </summary>
        public string Country { get; set; }
    }

    public class Integrations
    {
        public Porterbuddy Porterbuddy { get; set; }
        public Instabox Instabox { get; set; }
        public Helthjem Helthjem { get; set; }
    }

    /// <summary>
    /// Configuration required to enable Porterbuddy logistics options
    /// </summary>
    public class Porterbuddy
    {
        /// <summary>
        /// The public key provided to you by Porterbuddy
        /// </summary>
        public string PublicToken { get; set; }

        /// <summary>
        /// The API key provided to you by Porterbuddy
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Information about the sender
        /// </summary>
        public PorterbuddyOrigin Origin { get; set; }
    }

    /// <summary>
    /// Details about the sender of the Porterbuddy parcels
    /// </summary>
    public class PorterbuddyOrigin
    {
        /// <summary>
        /// The name of your store
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Your email address where Porterbuddy booking confirmation will be sent
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Your phone number where Porterbuddy may send you important messages. Format must be MSISDN (including country code). Example: "4791234567"
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Your address where Porterbuddy will pick up the parcels
        /// </summary>
        public PorterbuddyOriginAddress Address { get; set; }
    }

    public class PorterbuddyOriginAddress
    {
        /// <summary>
        /// Example: "Robert Levins gate 5"
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// Example: "0154"
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Example: "Oslo"
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The ISO-3166-1 Alpha-2 representation of the country. Example: "NO"
        /// </summary>
        public string Country { get; set; }
    }

    /// <summary>
    /// Configuration required to enable Instabox logistics options
    /// </summary>
    public class Instabox
    {
        /// <summary>
        /// The client id provided to you by Instabox
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The client secret provided to you by Instabox
        /// </summary>
        public string ClientSecret { get; set; }
    }

    /// <summary>
    /// Configuration required to enable Helthjem logistics options
    /// </summary>
    public class Helthjem
    {
        /// <summary>
        /// The Username provided to you by Helthjem
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The Password provided to you by Helthjem
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The ShopId provided to you by Helthjem
        /// </summary>
        public int ShopId { get; set; }
    }
}
