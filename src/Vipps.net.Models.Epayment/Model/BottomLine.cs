/*
 * ePayment API
 *
 * The ePayment API enables you to create Vipps MobilePay payments for online and in-person payments. See the [ePayment API Guide](https://developer.vippsmobilepay.com/docs/APIs/epayment-api) for more details.
 *
 * The version of the OpenAPI document: 1.6.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Vipps.net.Models.Epayment.Client.OpenAPIDateConverter;

namespace Vipps.net.Models.Epayment.Model
{
    /// <summary>
    /// Summary of the order. Total amount and total. Amounts are specified in minor units (i.e., integers with two trailing zeros). For example: 10.00 EUR/NOK/DKK should be written as 1000.
    /// </summary>
    [DataContract(Name = "BottomLine")]
    public partial class BottomLine : IValidatableObject
    {

        /// <summary>
        /// Gets or Sets Currency
        /// </summary>
        [DataMember(Name = "currency", IsRequired = true, EmitDefaultValue = true)]
        public CurrencyEnum Currency { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="BottomLine" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected BottomLine() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="BottomLine" /> class.
        /// </summary>
        /// <param name="currency">currency (required).</param>
        /// <param name="tipAmount">Tip amount for the order. Amounts are specified in minor units (i.e., integers with two trailing zeros). For example: 10.00 EUR/NOK/DKK should be written as 1000..</param>
        /// <param name="giftCardAmount">Amount paid by gift card or coupon..</param>
        /// <param name="posId">POS ID is the device number of the POS terminal.</param>
        /// <param name="totalAmount">Deprecated, sum will be calculated based on the sum of the orderLines.</param>
        /// <param name="totalTax">Deprecated, tax will be calculated based on the sum of the totalTaxAmount field on each orderLine.</param>
        /// <param name="totalDiscount">Deprecated, discount will be calculated based on the sum of the discount field on each orderLine.</param>
        /// <param name="shippingAmount">Deprecated, use a regular orderLine with \&quot;isShipping\&quot; flag. Using this will result in faulty calculation of sum and tax..</param>
        /// <param name="shippingInfo">shippingInfo.</param>
        /// <param name="paymentSources">paymentSources.</param>
        /// <param name="barcode">barcode.</param>
        /// <param name="receiptNumber">receiptNumber.</param>
        /// <param name="terminalId">Deprecated, use \&quot;posId\&quot; instead..</param>
        public BottomLine(CurrencyEnum currency = default(CurrencyEnum), long? tipAmount = default(long?), long? giftCardAmount = default(long?), string posId = default(string), long? totalAmount = default(long?), long? totalTax = default(long?), long? totalDiscount = default(long?), long? shippingAmount = default(long?), ShippingInfo shippingInfo = default(ShippingInfo), PaymentSources paymentSources = default(PaymentSources), Barcode barcode = default(Barcode), string receiptNumber = default(string), string terminalId = default(string))
        {
            this.Currency = currency;
            this.TipAmount = tipAmount;
            this.GiftCardAmount = giftCardAmount;
            this.PosId = posId;
            this.TotalAmount = totalAmount;
            this.TotalTax = totalTax;
            this.TotalDiscount = totalDiscount;
            this.ShippingAmount = shippingAmount;
            this.ShippingInfo = shippingInfo;
            this.PaymentSources = paymentSources;
            this.Barcode = barcode;
            this.ReceiptNumber = receiptNumber;
            this.TerminalId = terminalId;
        }

        /// <summary>
        /// Tip amount for the order. Amounts are specified in minor units (i.e., integers with two trailing zeros). For example: 10.00 EUR/NOK/DKK should be written as 1000.
        /// </summary>
        /// <value>Tip amount for the order. Amounts are specified in minor units (i.e., integers with two trailing zeros). For example: 10.00 EUR/NOK/DKK should be written as 1000.</value>
        /*
        <example>2000</example>
        */
        [DataMember(Name = "tipAmount", EmitDefaultValue = true)]
        public long? TipAmount { get; set; }

        /// <summary>
        /// Amount paid by gift card or coupon.
        /// </summary>
        /// <value>Amount paid by gift card or coupon.</value>
        /*
        <example>20000</example>
        */
        [DataMember(Name = "giftCardAmount", EmitDefaultValue = true)]
        [Obsolete]
        public long? GiftCardAmount { get; set; }

        /// <summary>
        /// POS ID is the device number of the POS terminal
        /// </summary>
        /// <value>POS ID is the device number of the POS terminal</value>
        [DataMember(Name = "posId", EmitDefaultValue = true)]
        public string PosId { get; set; }

        /// <summary>
        /// Deprecated, sum will be calculated based on the sum of the orderLines
        /// </summary>
        /// <value>Deprecated, sum will be calculated based on the sum of the orderLines</value>
        [DataMember(Name = "totalAmount", EmitDefaultValue = true)]
        [Obsolete]
        public long? TotalAmount { get; set; }

        /// <summary>
        /// Deprecated, tax will be calculated based on the sum of the totalTaxAmount field on each orderLine
        /// </summary>
        /// <value>Deprecated, tax will be calculated based on the sum of the totalTaxAmount field on each orderLine</value>
        [DataMember(Name = "totalTax", EmitDefaultValue = true)]
        [Obsolete]
        public long? TotalTax { get; set; }

        /// <summary>
        /// Deprecated, discount will be calculated based on the sum of the discount field on each orderLine
        /// </summary>
        /// <value>Deprecated, discount will be calculated based on the sum of the discount field on each orderLine</value>
        [DataMember(Name = "totalDiscount", EmitDefaultValue = true)]
        [Obsolete]
        public long? TotalDiscount { get; set; }

        /// <summary>
        /// Deprecated, use a regular orderLine with \&quot;isShipping\&quot; flag. Using this will result in faulty calculation of sum and tax.
        /// </summary>
        /// <value>Deprecated, use a regular orderLine with \&quot;isShipping\&quot; flag. Using this will result in faulty calculation of sum and tax.</value>
        [DataMember(Name = "shippingAmount", EmitDefaultValue = true)]
        [Obsolete]
        public long? ShippingAmount { get; set; }

        /// <summary>
        /// Gets or Sets ShippingInfo
        /// </summary>
        [DataMember(Name = "shippingInfo", EmitDefaultValue = false)]
        [Obsolete]
        public ShippingInfo ShippingInfo { get; set; }

        /// <summary>
        /// Gets or Sets PaymentSources
        /// </summary>
        [DataMember(Name = "paymentSources", EmitDefaultValue = false)]
        public PaymentSources PaymentSources { get; set; }

        /// <summary>
        /// Gets or Sets Barcode
        /// </summary>
        [DataMember(Name = "barcode", EmitDefaultValue = false)]
        public Barcode Barcode { get; set; }

        /// <summary>
        /// Gets or Sets ReceiptNumber
        /// </summary>
        [DataMember(Name = "receiptNumber", EmitDefaultValue = true)]
        public string ReceiptNumber { get; set; }

        /// <summary>
        /// Deprecated, use \&quot;posId\&quot; instead.
        /// </summary>
        /// <value>Deprecated, use \&quot;posId\&quot; instead.</value>
        [DataMember(Name = "terminalId", EmitDefaultValue = true)]
        [Obsolete]
        public string TerminalId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BottomLine {\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  TipAmount: ").Append(TipAmount).Append("\n");
            sb.Append("  GiftCardAmount: ").Append(GiftCardAmount).Append("\n");
            sb.Append("  PosId: ").Append(PosId).Append("\n");
            sb.Append("  TotalAmount: ").Append(TotalAmount).Append("\n");
            sb.Append("  TotalTax: ").Append(TotalTax).Append("\n");
            sb.Append("  TotalDiscount: ").Append(TotalDiscount).Append("\n");
            sb.Append("  ShippingAmount: ").Append(ShippingAmount).Append("\n");
            sb.Append("  ShippingInfo: ").Append(ShippingInfo).Append("\n");
            sb.Append("  PaymentSources: ").Append(PaymentSources).Append("\n");
            sb.Append("  Barcode: ").Append(Barcode).Append("\n");
            sb.Append("  ReceiptNumber: ").Append(ReceiptNumber).Append("\n");
            sb.Append("  TerminalId: ").Append(TerminalId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            // TipAmount (long?) minimum
            if (this.TipAmount < (long?)0)
            {
                yield return new ValidationResult("Invalid value for TipAmount, must be a value greater than or equal to 0.", new [] { "TipAmount" });
            }

            // GiftCardAmount (long?) minimum
            if (this.GiftCardAmount < (long?)0)
            {
                yield return new ValidationResult("Invalid value for GiftCardAmount, must be a value greater than or equal to 0.", new [] { "GiftCardAmount" });
            }

            // TotalTax (long?) minimum
            if (this.TotalTax < (long?)0)
            {
                yield return new ValidationResult("Invalid value for TotalTax, must be a value greater than or equal to 0.", new [] { "TotalTax" });
            }

            // TotalDiscount (long?) minimum
            if (this.TotalDiscount < (long?)0)
            {
                yield return new ValidationResult("Invalid value for TotalDiscount, must be a value greater than or equal to 0.", new [] { "TotalDiscount" });
            }

            // ShippingAmount (long?) minimum
            if (this.ShippingAmount < (long?)0)
            {
                yield return new ValidationResult("Invalid value for ShippingAmount, must be a value greater than or equal to 0.", new [] { "ShippingAmount" });
            }

            yield break;
        }
    }

}
