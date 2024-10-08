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
    /// If used, displays a checkbox that can be used to ask for extra consent.
    /// </summary>
    [DataContract(Name = "CustomConsent")]
    public partial class CustomConsent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomConsent" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CustomConsent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomConsent" /> class.
        /// </summary>
        /// <param name="text">Text displayed next to the checkbox. This text can contain up to one link in markdown format like this: [linkText](https://example.com) (required).</param>
        /// <param name="required">Whether box has to be checked to complete the checkout. (required).</param>
        public CustomConsent(string text = default(string), bool required = default(bool))
        {
            // to ensure "text" is required (not null)
            if (text == null)
            {
                throw new ArgumentNullException("text is a required property for CustomConsent and cannot be null");
            }
            this.Text = text;
            this.Required = required;
        }

        /// <summary>
        /// Text displayed next to the checkbox. This text can contain up to one link in markdown format like this: [linkText](https://example.com)
        /// </summary>
        /// <value>Text displayed next to the checkbox. This text can contain up to one link in markdown format like this: [linkText](https://example.com)</value>
        [DataMember(Name = "text", IsRequired = true, EmitDefaultValue = true)]
        public string Text { get; set; }

        /// <summary>
        /// Whether box has to be checked to complete the checkout.
        /// </summary>
        /// <value>Whether box has to be checked to complete the checkout.</value>
        [DataMember(Name = "required", IsRequired = true, EmitDefaultValue = true)]
        public bool Required { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CustomConsent {\n");
            sb.Append("  Text: ").Append(Text).Append("\n");
            sb.Append("  Required: ").Append(Required).Append("\n");
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
