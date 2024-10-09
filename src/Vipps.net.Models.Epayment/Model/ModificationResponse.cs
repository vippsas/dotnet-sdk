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
    /// ModificationResponse
    /// </summary>
    [DataContract(Name = "ModificationResponse")]
    public partial class ModificationResponse : IValidatableObject
    {

        /// <summary>
        /// Gets or Sets State
        /// </summary>
        [DataMember(Name = "state", IsRequired = true, EmitDefaultValue = true)]
        public State State { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ModificationResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ModificationResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ModificationResponse" /> class.
        /// </summary>
        /// <param name="amount">amount (required).</param>
        /// <param name="state">state (required).</param>
        /// <param name="aggregate">aggregate (required).</param>
        /// <param name="pspReference">Reference value for a payment, defined by Vipps MobilePay. (required).</param>
        /// <param name="reference">The &#x60;reference&#x60; is the unique identifier for the payment, specified when initiating the payment. The reference must be unique for the sales unit (MSN), but is not _globally_ unique, so several MSNs may use the same reference. See the [recommendations](/docs/knowledge-base/orderid/). (required).</param>
        public ModificationResponse(Amount amount = default(Amount), State state = default(State), Aggregate aggregate = default(Aggregate), string pspReference = default(string), string reference = default(string))
        {
            // to ensure "amount" is required (not null)
            if (amount == null)
            {
                throw new ArgumentNullException("amount is a required property for ModificationResponse and cannot be null");
            }
            this.Amount = amount;
            this.State = state;
            // to ensure "aggregate" is required (not null)
            if (aggregate == null)
            {
                throw new ArgumentNullException("aggregate is a required property for ModificationResponse and cannot be null");
            }
            this.Aggregate = aggregate;
            // to ensure "pspReference" is required (not null)
            if (pspReference == null)
            {
                throw new ArgumentNullException("pspReference is a required property for ModificationResponse and cannot be null");
            }
            this.PspReference = pspReference;
            // to ensure "reference" is required (not null)
            if (reference == null)
            {
                throw new ArgumentNullException("reference is a required property for ModificationResponse and cannot be null");
            }
            this.Reference = reference;
        }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name = "amount", IsRequired = true, EmitDefaultValue = true)]
        public Amount Amount { get; set; }

        /// <summary>
        /// Gets or Sets Aggregate
        /// </summary>
        [DataMember(Name = "aggregate", IsRequired = true, EmitDefaultValue = true)]
        public Aggregate Aggregate { get; set; }

        /// <summary>
        /// Reference value for a payment, defined by Vipps MobilePay.
        /// </summary>
        /// <value>Reference value for a payment, defined by Vipps MobilePay.</value>
        [DataMember(Name = "pspReference", IsRequired = true, EmitDefaultValue = true)]
        public string PspReference { get; set; }

        /// <summary>
        /// The &#x60;reference&#x60; is the unique identifier for the payment, specified when initiating the payment. The reference must be unique for the sales unit (MSN), but is not _globally_ unique, so several MSNs may use the same reference. See the [recommendations](/docs/knowledge-base/orderid/).
        /// </summary>
        /// <value>The &#x60;reference&#x60; is the unique identifier for the payment, specified when initiating the payment. The reference must be unique for the sales unit (MSN), but is not _globally_ unique, so several MSNs may use the same reference. See the [recommendations](/docs/knowledge-base/orderid/).</value>
        /*
        <example>acme-shop-123-order123abc</example>
        */
        [DataMember(Name = "reference", IsRequired = true, EmitDefaultValue = true)]
        public string Reference { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ModificationResponse {\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  Aggregate: ").Append(Aggregate).Append("\n");
            sb.Append("  PspReference: ").Append(PspReference).Append("\n");
            sb.Append("  Reference: ").Append(Reference).Append("\n");
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
            // Reference (string) maxLength
            if (this.Reference != null && this.Reference.Length > 50)
            {
                yield return new ValidationResult("Invalid value for Reference, length must be less than 50.", new [] { "Reference" });
            }

            // Reference (string) minLength
            if (this.Reference != null && this.Reference.Length < 8)
            {
                yield return new ValidationResult("Invalid value for Reference, length must be greater than 8.", new [] { "Reference" });
            }

            if (this.Reference != null) {
                // Reference (string) pattern
                Regex regexReference = new Regex(@"^[a-zA-Z0-9-]{8,50}$", RegexOptions.CultureInvariant);
                if (!regexReference.Match(this.Reference).Success)
                {
                    yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Reference, must match a pattern of " + regexReference, new [] { "Reference" });
                }
            }

            yield break;
        }
    }

}
