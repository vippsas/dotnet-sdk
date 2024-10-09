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
    /// Defines PaymentMethod
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentMethod
    {
        /// <summary>
        /// Enum Wallet for value: Wallet
        /// </summary>
        [EnumMember(Value = "Wallet")]
        Wallet = 1,

        /// <summary>
        /// Enum Card for value: Card
        /// </summary>
        [EnumMember(Value = "Card")]
        Card = 2,

        /// <summary>
        /// Enum BankTransfer for value: BankTransfer
        /// </summary>
        [EnumMember(Value = "BankTransfer")]
        BankTransfer = 3,

        /// <summary>
        /// Enum Klarna for value: Klarna
        /// </summary>
        [EnumMember(Value = "Klarna")]
        Klarna = 4
    }

}