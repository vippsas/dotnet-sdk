using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.CreatePaymentRequest
{
    public record AirlineData(
        [property: JsonPropertyName("agencyInvoiceNumber")] string AgencyInvoiceNumber,
        [property: JsonPropertyName("airlineCode")] string AirlineCode,
        [property: JsonPropertyName("airlineDesignatorCode")] string AirlineDesignatorCode,
        [property: JsonPropertyName("passengerName")] string PassengerName,
        [property: JsonPropertyName("ticketNumber")] string TicketNumber
    );

    public record Amount(
        [property: JsonPropertyName("currency")] string Currency,
        [property: JsonPropertyName("value")] int? Value
    );

    public record BottomLine(
        [property: JsonPropertyName("currency")] string Currency,
        [property: JsonPropertyName("tipAmount")] int? TipAmount,
        [property: JsonPropertyName("giftCardAmount")] int? GiftCardAmount,
        [property: JsonPropertyName("terminalId")] string TerminalId,
        [property: JsonPropertyName("totalAmount")] int? TotalAmount,
        [property: JsonPropertyName("totalTax")] int? TotalTax,
        [property: JsonPropertyName("totalDiscount")] int? TotalDiscount,
        [property: JsonPropertyName("shippingAmount")] int? ShippingAmount,
        [property: JsonPropertyName("shippingInfo")] ShippingInfo ShippingInfo
    );

    public record Customer(
        [property: JsonPropertyName("phoneNumber")] long? PhoneNumber
    );

    public record IndustryData(
        [property: JsonPropertyName("airlineData")] AirlineData AirlineData
    );

    public record OrderLine(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("totalAmount")] int? TotalAmount,
        [property: JsonPropertyName("totalAmountExcludingTax")] int? TotalAmountExcludingTax,
        [property: JsonPropertyName("totalTaxAmount")] int? TotalTaxAmount,
        [property: JsonPropertyName("taxPercentage")] int? TaxPercentage,
        [property: JsonPropertyName("unitInfo")] UnitInfo UnitInfo,
        [property: JsonPropertyName("discount")] int? Discount,
        [property: JsonPropertyName("productUrl")] string ProductUrl,
        [property: JsonPropertyName("isReturn")] bool? IsReturn,
        [property: JsonPropertyName("isShipping")] bool? IsShipping
    );

    public record PaymentMethod(
        [property: JsonPropertyName("type")] string Type
    );

    public record Profile(
        [property: JsonPropertyName("scope")] string Scope
    );

    public record QrFormat(
        [property: JsonPropertyName("format")] string Format,
        [property: JsonPropertyName("size")] int? Size
    );

    public record Receipt(
        [property: JsonPropertyName("orderLines")] IReadOnlyList<OrderLine> OrderLines,
        [property: JsonPropertyName("bottomLine")] BottomLine BottomLine
    );

    public record CreatePaymentRequest(
        [property: JsonPropertyName("amount")] Amount Amount,
        [property: JsonPropertyName("directCapture")] bool? DirectCapture,
        [property: JsonPropertyName("customer")] Customer Customer,
        [property: JsonPropertyName("customerInteraction")] string CustomerInteraction,
        [property: JsonPropertyName("industryData")] IndustryData IndustryData,
        [property: JsonPropertyName("receipt")] Receipt Receipt,
        [property: JsonPropertyName("paymentMethod")] PaymentMethod PaymentMethod,
        [property: JsonPropertyName("profile")] Profile Profile,
        [property: JsonPropertyName("reference")] string Reference,
        [property: JsonPropertyName("returnUrl")] string ReturnUrl,
        [property: JsonPropertyName("userFlow")] string UserFlow,
        [property: JsonPropertyName("expiresAt")] DateTime? ExpiresAt,
        [property: JsonPropertyName("qrFormat")] QrFormat QrFormat,
        [property: JsonPropertyName("paymentDescription")] string PaymentDescription
    );

    public record ShippingInfo(
        [property: JsonPropertyName("amount")] int? Amount,
        [property: JsonPropertyName("amountExcludingTax")] int? AmountExcludingTax,
        [property: JsonPropertyName("taxAmount")] int? TaxAmount,
        [property: JsonPropertyName("taxPercentage")] int? TaxPercentage
    );

    public record UnitInfo(
        [property: JsonPropertyName("unitPrice")] int? UnitPrice,
        [property: JsonPropertyName("quantity")] string Quantity,
        [property: JsonPropertyName("quantityUnit")] string QuantityUnit
    );


}
