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
    /// A machine-readable format for specifying errors in HTTP API responses based on &lt;see href&#x3D;\&quot;https://tools.ietf.org/html/rfc7807\&quot; /&gt;.
    /// </summary>
    [DataContract(Name = "CheckoutProblemDetails")]
    public partial class CheckoutProblemDetails : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutProblemDetails" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CheckoutProblemDetails()
        {
            this.AdditionalProperties = new Dictionary<string, object>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutProblemDetails" /> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="title">title.</param>
        /// <param name="status">status.</param>
        /// <param name="detail">detail.</param>
        /// <param name="instance">instance.</param>
        /// <param name="errorCode">errorCode (required).</param>
        /// <param name="errors">errors (required).</param>
        public CheckoutProblemDetails(string type = default(string), string title = default(string), int? status = default(int?), string detail = default(string), string instance = default(string), string errorCode = default(string), Dictionary<string, List<string>> errors = default(Dictionary<string, List<string>>))
        {
            // to ensure "errorCode" is required (not null)
            if (errorCode == null)
            {
                throw new ArgumentNullException("errorCode is a required property for CheckoutProblemDetails and cannot be null");
            }
            this.ErrorCode = errorCode;
            // to ensure "errors" is required (not null)
            if (errors == null)
            {
                throw new ArgumentNullException("errors is a required property for CheckoutProblemDetails and cannot be null");
            }
            this.Errors = errors;
            this.Type = type;
            this.Title = title;
            this.Status = status;
            this.Detail = detail;
            this.Instance = instance;
            this.AdditionalProperties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = true)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name = "title", EmitDefaultValue = true)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = true)]
        public int? Status { get; set; }

        /// <summary>
        /// Gets or Sets Detail
        /// </summary>
        [DataMember(Name = "detail", EmitDefaultValue = true)]
        public string Detail { get; set; }

        /// <summary>
        /// Gets or Sets Instance
        /// </summary>
        [DataMember(Name = "instance", EmitDefaultValue = true)]
        public string Instance { get; set; }

        /// <summary>
        /// Gets or Sets ErrorCode
        /// </summary>
        [DataMember(Name = "errorCode", IsRequired = true, EmitDefaultValue = true)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or Sets Errors
        /// </summary>
        [DataMember(Name = "errors", IsRequired = true, EmitDefaultValue = true)]
        public Dictionary<string, List<string>> Errors { get; set; }

        /// <summary>
        /// Gets or Sets additional properties
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CheckoutProblemDetails {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Detail: ").Append(Detail).Append("\n");
            sb.Append("  Instance: ").Append(Instance).Append("\n");
            sb.Append("  ErrorCode: ").Append(ErrorCode).Append("\n");
            sb.Append("  Errors: ").Append(Errors).Append("\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
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