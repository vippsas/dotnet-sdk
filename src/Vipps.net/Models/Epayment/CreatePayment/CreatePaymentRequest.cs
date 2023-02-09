using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.CreatePaymentRequest;

public class CreatePaymentRequest : VippsRequest
{
    [property: JsonPropertyName("amount")]
    public Amount Amount { get; init; }

    [property: JsonPropertyName("directCapture")]
    public bool? DirectCapture { get; init; }

    [property: JsonPropertyName("customer")]
    public Customer Customer { get; init; }

    [property: JsonPropertyName("customerInteraction")]
    public string CustomerInteraction { get; init; }

    [property: JsonPropertyName("industryData")]
    public IndustryData IndustryData { get; init; }

    [property: JsonPropertyName("receipt")]
    public Receipt Receipt { get; init; }

    [property: JsonPropertyName("paymentMethod")]
    public PaymentMethod PaymentMethod { get; init; }

    [property: JsonPropertyName("profile")]
    public Profile Profile { get; init; }

    [property: JsonPropertyName("reference")]
    public string Reference { get; init; }

    [property: JsonPropertyName("returnUrl")]
    public string ReturnUrl { get; init; }

    [property: JsonPropertyName("userFlow")]
    public string UserFlow { get; init; }

    [property: JsonPropertyName("expiresAt")]
    public DateTime? ExpiresAt { get; init; }

    [property: JsonPropertyName("qrFormat")]
    public QrFormat QrFormat { get; init; }

    [property: JsonPropertyName("paymentDescription")]
    public string PaymentDescription { get; init; }
}

public class AirlineData
{
    [property: JsonPropertyName("agencyInvoiceNumber")]
    public string AgencyInvoiceNumber { get; init; }

    [property: JsonPropertyName("airlineCode")]
    public string AirlineCode { get; init; }

    [property: JsonPropertyName("airlineDesignatorCode")]
    public string AirlineDesignatorCode { get; init; }

    [property: JsonPropertyName("passengerName")]
    public string PassengerName { get; init; }

    [property: JsonPropertyName("ticketNumber")]
    public string TicketNumber { get; init; }
}

public class Amount
{
    [property: JsonPropertyName("currency")]
    public string Currency { get; init; }

    [property: JsonPropertyName("value")]
    public int? Value { get; init; }
}

public class BottomLine
{
    [property: JsonPropertyName("currency")]
    public string Currency { get; init; }

    [property: JsonPropertyName("tipAmount")]
    public int? TipAmount { get; init; }

    [property: JsonPropertyName("giftCardAmount")]
    public int? GiftCardAmount { get; init; }

    [property: JsonPropertyName("terminalId")]
    public string TerminalId { get; init; }

    [property: JsonPropertyName("totalAmount")]
    public int? TotalAmount { get; init; }

    [property: JsonPropertyName("totalTax")]
    public int? TotalTax { get; init; }

    [property: JsonPropertyName("totalDiscount")]
    public int? TotalDiscount { get; init; }

    [property: JsonPropertyName("shippingAmount")]
    public int? ShippingAmount { get; init; }

    [property: JsonPropertyName("shippingInfo")]
    public ShippingInfo ShippingInfo { get; init; }
}

public class Customer
{
    [property: JsonPropertyName("phoneNumber")]
    public long? PhoneNumber { get; init; }
}

public class IndustryData
{
    [property: JsonPropertyName("airlineData")]
    public AirlineData AirlineData { get; init; }
}

public class OrderLine
{
    [property: JsonPropertyName("name")]
    public string Name { get; init; }

    [property: JsonPropertyName("id")]
    public string Id { get; init; }

    [property: JsonPropertyName("totalAmount")]
    public int? TotalAmount { get; init; }

    [property: JsonPropertyName("totalAmountExcludingTax")]
    public int? TotalAmountExcludingTax { get; init; }

    [property: JsonPropertyName("totalTaxAmount")]
    public int? TotalTaxAmount { get; init; }

    [property: JsonPropertyName("taxPercentage")]
    public int? TaxPercentage { get; init; }

    [property: JsonPropertyName("unitInfo")]
    public UnitInfo UnitInfo { get; init; }

    [property: JsonPropertyName("discount")]
    public int? Discount { get; init; }

    [property: JsonPropertyName("productUrl")]
    public string ProductUrl { get; init; }

    [property: JsonPropertyName("isReturn")]
    public bool? IsReturn { get; init; }

    [property: JsonPropertyName("isShipping")]
    public bool? IsShipping { get; init; }
}

public class PaymentMethod
{
    [property: JsonPropertyName("type")]
    public string Type { get; init; }
}

public class Profile
{
    [property: JsonPropertyName("scope")]
    public string Scope { get; init; }
}

public class QrFormat
{
    [property: JsonPropertyName("format")]
    public string Format { get; init; }

    [property: JsonPropertyName("size")]
    public int? Size { get; init; }
}

public class Receipt
{
    [property: JsonPropertyName("orderLines")]
    public IReadOnlyList<OrderLine> OrderLines { get; init; }

    [property: JsonPropertyName("bottomLine")]
    public BottomLine BottomLine { get; init; }
}

public class ShippingInfo
{
    [property: JsonPropertyName("amount")]
    public int? Amount { get; init; }

    [property: JsonPropertyName("amountExcludingTax")]
    public int? AmountExcludingTax { get; init; }

    [property: JsonPropertyName("taxAmount")]
    public int? TaxAmount { get; init; }

    [property: JsonPropertyName("taxPercentage")]
    public int? TaxPercentage { get; init; }
}

public class UnitInfo
{
    [property: JsonPropertyName("unitPrice")]
    public int? UnitPrice { get; init; }

    [property: JsonPropertyName("quantity")]
    public string Quantity { get; init; }

    [property: JsonPropertyName("quantityUnit")]
    public string QuantityUnit { get; init; }
}
