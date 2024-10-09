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
    /// Defines ExternalSessionState
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ExternalSessionState
    {
        /// <summary>
        /// Enum SessionCreated for value: SessionCreated
        /// </summary>
        [EnumMember(Value = "SessionCreated")]
        SessionCreated = 1,

        /// <summary>
        /// Enum PaymentInitiated for value: PaymentInitiated
        /// </summary>
        [EnumMember(Value = "PaymentInitiated")]
        PaymentInitiated = 2,

        /// <summary>
        /// Enum SessionExpired for value: SessionExpired
        /// </summary>
        [EnumMember(Value = "SessionExpired")]
        SessionExpired = 3,

        /// <summary>
        /// Enum PaymentSuccessful for value: PaymentSuccessful
        /// </summary>
        [EnumMember(Value = "PaymentSuccessful")]
        PaymentSuccessful = 4,

        /// <summary>
        /// Enum PaymentTerminated for value: PaymentTerminated
        /// </summary>
        [EnumMember(Value = "PaymentTerminated")]
        PaymentTerminated = 5
    }

}