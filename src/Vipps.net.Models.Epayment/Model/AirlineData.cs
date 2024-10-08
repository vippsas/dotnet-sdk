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
    /// Airline related data. If present, &#x60;passengerName&#x60;, &#x60;airlineCode&#x60;, &#x60;airlineDesignatorCode&#x60;, and &#x60;agencyInvoiceNumber&#x60; are all required.
    /// </summary>
    [DataContract(Name = "AirlineData")]
    public partial class AirlineData : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirlineData" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AirlineData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AirlineData" /> class.
        /// </summary>
        /// <param name="agencyInvoiceNumber">Reference number for the invoice, issued by the agency. (required).</param>
        /// <param name="airlineCode">IATA 3-digit accounting code (PAX); numeric. It identifies the carrier. eg KLM &#x3D; 074. (required).</param>
        /// <param name="airlineDesignatorCode">IATA 2-letter accounting code (PAX); alphabetical. It identifies the carrier. Eg KLM &#x3D; KL. (required).</param>
        /// <param name="passengerName">Passenger name, initials, and a title. (required).</param>
        /// <param name="ticketNumber">The ticket&#39;s unique identifier..</param>
        public AirlineData(string agencyInvoiceNumber = default(string), string airlineCode = default(string), string airlineDesignatorCode = default(string), string passengerName = default(string), string ticketNumber = default(string))
        {
            // to ensure "agencyInvoiceNumber" is required (not null)
            if (agencyInvoiceNumber == null)
            {
                throw new ArgumentNullException("agencyInvoiceNumber is a required property for AirlineData and cannot be null");
            }
            this.AgencyInvoiceNumber = agencyInvoiceNumber;
            // to ensure "airlineCode" is required (not null)
            if (airlineCode == null)
            {
                throw new ArgumentNullException("airlineCode is a required property for AirlineData and cannot be null");
            }
            this.AirlineCode = airlineCode;
            // to ensure "airlineDesignatorCode" is required (not null)
            if (airlineDesignatorCode == null)
            {
                throw new ArgumentNullException("airlineDesignatorCode is a required property for AirlineData and cannot be null");
            }
            this.AirlineDesignatorCode = airlineDesignatorCode;
            // to ensure "passengerName" is required (not null)
            if (passengerName == null)
            {
                throw new ArgumentNullException("passengerName is a required property for AirlineData and cannot be null");
            }
            this.PassengerName = passengerName;
            this.TicketNumber = ticketNumber;
        }

        /// <summary>
        /// Reference number for the invoice, issued by the agency.
        /// </summary>
        /// <value>Reference number for the invoice, issued by the agency.</value>
        [DataMember(Name = "agencyInvoiceNumber", IsRequired = true, EmitDefaultValue = true)]
        public string AgencyInvoiceNumber { get; set; }

        /// <summary>
        /// IATA 3-digit accounting code (PAX); numeric. It identifies the carrier. eg KLM &#x3D; 074.
        /// </summary>
        /// <value>IATA 3-digit accounting code (PAX); numeric. It identifies the carrier. eg KLM &#x3D; 074.</value>
        /*
        <example>074</example>
        */
        [DataMember(Name = "airlineCode", IsRequired = true, EmitDefaultValue = true)]
        public string AirlineCode { get; set; }

        /// <summary>
        /// IATA 2-letter accounting code (PAX); alphabetical. It identifies the carrier. Eg KLM &#x3D; KL.
        /// </summary>
        /// <value>IATA 2-letter accounting code (PAX); alphabetical. It identifies the carrier. Eg KLM &#x3D; KL.</value>
        /*
        <example>KL</example>
        */
        [DataMember(Name = "airlineDesignatorCode", IsRequired = true, EmitDefaultValue = true)]
        public string AirlineDesignatorCode { get; set; }

        /// <summary>
        /// Passenger name, initials, and a title.
        /// </summary>
        /// <value>Passenger name, initials, and a title.</value>
        /*
        <example>FLYER / MARY MS.</example>
        */
        [DataMember(Name = "passengerName", IsRequired = true, EmitDefaultValue = true)]
        public string PassengerName { get; set; }

        /// <summary>
        /// The ticket&#39;s unique identifier.
        /// </summary>
        /// <value>The ticket&#39;s unique identifier.</value>
        /*
        <example>123-1234567890</example>
        */
        [DataMember(Name = "ticketNumber", EmitDefaultValue = false)]
        public string TicketNumber { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AirlineData {\n");
            sb.Append("  AgencyInvoiceNumber: ").Append(AgencyInvoiceNumber).Append("\n");
            sb.Append("  AirlineCode: ").Append(AirlineCode).Append("\n");
            sb.Append("  AirlineDesignatorCode: ").Append(AirlineDesignatorCode).Append("\n");
            sb.Append("  PassengerName: ").Append(PassengerName).Append("\n");
            sb.Append("  TicketNumber: ").Append(TicketNumber).Append("\n");
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
            // AgencyInvoiceNumber (string) maxLength
            if (this.AgencyInvoiceNumber != null && this.AgencyInvoiceNumber.Length > 6)
            {
                yield return new ValidationResult("Invalid value for AgencyInvoiceNumber, length must be less than 6.", new [] { "AgencyInvoiceNumber" });
            }

            // AgencyInvoiceNumber (string) minLength
            if (this.AgencyInvoiceNumber != null && this.AgencyInvoiceNumber.Length < 1)
            {
                yield return new ValidationResult("Invalid value for AgencyInvoiceNumber, length must be greater than 1.", new [] { "AgencyInvoiceNumber" });
            }

            // AirlineCode (string) maxLength
            if (this.AirlineCode != null && this.AirlineCode.Length > 3)
            {
                yield return new ValidationResult("Invalid value for AirlineCode, length must be less than 3.", new [] { "AirlineCode" });
            }

            // AirlineCode (string) minLength
            if (this.AirlineCode != null && this.AirlineCode.Length < 3)
            {
                yield return new ValidationResult("Invalid value for AirlineCode, length must be greater than 3.", new [] { "AirlineCode" });
            }

            // AirlineDesignatorCode (string) maxLength
            if (this.AirlineDesignatorCode != null && this.AirlineDesignatorCode.Length > 2)
            {
                yield return new ValidationResult("Invalid value for AirlineDesignatorCode, length must be less than 2.", new [] { "AirlineDesignatorCode" });
            }

            // AirlineDesignatorCode (string) minLength
            if (this.AirlineDesignatorCode != null && this.AirlineDesignatorCode.Length < 2)
            {
                yield return new ValidationResult("Invalid value for AirlineDesignatorCode, length must be greater than 2.", new [] { "AirlineDesignatorCode" });
            }

            // PassengerName (string) maxLength
            if (this.PassengerName != null && this.PassengerName.Length > 49)
            {
                yield return new ValidationResult("Invalid value for PassengerName, length must be less than 49.", new [] { "PassengerName" });
            }

            // PassengerName (string) minLength
            if (this.PassengerName != null && this.PassengerName.Length < 1)
            {
                yield return new ValidationResult("Invalid value for PassengerName, length must be greater than 1.", new [] { "PassengerName" });
            }

            // TicketNumber (string) maxLength
            if (this.TicketNumber != null && this.TicketNumber.Length > 150)
            {
                yield return new ValidationResult("Invalid value for TicketNumber, length must be less than 150.", new [] { "TicketNumber" });
            }

            // TicketNumber (string) minLength
            if (this.TicketNumber != null && this.TicketNumber.Length < 1)
            {
                yield return new ValidationResult("Invalid value for TicketNumber, length must be greater than 1.", new [] { "TicketNumber" });
            }

            yield break;
        }
    }

}
