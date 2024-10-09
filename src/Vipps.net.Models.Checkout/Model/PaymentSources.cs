/*
 * checkout-backend-merchant-v3.API
 *
 * See the [Checkout API Guide](https://developer.vippsmobilepay.com/docs/APIs/checkout-api/).
 *
 * The version of the OpenAPI document: v3
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
using OpenAPIDateConverter = Vipps.net.Models.Checkout.Client.OpenAPIDateConverter;

namespace Vipps.net.Models.Checkout.Model
{
    /// <summary>
    /// PaymentSources
    /// </summary>
    [DataContract(Name = "PaymentSources")]
    public partial class PaymentSources : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentSources" /> class.
        /// </summary>
        /// <param name="giftCard">Amount from gift card.</param>
        /// <param name="card">Amount from card.</param>
        /// <param name="voucher">Amount from voucher.</param>
        /// <param name="cash">Amount from cash.</param>
        public PaymentSources(long? giftCard = default(long?), long? card = default(long?), long? voucher = default(long?), long? cash = default(long?))
        {
            this.GiftCard = giftCard;
            this.Card = card;
            this.Voucher = voucher;
            this.Cash = cash;
        }

        /// <summary>
        /// Amount from gift card
        /// </summary>
        /// <value>Amount from gift card</value>
        [DataMember(Name = "giftCard", EmitDefaultValue = true)]
        public long? GiftCard { get; set; }

        /// <summary>
        /// Amount from card
        /// </summary>
        /// <value>Amount from card</value>
        [DataMember(Name = "card", EmitDefaultValue = true)]
        public long? Card { get; set; }

        /// <summary>
        /// Amount from voucher
        /// </summary>
        /// <value>Amount from voucher</value>
        [DataMember(Name = "voucher", EmitDefaultValue = true)]
        public long? Voucher { get; set; }

        /// <summary>
        /// Amount from cash
        /// </summary>
        /// <value>Amount from cash</value>
        [DataMember(Name = "cash", EmitDefaultValue = true)]
        public long? Cash { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PaymentSources {\n");
            sb.Append("  GiftCard: ").Append(GiftCard).Append("\n");
            sb.Append("  Card: ").Append(Card).Append("\n");
            sb.Append("  Voucher: ").Append(Voucher).Append("\n");
            sb.Append("  Cash: ").Append(Cash).Append("\n");
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
            yield break;
        }
    }

}
