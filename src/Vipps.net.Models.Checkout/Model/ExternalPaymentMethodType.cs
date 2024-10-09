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
    /// Valid types of external payment methods
    /// </summary>
    /// <value>Valid types of external payment methods</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ExternalPaymentMethodType
    {
        /// <summary>
        /// Enum Klarna for value: Klarna
        /// </summary>
        [EnumMember(Value = "Klarna")]
        Klarna = 1
    }

}
