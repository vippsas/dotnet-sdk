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
    /// The state of the Payment. One of: - &#x60;CREATED&#x60;: The user has not yet acted upon the payment.   Example: The user has received a push message, but not yet opened it. - &#x60;ABORTED&#x60;: The user has aborted the payment before authorization. This is a final state.   Example: The user cancelled instead of accepting the payment. - &#x60;EXPIRED&#x60;: The user did not act on the payment within the payment expiration time. This is a final state.   Example: The user received a push message, but did nothing before the payment request timed out. - &#x60;AUTHORIZED&#x60;: The user has approved the payment. This is a final state.   Example: A payment that has been refunded may have one or more refund events, but the state would be &#x60;AUTHORIZED&#x60;.  - &#x60;TERMINATED&#x60;: The merchant has terminated the payment via the cancelPayment endpoint. This is a final state.   Example: The merchant was not able to provide the product or service, and has cancelled the payment.
    /// </summary>
    /// <value>The state of the Payment. One of: - &#x60;CREATED&#x60;: The user has not yet acted upon the payment.   Example: The user has received a push message, but not yet opened it. - &#x60;ABORTED&#x60;: The user has aborted the payment before authorization. This is a final state.   Example: The user cancelled instead of accepting the payment. - &#x60;EXPIRED&#x60;: The user did not act on the payment within the payment expiration time. This is a final state.   Example: The user received a push message, but did nothing before the payment request timed out. - &#x60;AUTHORIZED&#x60;: The user has approved the payment. This is a final state.   Example: A payment that has been refunded may have one or more refund events, but the state would be &#x60;AUTHORIZED&#x60;.  - &#x60;TERMINATED&#x60;: The merchant has terminated the payment via the cancelPayment endpoint. This is a final state.   Example: The merchant was not able to provide the product or service, and has cancelled the payment.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum State
    {
        /// <summary>
        /// Enum CREATED for value: CREATED
        /// </summary>
        [EnumMember(Value = "CREATED")]
        CREATED = 1,

        /// <summary>
        /// Enum ABORTED for value: ABORTED
        /// </summary>
        [EnumMember(Value = "ABORTED")]
        ABORTED = 2,

        /// <summary>
        /// Enum EXPIRED for value: EXPIRED
        /// </summary>
        [EnumMember(Value = "EXPIRED")]
        EXPIRED = 3,

        /// <summary>
        /// Enum AUTHORIZED for value: AUTHORIZED
        /// </summary>
        [EnumMember(Value = "AUTHORIZED")]
        AUTHORIZED = 4,

        /// <summary>
        /// Enum TERMINATED for value: TERMINATED
        /// </summary>
        [EnumMember(Value = "TERMINATED")]
        TERMINATED = 5
    }

}