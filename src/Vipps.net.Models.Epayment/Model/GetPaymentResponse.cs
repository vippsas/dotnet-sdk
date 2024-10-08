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
    /// The &#x60;GetPaymentResponse&#x60; object.
    /// </summary>
    [DataContract(Name = "GetPaymentResponse")]
    public partial class GetPaymentResponse : IValidatableObject
    {

        /// <summary>
        /// Gets or Sets State
        /// </summary>
        [DataMember(Name = "state", IsRequired = true, EmitDefaultValue = true)]
        public State State { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPaymentResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetPaymentResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPaymentResponse" /> class.
        /// </summary>
        /// <param name="aggregate">aggregate (required).</param>
        /// <param name="amount">amount (required).</param>
        /// <param name="state">state (required).</param>
        /// <param name="paymentMethod">paymentMethod (required).</param>
        /// <param name="profile">profile (required).</param>
        /// <param name="pspReference">Reference value for a payment, defined by Vipps MobilePay. (required).</param>
        /// <param name="redirectUrl">The URL you should redirect the user to to continue with the payment. This is the URL to the Vipps MobilePay landing page. See: https://developer.vippsmobilepay.com/docs/knowledge-base/landing-page/.</param>
        /// <param name="reference">The &#x60;reference&#x60; is the unique identifier for the payment, specified when initiating the payment. The reference must be unique for the sales unit (MSN), but is not _globally_ unique, so several MSNs may use the same reference. See the [recommendations](/docs/knowledge-base/orderid/). (required).</param>
        /// <param name="metadata">Metadata is a key-value map that can be used to store additional information about the payment. The metadata is not used by Vipps MobilePay, but is passed through in the &#x60;GetPaymentResponse&#x60; object. Key length is limited to 100 characters, and value length is limited to 500 characters. Max capacity is 5 key-value pairs..</param>
        public GetPaymentResponse(Aggregate aggregate = default(Aggregate), Amount amount = default(Amount), State state = default(State), PaymentMethodResponse paymentMethod = default(PaymentMethodResponse), ProfileResponse profile = default(ProfileResponse), string pspReference = default(string), string redirectUrl = default(string), string reference = default(string), Dictionary<string, string> metadata = default(Dictionary<string, string>))
        {
            // to ensure "aggregate" is required (not null)
            if (aggregate == null)
            {
                throw new ArgumentNullException("aggregate is a required property for GetPaymentResponse and cannot be null");
            }
            this.Aggregate = aggregate;
            // to ensure "amount" is required (not null)
            if (amount == null)
            {
                throw new ArgumentNullException("amount is a required property for GetPaymentResponse and cannot be null");
            }
            this.Amount = amount;
            this.State = state;
            // to ensure "paymentMethod" is required (not null)
            if (paymentMethod == null)
            {
                throw new ArgumentNullException("paymentMethod is a required property for GetPaymentResponse and cannot be null");
            }
            this.PaymentMethod = paymentMethod;
            // to ensure "profile" is required (not null)
            if (profile == null)
            {
                throw new ArgumentNullException("profile is a required property for GetPaymentResponse and cannot be null");
            }
            this.Profile = profile;
            // to ensure "pspReference" is required (not null)
            if (pspReference == null)
            {
                throw new ArgumentNullException("pspReference is a required property for GetPaymentResponse and cannot be null");
            }
            this.PspReference = pspReference;
            // to ensure "reference" is required (not null)
            if (reference == null)
            {
                throw new ArgumentNullException("reference is a required property for GetPaymentResponse and cannot be null");
            }
            this.Reference = reference;
            this.RedirectUrl = redirectUrl;
            this.Metadata = metadata;
        }

        /// <summary>
        /// Gets or Sets Aggregate
        /// </summary>
        [DataMember(Name = "aggregate", IsRequired = true, EmitDefaultValue = true)]
        public Aggregate Aggregate { get; set; }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name = "amount", IsRequired = true, EmitDefaultValue = true)]
        public Amount Amount { get; set; }

        /// <summary>
        /// Gets or Sets PaymentMethod
        /// </summary>
        [DataMember(Name = "paymentMethod", IsRequired = true, EmitDefaultValue = true)]
        public PaymentMethodResponse PaymentMethod { get; set; }

        /// <summary>
        /// Gets or Sets Profile
        /// </summary>
        [DataMember(Name = "profile", IsRequired = true, EmitDefaultValue = true)]
        public ProfileResponse Profile { get; set; }

        /// <summary>
        /// Reference value for a payment, defined by Vipps MobilePay.
        /// </summary>
        /// <value>Reference value for a payment, defined by Vipps MobilePay.</value>
        [DataMember(Name = "pspReference", IsRequired = true, EmitDefaultValue = true)]
        public string PspReference { get; set; }

        /// <summary>
        /// The URL you should redirect the user to to continue with the payment. This is the URL to the Vipps MobilePay landing page. See: https://developer.vippsmobilepay.com/docs/knowledge-base/landing-page/
        /// </summary>
        /// <value>The URL you should redirect the user to to continue with the payment. This is the URL to the Vipps MobilePay landing page. See: https://developer.vippsmobilepay.com/docs/knowledge-base/landing-page/</value>
        /*
        <example>https://landing.vipps.no?token&#x3D;abc123</example>
        */
        [DataMember(Name = "redirectUrl", EmitDefaultValue = false)]
        public string RedirectUrl { get; set; }

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
        /// Metadata is a key-value map that can be used to store additional information about the payment. The metadata is not used by Vipps MobilePay, but is passed through in the &#x60;GetPaymentResponse&#x60; object. Key length is limited to 100 characters, and value length is limited to 500 characters. Max capacity is 5 key-value pairs.
        /// </summary>
        /// <value>Metadata is a key-value map that can be used to store additional information about the payment. The metadata is not used by Vipps MobilePay, but is passed through in the &#x60;GetPaymentResponse&#x60; object. Key length is limited to 100 characters, and value length is limited to 500 characters. Max capacity is 5 key-value pairs.</value>
        /*
        <example>{&quot;key1&quot;:&quot;value1&quot;,&quot;key2&quot;:&quot;value2&quot;,&quot;key3&quot;:&quot;value3&quot;}</example>
        */
        [DataMember(Name = "metadata", EmitDefaultValue = true)]
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GetPaymentResponse {\n");
            sb.Append("  Aggregate: ").Append(Aggregate).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  PaymentMethod: ").Append(PaymentMethod).Append("\n");
            sb.Append("  Profile: ").Append(Profile).Append("\n");
            sb.Append("  PspReference: ").Append(PspReference).Append("\n");
            sb.Append("  RedirectUrl: ").Append(RedirectUrl).Append("\n");
            sb.Append("  Reference: ").Append(Reference).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
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
