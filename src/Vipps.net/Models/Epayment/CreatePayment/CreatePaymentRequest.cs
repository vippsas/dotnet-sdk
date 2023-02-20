using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Vipps.Models.Epayment.CreatePaymentRequest
{
    public class CreatePaymentRequest : VippsRequest
    {
        [property: JsonProperty("amount")]
        [Required]
        public Amount Amount { get; set; }

        [property: JsonProperty("directCapture")]
        [Required]
        public bool DirectCapture { get; set; }

        [property: JsonProperty("customer")]
        public Customer Customer { get; set; }

        [property: JsonProperty("customerInteraction")]
        [Required]
        public string CustomerInteraction { get; set; }

        [property: JsonProperty("industryData")]
        public IndustryData IndustryData { get; set; }

        [property: JsonProperty("receipt")]
        public Receipt Receipt { get; set; }

        [property: JsonProperty("paymentMethod")]
        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [property: JsonProperty("profile")]
        public Profile Profile { get; set; }

        [property: JsonProperty("reference")]
        [Required]
        public string Reference { get; set; }

        [property: JsonProperty("returnUrl")]
        [Required]
        public string ReturnUrl { get; set; }

        [property: JsonProperty("userFlow")]
        public string UserFlow { get; set; }

        [property: JsonProperty("expiresAt")]
        public DateTime ExpiresAt { get; set; }

        [property: JsonProperty("qrFormat")]
        public QrFormat QrFormat { get; set; }

        [property: JsonProperty("paymentDescription")]
        [Required]
        public string PaymentDescription { get; set; }
    }

    public class AirlineData
    {
        [property: JsonProperty("agencyInvoiceNumber")]
        public string AgencyInvoiceNumber { get; set; }

        [property: JsonProperty("airlineCode")]
        public string AirlineCode { get; set; }

        [property: JsonProperty("airlineDesignatorCode")]
        public string AirlineDesignatorCode { get; set; }

        [property: JsonProperty("passengerName")]
        public string PassengerName { get; set; }

        [property: JsonProperty("ticketNumber")]
        public string TicketNumber { get; set; }
    }

    public class Amount
    {
        [property: JsonProperty("currency")]
        public string Currency { get; set; }

        [property: JsonProperty("value")]
        public int? Value { get; set; }
    }

    public class BottomLine
    {
        [property: JsonProperty("currency")]
        public string Currency { get; set; }

        [property: JsonProperty("tipAmount")]
        public int? TipAmount { get; set; }

        [property: JsonProperty("giftCardAmount")]
        public int? GiftCardAmount { get; set; }

        [property: JsonProperty("terminalId")]
        public string TerminalId { get; set; }

        [property: JsonProperty("totalAmount")]
        public int? TotalAmount { get; set; }

        [property: JsonProperty("totalTax")]
        public int? TotalTax { get; set; }

        [property: JsonProperty("totalDiscount")]
        public int? TotalDiscount { get; set; }

        [property: JsonProperty("shippingAmount")]
        public int? ShippingAmount { get; set; }

        [property: JsonProperty("shippingInfo")]
        public ShippingInfo ShippingInfo { get; set; }
    }

    public class Customer
    {
        [property: JsonProperty("phoneNumber")]
        public long? PhoneNumber { get; set; }
    }

    public class IndustryData
    {
        [property: JsonProperty("airlineData")]
        public AirlineData AirlineData { get; set; }
    }

    public class OrderLine
    {
        [property: JsonProperty("name")]
        public string Name { get; set; }

        [property: JsonProperty("id")]
        public string Id { get; set; }

        [property: JsonProperty("totalAmount")]
        public int? TotalAmount { get; set; }

        [property: JsonProperty("totalAmountExcludingTax")]
        public int? TotalAmountExcludingTax { get; set; }

        [property: JsonProperty("totalTaxAmount")]
        public int? TotalTaxAmount { get; set; }

        [property: JsonProperty("taxPercentage")]
        public int? TaxPercentage { get; set; }

        [property: JsonProperty("unitInfo")]
        public UnitInfo UnitInfo { get; set; }

        [property: JsonProperty("discount")]
        public int? Discount { get; set; }

        [property: JsonProperty("productUrl")]
        public string ProductUrl { get; set; }

        [property: JsonProperty("isReturn")]
        public bool? IsReturn { get; set; }

        [property: JsonProperty("isShipping")]
        public bool? IsShipping { get; set; }
    }

    public class PaymentMethod
    {
        [property: JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Profile
    {
        [property: JsonProperty("scope")]
        public string Scope { get; set; }
    }

    public class QrFormat
    {
        [property: JsonProperty("format")]
        public string Format { get; set; }

        [property: JsonProperty("size")]
        public int? Size { get; set; }
    }

    public class Receipt
    {
        [property: JsonProperty("orderLines")]
        public IReadOnlyList<OrderLine> OrderLines { get; set; }

        [property: JsonProperty("bottomLine")]
        public BottomLine BottomLine { get; set; }
    }

    public class ShippingInfo
    {
        [property: JsonProperty("amount")]
        public int? Amount { get; set; }

        [property: JsonProperty("amountExcludingTax")]
        public int? AmountExcludingTax { get; set; }

        [property: JsonProperty("taxAmount")]
        public int? TaxAmount { get; set; }

        [property: JsonProperty("taxPercentage")]
        public int? TaxPercentage { get; set; }
    }

    public class UnitInfo
    {
        [property: JsonProperty("unitPrice")]
        public int? UnitPrice { get; set; }

        [property: JsonProperty("quantity")]
        public string Quantity { get; set; }

        [property: JsonProperty("quantityUnit")]
        public string QuantityUnit { get; set; }
    }
}
