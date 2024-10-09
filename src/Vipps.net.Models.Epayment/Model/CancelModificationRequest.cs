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
    /// CancelModificationRequest
    /// </summary>
    [DataContract(Name = "CancelModificationRequest")]
    public partial class CancelModificationRequest : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CancelModificationRequest" /> class.
        /// </summary>
        /// <param name="cancelTransactionOnly">Only cancel transaction if it has not been authorized. If this flag is set and the transaction has been authorized, the reserved amount will not be canceled..</param>
        public CancelModificationRequest(bool cancelTransactionOnly = default(bool))
        {
            this.CancelTransactionOnly = cancelTransactionOnly;
        }

        /// <summary>
        /// Only cancel transaction if it has not been authorized. If this flag is set and the transaction has been authorized, the reserved amount will not be canceled.
        /// </summary>
        /// <value>Only cancel transaction if it has not been authorized. If this flag is set and the transaction has been authorized, the reserved amount will not be canceled.</value>
        [DataMember(Name = "cancelTransactionOnly", EmitDefaultValue = true)]
        public bool CancelTransactionOnly { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CancelModificationRequest {\n");
            sb.Append("  CancelTransactionOnly: ").Append(CancelTransactionOnly).Append("\n");
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
