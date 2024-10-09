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
    /// Defines QuantityUnit
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum QuantityUnit
    {
        /// <summary>
        /// Enum PCS for value: PCS
        /// </summary>
        [EnumMember(Value = "PCS")]
        PCS = 1,

        /// <summary>
        /// Enum KG for value: KG
        /// </summary>
        [EnumMember(Value = "KG")]
        KG = 2,

        /// <summary>
        /// Enum KM for value: KM
        /// </summary>
        [EnumMember(Value = "KM")]
        KM = 3,

        /// <summary>
        /// Enum MINUTE for value: MINUTE
        /// </summary>
        [EnumMember(Value = "MINUTE")]
        MINUTE = 4,

        /// <summary>
        /// Enum LITRE for value: LITRE
        /// </summary>
        [EnumMember(Value = "LITRE")]
        LITRE = 5
    }

}