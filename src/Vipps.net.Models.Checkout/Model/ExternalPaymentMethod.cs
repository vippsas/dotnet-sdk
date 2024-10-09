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
    /// Configuration for showing and enabling external payment methods in the checkout.
    /// </summary>
    [DataContract(Name = "ExternalPaymentMethod")]
    public partial class ExternalPaymentMethod : IValidatableObject
    {

        /// <summary>
        /// Identifier for the payment method, needs to match that of the allowed list defined in the docs
        /// </summary>
        /// <value>Identifier for the payment method, needs to match that of the allowed list defined in the docs</value>
        [DataMember(Name = "paymentMethod", IsRequired = true, EmitDefaultValue = true)]
        public ExternalPaymentMethodType PaymentMethod { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalPaymentMethod" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ExternalPaymentMethod() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalPaymentMethod" /> class.
        /// </summary>
        /// <param name="paymentMethod">Identifier for the payment method, needs to match that of the allowed list defined in the docs (required).</param>
        /// <param name="redirectUrl">URL to redirect the customer to finish the payment (required).</param>
        public ExternalPaymentMethod(ExternalPaymentMethodType paymentMethod = default(ExternalPaymentMethodType), string redirectUrl = default(string))
        {
            this.PaymentMethod = paymentMethod;
            // to ensure "redirectUrl" is required (not null)
            if (redirectUrl == null)
            {
                throw new ArgumentNullException("redirectUrl is a required property for ExternalPaymentMethod and cannot be null");
            }
            this.RedirectUrl = redirectUrl;
        }

        /// <summary>
        /// URL to redirect the customer to finish the payment
        /// </summary>
        /// <value>URL to redirect the customer to finish the payment</value>
        [DataMember(Name = "redirectUrl", IsRequired = true, EmitDefaultValue = true)]
        public string RedirectUrl { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ExternalPaymentMethod {\n");
            sb.Append("  PaymentMethod: ").Append(PaymentMethod).Append("\n");
            sb.Append("  RedirectUrl: ").Append(RedirectUrl).Append("\n");
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
