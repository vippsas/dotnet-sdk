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
        public Amount Amount { get; private set; }

        [property: JsonPropertyName("directCapture")]
        [Required]
        public bool DirectCapture { get; private set; }

        [property: JsonPropertyName("customer")]
        public Customer Customer { get; private set; }

        [property: JsonPropertyName("customerInteraction")]
        [Required]
        public string CustomerInteraction { get; private set; }

        [property: JsonPropertyName("industryData")]
        public IndustryData IndustryData { get; private set; }

        [property: JsonPropertyName("receipt")]
        public Receipt Receipt { get; private set; }

        [property: JsonPropertyName("paymentMethod")]
        [Required]
        public PaymentMethod PaymentMethod { get; private set; }

        [property: JsonPropertyName("profile")]
        public Profile Profile { get; private set; }

        [property: JsonPropertyName("reference")]
        [Required]
        public string Reference { get; private set; }

        [property: JsonPropertyName("returnUrl")]
        [Required]
        public string ReturnUrl { get; private set; }

        [property: JsonPropertyName("userFlow")]
        public string UserFlow { get; private set; }

        [property: JsonPropertyName("expiresAt")]
        public DateTime ExpiresAt { get; private set; }

        [property: JsonPropertyName("qrFormat")]
        public QrFormat QrFormat { get; private set; }

        [property: JsonPropertyName("paymentDescription")]
        [Required]
        public string PaymentDescription { get; private set; }
    }

    public class AirlineData
    {
        [property: JsonPropertyName("agencyInvoiceNumber")]
        public string AgencyInvoiceNumber { get; private set; }

        [property: JsonPropertyName("airlineCode")]
        public string AirlineCode { get; private set; }

        [property: JsonPropertyName("airlineDesignatorCode")]
        public string AirlineDesignatorCode { get; private set; }

        [property: JsonPropertyName("passengerName")]
        public string PassengerName { get; private set; }

        [property: JsonPropertyName("ticketNumber")]
        public string TicketNumber { get; private set; }
    }

    public class Amount
    {
        [property: JsonPropertyName("currency")]
        public string Currency { get; private set; }

        [property: JsonPropertyName("value")]
        public int? Value { get; private set; }
    }

    public class BottomLine
    {
        [property: JsonPropertyName("currency")]
        public string Currency { get; private set; }

        [property: JsonPropertyName("tipAmount")]
        public int? TipAmount { get; private set; }

        [property: JsonPropertyName("giftCardAmount")]
        public int? GiftCardAmount { get; private set; }

        [property: JsonPropertyName("terminalId")]
        public string TerminalId { get; private set; }

        [property: JsonPropertyName("totalAmount")]
        public int? TotalAmount { get; private set; }

        [property: JsonPropertyName("totalTax")]
        public int? TotalTax { get; private set; }

        [property: JsonPropertyName("totalDiscount")]
        public int? TotalDiscount { get; private set; }

        [property: JsonPropertyName("shippingAmount")]
        public int? ShippingAmount { get; private set; }

        [property: JsonPropertyName("shippingInfo")]
        public ShippingInfo ShippingInfo { get; private set; }
    }

    public class Customer
    {
        [property: JsonPropertyName("phoneNumber")]
        public long? PhoneNumber { get; private set; }
    }

    public class IndustryData
    {
        [property: JsonPropertyName("airlineData")]
        public AirlineData AirlineData { get; private set; }
    }

    public class OrderLine
    {
        [property: JsonPropertyName("name")]
        public string Name { get; private set; }

        [property: JsonPropertyName("id")]
        public string Id { get; private set; }

        [property: JsonPropertyName("totalAmount")]
        public int? TotalAmount { get; private set; }

        [property: JsonPropertyName("totalAmountExcludingTax")]
        public int? TotalAmountExcludingTax { get; private set; }

        [property: JsonPropertyName("totalTaxAmount")]
        public int? TotalTaxAmount { get; private set; }

        [property: JsonPropertyName("taxPercentage")]
        public int? TaxPercentage { get; private set; }

        [property: JsonPropertyName("unitInfo")]
        public UnitInfo UnitInfo { get; private set; }

        [property: JsonPropertyName("discount")]
        public int? Discount { get; private set; }

        [property: JsonPropertyName("productUrl")]
        public string ProductUrl { get; private set; }

        [property: JsonPropertyName("isReturn")]
        public bool? IsReturn { get; private set; }

        [property: JsonPropertyName("isShipping")]
        public bool? IsShipping { get; private set; }
    }

    public class PaymentMethod
    {
        [property: JsonPropertyName("type")]
        public string Type { get; private set; }
    }

    public class Profile
    {
        [property: JsonPropertyName("scope")]
        public string Scope { get; private set; }
    }

    public class QrFormat
    {
        [property: JsonPropertyName("format")]
        public string Format { get; private set; }

        [property: JsonPropertyName("size")]
        public int? Size { get; private set; }
    }

    public class Receipt
    {
        [property: JsonPropertyName("orderLines")]
        public IReadOnlyList<OrderLine> OrderLines { get; private set; }

        [property: JsonPropertyName("bottomLine")]
        public BottomLine BottomLine { get; private set; }
    }

    public class ShippingInfo
    {
        [property: JsonPropertyName("amount")]
        public int? Amount { get; private set; }

        [property: JsonPropertyName("amountExcludingTax")]
        public int? AmountExcludingTax { get; private set; }

        [property: JsonPropertyName("taxAmount")]
        public int? TaxAmount { get; private set; }

        [property: JsonPropertyName("taxPercentage")]
        public int? TaxPercentage { get; private set; }
    }

    public class UnitInfo
    {
        [property: JsonPropertyName("unitPrice")]
        public int? UnitPrice { get; private set; }

        [property: JsonPropertyName("quantity")]
        public string Quantity { get; private set; }

        [property: JsonPropertyName("quantityUnit")]
        public string QuantityUnit { get; private set; }
    }
}
