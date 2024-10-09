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
    /// PaymentMethodResponse
    /// </summary>
    [DataContract(Name = "PaymentMethodResponse")]
    public partial class PaymentMethodResponse : IValidatableObject
    {

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public PaymentMethodType Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentMethodResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PaymentMethodResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentMethodResponse" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="cardBin">The payment card&#39;s Bank Identification Number (BIN), that identifies which bank has issued the card..</param>
        public PaymentMethodResponse(PaymentMethodType type = default(PaymentMethodType), string cardBin = default(string))
        {
            this.Type = type;
            this.CardBin = cardBin;
        }

        /// <summary>
        /// The payment card&#39;s Bank Identification Number (BIN), that identifies which bank has issued the card.
        /// </summary>
        /// <value>The payment card&#39;s Bank Identification Number (BIN), that identifies which bank has issued the card.</value>
        /*
        <example>540185</example>
        */
        [DataMember(Name = "cardBin", EmitDefaultValue = false)]
        public string CardBin { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PaymentMethodResponse {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  CardBin: ").Append(CardBin).Append("\n");
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
            // CardBin (string) maxLength
            if (this.CardBin != null && this.CardBin.Length > 6)
            {
                yield return new ValidationResult("Invalid value for CardBin, length must be less than 6.", new [] { "CardBin" });
            }

            // CardBin (string) minLength
            if (this.CardBin != null && this.CardBin.Length < 6)
            {
                yield return new ValidationResult("Invalid value for CardBin, length must be greater than 6.", new [] { "CardBin" });
            }

            yield break;
        }
    }

}