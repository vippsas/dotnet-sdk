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
using System.Reflection;

namespace Vipps.net.Models.Checkout.Model
{
    /// <summary>
    /// CheckoutV3SessionPostRequest
    /// </summary>
    [JsonConverter(typeof(CheckoutV3SessionPostRequestJsonConverter))]
    [DataContract(Name = "_checkout_v3_session_post_request")]
    public partial class CheckoutV3SessionPostRequest : AbstractOpenAPISchema, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutV3SessionPostRequest" /> class
        /// with the <see cref="InitiatePaymentSessionRequest" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of InitiatePaymentSessionRequest.</param>
        public CheckoutV3SessionPostRequest(InitiatePaymentSessionRequest actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutV3SessionPostRequest" /> class
        /// with the <see cref="InitiateSubscriptionSessionRequest" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of InitiateSubscriptionSessionRequest.</param>
        public CheckoutV3SessionPostRequest(InitiateSubscriptionSessionRequest actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }


        private Object _actualInstance;

        /// <summary>
        /// Gets or Sets ActualInstance
        /// </summary>
        public override Object ActualInstance
        {
            get
            {
                return _actualInstance;
            }
            set
            {
                if (value.GetType() == typeof(InitiatePaymentSessionRequest) || value is InitiatePaymentSessionRequest)
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(InitiateSubscriptionSessionRequest) || value is InitiateSubscriptionSessionRequest)
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: InitiatePaymentSessionRequest, InitiateSubscriptionSessionRequest");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `InitiatePaymentSessionRequest`. If the actual instance is not `InitiatePaymentSessionRequest`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of InitiatePaymentSessionRequest</returns>
        public InitiatePaymentSessionRequest GetInitiatePaymentSessionRequest()
        {
            return (InitiatePaymentSessionRequest)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `InitiateSubscriptionSessionRequest`. If the actual instance is not `InitiateSubscriptionSessionRequest`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of InitiateSubscriptionSessionRequest</returns>
        public InitiateSubscriptionSessionRequest GetInitiateSubscriptionSessionRequest()
        {
            return (InitiateSubscriptionSessionRequest)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CheckoutV3SessionPostRequest {\n");
            sb.Append("  ActualInstance: ").Append(this.ActualInstance).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this.ActualInstance, CheckoutV3SessionPostRequest.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of CheckoutV3SessionPostRequest
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of CheckoutV3SessionPostRequest</returns>
        public static CheckoutV3SessionPostRequest FromJson(string jsonString)
        {
            CheckoutV3SessionPostRequest newCheckoutV3SessionPostRequest = null;

            if (string.IsNullOrEmpty(jsonString))
            {
                return newCheckoutV3SessionPostRequest;
            }
            int match = 0;
            List<string> matchedTypes = new List<string>();

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(InitiatePaymentSessionRequest).GetProperty("AdditionalProperties") == null)
                {
                    newCheckoutV3SessionPostRequest = new CheckoutV3SessionPostRequest(JsonConvert.DeserializeObject<InitiatePaymentSessionRequest>(jsonString, CheckoutV3SessionPostRequest.SerializerSettings));
                }
                else
                {
                    newCheckoutV3SessionPostRequest = new CheckoutV3SessionPostRequest(JsonConvert.DeserializeObject<InitiatePaymentSessionRequest>(jsonString, CheckoutV3SessionPostRequest.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("InitiatePaymentSessionRequest");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into InitiatePaymentSessionRequest: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(InitiateSubscriptionSessionRequest).GetProperty("AdditionalProperties") == null)
                {
                    newCheckoutV3SessionPostRequest = new CheckoutV3SessionPostRequest(JsonConvert.DeserializeObject<InitiateSubscriptionSessionRequest>(jsonString, CheckoutV3SessionPostRequest.SerializerSettings));
                }
                else
                {
                    newCheckoutV3SessionPostRequest = new CheckoutV3SessionPostRequest(JsonConvert.DeserializeObject<InitiateSubscriptionSessionRequest>(jsonString, CheckoutV3SessionPostRequest.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("InitiateSubscriptionSessionRequest");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into InitiateSubscriptionSessionRequest: {1}", jsonString, exception.ToString()));
            }

            if (match == 0)
            {
                throw new InvalidDataException("The JSON string `" + jsonString + "` cannot be deserialized into any schema defined.");
            }
            else if (match > 1)
            {
                throw new InvalidDataException("The JSON string `" + jsonString + "` incorrectly matches more than one schema (should be exactly one match): " + String.Join(",", matchedTypes));
            }

            // deserialization is considered successful at this point if no exception has been thrown.
            return newCheckoutV3SessionPostRequest;
        }


        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

    /// <summary>
    /// Custom JSON converter for CheckoutV3SessionPostRequest
    /// </summary>
    public class CheckoutV3SessionPostRequestJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)(typeof(CheckoutV3SessionPostRequest).GetMethod("ToJson").Invoke(value, null)));
        }

        /// <summary>
        /// To convert a JSON string into an object
        /// </summary>
        /// <param name="reader">JSON reader</param>
        /// <param name="objectType">Object type</param>
        /// <param name="existingValue">Existing value</param>
        /// <param name="serializer">JSON Serializer</param>
        /// <returns>The object converted from the JSON string</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch(reader.TokenType) 
            {
                case JsonToken.StartObject:
                    return CheckoutV3SessionPostRequest.FromJson(JObject.Load(reader).ToString(Formatting.None));
                case JsonToken.StartArray:
                    return CheckoutV3SessionPostRequest.FromJson(JArray.Load(reader).ToString(Formatting.None));
                default:
                    return null;
            }
        }

        /// <summary>
        /// Check if the object can be converted
        /// </summary>
        /// <param name="objectType">Object type</param>
        /// <returns>True if the object can be converted</returns>
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }

}
