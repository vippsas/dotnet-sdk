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
    /// Information about the customer address used when retrieving dynamic logistics options.
    /// </summary>
    [DataContract(Name = "MerchantLogisticsCallbackRequestBody")]
    public partial class MerchantLogisticsCallbackRequestBody : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MerchantLogisticsCallbackRequestBody" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MerchantLogisticsCallbackRequestBody() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MerchantLogisticsCallbackRequestBody" /> class.
        /// </summary>
        /// <param name="streetAddress">Example: \&quot;Robert Levins gate 5\&quot; (required).</param>
        /// <param name="postalCode">Example: \&quot;0154\&quot; (required).</param>
        /// <param name="region">Example: \&quot;Oslo\&quot; (required).</param>
        /// <param name="country">The ISO-3166-1 Alpha-2 representation of the country. Example: \&quot;NO\&quot; (required).</param>
        public MerchantLogisticsCallbackRequestBody(string streetAddress = default(string), string postalCode = default(string), string region = default(string), string country = default(string))
        {
            // to ensure "streetAddress" is required (not null)
            if (streetAddress == null)
            {
                throw new ArgumentNullException("streetAddress is a required property for MerchantLogisticsCallbackRequestBody and cannot be null");
            }
            this.StreetAddress = streetAddress;
            // to ensure "postalCode" is required (not null)
            if (postalCode == null)
            {
                throw new ArgumentNullException("postalCode is a required property for MerchantLogisticsCallbackRequestBody and cannot be null");
            }
            this.PostalCode = postalCode;
            // to ensure "region" is required (not null)
            if (region == null)
            {
                throw new ArgumentNullException("region is a required property for MerchantLogisticsCallbackRequestBody and cannot be null");
            }
            this.Region = region;
            // to ensure "country" is required (not null)
            if (country == null)
            {
                throw new ArgumentNullException("country is a required property for MerchantLogisticsCallbackRequestBody and cannot be null");
            }
            this.Country = country;
        }

        /// <summary>
        /// Example: \&quot;Robert Levins gate 5\&quot;
        /// </summary>
        /// <value>Example: \&quot;Robert Levins gate 5\&quot;</value>
        [DataMember(Name = "streetAddress", IsRequired = true, EmitDefaultValue = true)]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Example: \&quot;0154\&quot;
        /// </summary>
        /// <value>Example: \&quot;0154\&quot;</value>
        [DataMember(Name = "postalCode", IsRequired = true, EmitDefaultValue = true)]
        public string PostalCode { get; set; }

        /// <summary>
        /// Example: \&quot;Oslo\&quot;
        /// </summary>
        /// <value>Example: \&quot;Oslo\&quot;</value>
        [DataMember(Name = "region", IsRequired = true, EmitDefaultValue = true)]
        public string Region { get; set; }

        /// <summary>
        /// The ISO-3166-1 Alpha-2 representation of the country. Example: \&quot;NO\&quot;
        /// </summary>
        /// <value>The ISO-3166-1 Alpha-2 representation of the country. Example: \&quot;NO\&quot;</value>
        [DataMember(Name = "country", IsRequired = true, EmitDefaultValue = true)]
        public string Country { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MerchantLogisticsCallbackRequestBody {\n");
            sb.Append("  StreetAddress: ").Append(StreetAddress).Append("\n");
            sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
            sb.Append("  Region: ").Append(Region).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
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