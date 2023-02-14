using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
    public class InitiateSessionRequest : VippsRequest
    {
        public InitiateSessionRequest(
            PaymentMerchantInfo merchantInfo,
            PaymentTransaction transaction,
            Logistics logistics,
            PrefillCustomer prefillcustomer,
            CheckoutConfig checkoutConfig
        )
        {
            MerchantInfo = merchantInfo;
            Transaction = transaction;
            Logistics = logistics;
            PrefillCustomer = prefillcustomer;
            Configuration = checkoutConfig;
        }

        [Required]
        public PaymentMerchantInfo MerchantInfo { get; private set; }

        [Required]
        public PaymentTransaction Transaction { get; private set; }
        public Logistics Logistics { get; private set; }
        public PrefillCustomer PrefillCustomer { get; private set; }
        public CheckoutConfig Configuration { get; private set; }
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
        public CheckoutConfig(
            CustomerInteraction customerInteraction,
            Elements elements,
            Countries countries,
            UserFlow userFlow,
            bool? requireUserInfo
        )
        {
            CustomerInteraction = customerInteraction;
            Elements = elements;
            Countries = countries;
            UserFlow = userFlow;
            RequireUserInfo = requireUserInfo;
        }

        public CustomerInteraction CustomerInteraction { get; private set; }
        public Elements Elements { get; private set; }
        public Countries Countries { get; private set; }
        public UserFlow UserFlow { get; private set; }
        public bool? RequireUserInfo { get; private set; }
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
        public List<string> Supported { get; private set; }
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
        public PaymentMerchantInfo(
            string callbackUrl,
            string returnUrl,
            string callbackAuthorizationToken,
            string termsAndConditionsUrl
        )
        {
            CallbackUrl = callbackUrl;
            ReturnUrl = returnUrl;
            CallbackAuthorizationToken = callbackAuthorizationToken;
            TermsAndConditionsUrl = termsAndConditionsUrl;
        }

        [Required]
        public string CallbackUrl { get; private set; }

        [Required]
        public string ReturnUrl { get; private set; }

        [Required]
        public string CallbackAuthorizationToken { get; private set; }
        public string TermsAndConditionsUrl { get; private set; }
    }

    /// <param name="Amount"></param>
    /// <param name="Reference">The merchant's unique reference for the transaction. Also known as OrderId. Example: "acme-shop-123-order123abc". See https://vippsas.github.io/vipps-developer-docs/docs/vipps-developers/common-topics/orderid</param>
    /// <param name="PaymentDescription">Description visible to the customer during payment. Example: "One pair of Vipps socks".</param>
    /// <param name="OrderSummary">Contain descriptions of each item present in the order, and an order bottom line for information regarding the order as a whole.</param>
    public class PaymentTransaction
    {
        public PaymentTransaction(
            Amount amount,
            string reference,
            string paymentDescription,
            OrderSummary orderSummary
        )
        {
            Amount = amount;
            Reference = reference;
            PaymentDescription = paymentDescription;
            OrderSummary = orderSummary;
        }

        [Required]
        public Amount Amount { get; private set; }

        [Required]
        public string Reference { get; private set; }

        [Required]
        public string PaymentDescription { get; private set; }
        public OrderSummary OrderSummary { get; private set; }
    }

    /// <summary>
    /// Amounts are specified in minor units. For Norwegian kroner (NOK) that means 1 kr = 100 øre. Example: 499 kr = 49900 øre.
    /// </summary>
    /// <param name="Currency">The currency identifier according to ISO 4217. Example: "NOK"</param>
    /// <param name="Value">Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.</param>
    public class Amount
    {
        public Amount(int value, string currency)
        {
            Value = value;
            Currency = currency;
        }

        public int Value { get; private set; }
        public string Currency { get; private set; }
    }

    /// <param name="OrderLines">The order lines contain descriptions of each item present in the order.</param>
    /// <param name="OrderBottomLine">Contains information regarding the order as a whole.</param>
    public class OrderSummary
    {
        public OrderSummary(OrderLine[] orderLines, OrderBottomLine orderBottomLine)
        {
            OrderLines = orderLines;
            OrderBottomLine = orderBottomLine;
        }

        public OrderLine[] OrderLines { get; private set; }
        public OrderBottomLine OrderBottomLine { get; private set; }
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
        public OrderLine(
            string name,
            string id,
            long totalAmount,
            long totalAmountExcludingTax,
            long totalTaxAmount,
            int taxPercentage,
            OrderUnitInfo unitInfo,
            long? discount,
            string productUrl,
            bool? isReturn,
            bool? isShipping
        )
        {
            Name = name;
            Id = id;
            TotalAmount = totalAmount;
            TotalAmountExcludingTax = totalAmountExcludingTax;
            TotalTaxAmount = totalTaxAmount;
            TaxPercentage = taxPercentage;
            UnitInfo = unitInfo;
            Discount = discount;
            ProductUrl = productUrl;
            IsReturn = isReturn;
            IsShipping = isShipping;
        }

        [Required]
        public string Name { get; private set; }

        [Required]
        public string Id { get; private set; }

        [Required]
        public long TotalAmount { get; private set; }

        [Required]
        public long TotalAmountExcludingTax { get; private set; }

        [Required]
        public long TotalTaxAmount { get; private set; }

        [Required]
        public int TaxPercentage { get; private set; }
        public OrderUnitInfo UnitInfo { get; private set; }
        public long? Discount { get; private set; }
        public string ProductUrl { get; private set; }
        public bool? IsReturn { get; private set; }
        public bool? IsShipping { get; private set; }
    }

    /// <param name="Currency">The currency identifier according to ISO 4217. Example: "NOK".</param>
    /// <param name="TipAmount">Tip amount for the order. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.</param>
    /// <param name="GiftCardAmount">Amount paid by gift card or coupon. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.</param>
    /// <param name="TerminalId">Identifier of the terminal / popublic int of sale.</param>
    public class OrderBottomLine
    {
        public OrderBottomLine(
            string currency,
            long? tipAmount,
            long? giftCardAmount,
            string terminalId
        )
        {
            Currency = currency;
            TipAmount = tipAmount;
            GiftCardAmount = giftCardAmount;
            TerminalId = terminalId;
        }

        [Required]
        public string Currency { get; private set; }
        public long? TipAmount { get; private set; }
        public long? GiftCardAmount { get; private set; }
        public string TerminalId { get; private set; }
    }

    /// <param name="UnitPrice">Total price per unit, including tax and excluding discount. Must be in Minor Units. The smallest unit of a currency. Example 100 NOK = 10000.</param>
    /// <param name="Quantity">Quantity given as a public integer or fraction {only for cosmetics).</param>
    /// <param name="QuantityUnit">Available units for quantity. Will default to PCS if not set.</param>
    public class OrderUnitInfo
    {
        public OrderUnitInfo(long unitPrice, string quantity, QuantityUnit quantityUnit)
        {
            UnitPrice = unitPrice;
            Quantity = quantity;
            QuantityUnit = quantityUnit;
        }

        public long UnitPrice { get; private set; }
        public string Quantity { get; private set; }
        public QuantityUnit QuantityUnit { get; private set; }
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
        public string DynamicOptionsCallback { get; private set; }
        public List<LogisticsOptionBase> FixedOptions { get; private set; }
        public Integrations Integrations { get; private set; }
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
        public PrefillCustomer(
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string streetAddress,
            string city,
            string postalCode,
            string country
        )
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            StreetAddress = streetAddress;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string StreetAddress { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }
    }

    public class Integrations
    {
        public Integrations(Porterbuddy porterbuddy, Instabox instabox, Helthjem helthjem)
        {
            Porterbuddy = porterbuddy;
            Instabox = instabox;
            Helthjem = helthjem;
        }

        public Porterbuddy Porterbuddy { get; private set; }
        public Instabox Instabox { get; private set; }
        public Helthjem Helthjem { get; private set; }
    }

    /// <summary>
    /// Configuration required to enable Porterbuddy logistics options
    /// </summary>
    /// <param name="PublicToken">The public key provided to you by Porterbuddy</param>
    /// <param name="ApiKey">The API key provided to you by Porterbuddy</param>
    /// <param name="Origin">Information about the sender</param>
    public class Porterbuddy
    {
        public Porterbuddy(string publicToken, string apiKey, PorterbuddyOrigin origin)
        {
            PublicToken = publicToken;
            ApiKey = apiKey;
            Origin = origin;
        }

        public string PublicToken { get; private set; }
        public string ApiKey { get; private set; }
        public PorterbuddyOrigin Origin { get; private set; }
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
        public PorterbuddyOrigin(
            string name,
            string email,
            string phoneNumber,
            PorterbuddyOriginAddress address
        )
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public PorterbuddyOriginAddress Address { get; private set; }
    }

    /// <param name="StreetAddress">Example: "Robert Levins gate 5"</param>
    /// <param name="PostalCode">Example: "0154"</param>
    /// <param name="City">Example: "Oslo"</param>
    /// <param name="Country">The ISO-3166-1 Alpha-2 representation of the country. Example: "NO"</param>
    public class PorterbuddyOriginAddress
    {
        public PorterbuddyOriginAddress(
            string streetAddress,
            string postalCode,
            string city,
            string country
        )
        {
            StreetAddress = streetAddress;
            PostalCode = postalCode;
            City = city;
            Country = country;
        }

        public string StreetAddress { get; private set; }
        public string PostalCode { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
    }

    /// <summary>
    /// Configuration required to enable Instabox logistics options
    /// </summary>
    /// <param name="ClientId">The client id provided to you by Instabox</param>
    /// <param name="ClientSecret">The client secret provided to you by Instabox</param>
    public class Instabox
    {
        public Instabox(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public string ClientId { get; private set; }
        public string ClientSecret { get; private set; }
    }

    /// <summary>
    /// Configuration required to enable Helthjem logistics options
    /// </summary>
    /// <param name="Username">The Username provided to you by Helthjem</param>
    /// <param name="Password">The Password provided to you by Helthjem</param>
    /// <param name="ShopId">The ShopId provided to you by Helthjem</param>
    public class Helthjem
    {
        public Helthjem(string username, string password, int shopId)
        {
            Username = username;
            Password = password;
            ShopId = shopId;
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public int ShopId { get; private set; }
    }
}
