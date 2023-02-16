using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.CreatePaymentRequest
{
    public class CreatePaymentRequest : VippsRequest
    {
        [property: JsonPropertyName("amount")]
        [Required]
        public Amount Amount { get; set; }

        [property: JsonPropertyName("directCapture")]
        [Required]
        public bool DirectCapture { get; set; }

        [property: JsonPropertyName("customer")]
        public Customer Customer { get; set; }

        [property: JsonPropertyName("customerInteraction")]
        [Required]
        public string CustomerInteraction { get; set; }

        [property: JsonPropertyName("industryData")]
        public IndustryData IndustryData { get; set; }

        [property: JsonPropertyName("receipt")]
        public Receipt Receipt { get; set; }

        [property: JsonPropertyName("paymentMethod")]
        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [property: JsonPropertyName("profile")]
        public Profile Profile { get; set; }

        [property: JsonPropertyName("reference")]
        [Required]
        public string Reference { get; set; }

        [property: JsonPropertyName("returnUrl")]
        [Required]
        public string ReturnUrl { get; set; }

        [property: JsonPropertyName("userFlow")]
        public string UserFlow { get; set; }

        [property: JsonPropertyName("expiresAt")]
        public DateTime ExpiresAt { get; set; }

        [property: JsonPropertyName("qrFormat")]
        public QrFormat QrFormat { get; set; }

        [property: JsonPropertyName("paymentDescription")]
        [Required]
        public string PaymentDescription { get; set; }
    }

    public class AirlineData
    {
        [property: JsonPropertyName("agencyInvoiceNumber")]
        public string AgencyInvoiceNumber { get; set; }

        [property: JsonPropertyName("airlineCode")]
        public string AirlineCode { get; set; }

        [property: JsonPropertyName("airlineDesignatorCode")]
        public string AirlineDesignatorCode { get; set; }

        [property: JsonPropertyName("passengerName")]
        public string PassengerName { get; set; }

        [property: JsonPropertyName("ticketNumber")]
        public string TicketNumber { get; set; }
    }

    public class Amount
    {
        [property: JsonPropertyName("currency")]
        public string Currency { get; set; }

        [property: JsonPropertyName("value")]
        public int? Value { get; set; }
    }

    public class BottomLine
    {
        [property: JsonPropertyName("currency")]
        public string Currency { get; set; }

        [property: JsonPropertyName("tipAmount")]
        public int? TipAmount { get; set; }

        [property: JsonPropertyName("giftCardAmount")]
        public int? GiftCardAmount { get; set; }

        [property: JsonPropertyName("terminalId")]
        public string TerminalId { get; set; }

        [property: JsonPropertyName("totalAmount")]
        public int? TotalAmount { get; set; }

        [property: JsonPropertyName("totalTax")]
        public int? TotalTax { get; set; }

        [property: JsonPropertyName("totalDiscount")]
        public int? TotalDiscount { get; set; }

        [property: JsonPropertyName("shippingAmount")]
        public int? ShippingAmount { get; set; }

        [property: JsonPropertyName("shippingInfo")]
        public ShippingInfo ShippingInfo { get; set; }
    }

    public class Customer
    {
        [property: JsonPropertyName("phoneNumber")]
        public long? PhoneNumber { get; set; }
    }

    public class IndustryData
    {
        [property: JsonPropertyName("airlineData")]
        public AirlineData AirlineData { get; set; }
    }

    public class OrderLine
    {
        [property: JsonPropertyName("name")]
        public string Name { get; set; }

        [property: JsonPropertyName("id")]
        public string Id { get; set; }

        [property: JsonPropertyName("totalAmount")]
        public int? TotalAmount { get; set; }

        [property: JsonPropertyName("totalAmountExcludingTax")]
        public int? TotalAmountExcludingTax { get; set; }

        [property: JsonPropertyName("totalTaxAmount")]
        public int? TotalTaxAmount { get; set; }

        [property: JsonPropertyName("taxPercentage")]
        public int? TaxPercentage { get; set; }

        [property: JsonPropertyName("unitInfo")]
        public UnitInfo UnitInfo { get; set; }

        [property: JsonPropertyName("discount")]
        public int? Discount { get; set; }

        [property: JsonPropertyName("productUrl")]
        public string ProductUrl { get; set; }

        [property: JsonPropertyName("isReturn")]
        public bool? IsReturn { get; set; }

        [property: JsonPropertyName("isShipping")]
        public bool? IsShipping { get; set; }
    }

    public class PaymentMethod
    {
        [property: JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class Profile
    {
        [property: JsonPropertyName("scope")]
        public string Scope { get; set; }
    }

    public class QrFormat
    {
        [property: JsonPropertyName("format")]
        public string Format { get; set; }

        [property: JsonPropertyName("size")]
        public int? Size { get; set; }
    }

    public class Receipt
    {
        [property: JsonPropertyName("orderLines")]
        public IReadOnlyList<OrderLine> OrderLines { get; set; }

        [property: JsonPropertyName("bottomLine")]
        public BottomLine BottomLine { get; set; }
    }

    public class ShippingInfo
    {
        [property: JsonPropertyName("amount")]
        public int? Amount { get; set; }

        [property: JsonPropertyName("amountExcludingTax")]
        public int? AmountExcludingTax { get; set; }

        [property: JsonPropertyName("taxAmount")]
        public int? TaxAmount { get; set; }

        [property: JsonPropertyName("taxPercentage")]
        public int? TaxPercentage { get; set; }
    }

    public class UnitInfo
    {
        [property: JsonPropertyName("unitPrice")]
        public int? UnitPrice { get; set; }

        [property: JsonPropertyName("quantity")]
        public string Quantity { get; set; }

        [property: JsonPropertyName("quantityUnit")]
        public string QuantityUnit { get; set; }
    }
}
