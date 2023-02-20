using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Vipps.Models;

namespace Vipps.net.Helpers
{
    public static class VippsRequestSerializer
    {
        public static string SerializeVippsRequest(VippsRequest vippsRequest)
        {
            if (vippsRequest.ExtraParameters != null)
            {
                var extraParameters = vippsRequest.ExtraParameters;
                dynamic serializedExtraParameters = JsonConvert.SerializeObject(
                    extraParameters
                );
                vippsRequest.ExtraParameters = null;
                string serializedRequest = JsonConvert.SerializeObject(
                    vippsRequest
                );
                vippsRequest.ExtraParameters = extraParameters;
                return Merge(serializedRequest, serializedExtraParameters);
            }
            else { 
                return JsonConvert.SerializeObject(
                    vippsRequest
                );
            }
        }

        public static T DeserializeVippsResponse<T>(string vippsResponse)
            where T : VippsResponse
        {
            var deserializedTyped = JsonConvert.DeserializeObject<T>(vippsResponse);
            if (deserializedTyped is null)
            {
                throw new ArgumentException(
                    "Response could not be deserialized to {type}",
                    nameof(T)
                );
            }
            var deserializedRaw = JsonConvert.DeserializeObject<JObject>(vippsResponse);
            deserializedTyped.RawResponse = deserializedRaw;
            return deserializedTyped;
        }

        private static string Merge(string request, string extraParameters)
        {
            var parsedRequest = JsonConvert.DeserializeObject<JObject>(request);
            var parsedExtraParameters = JsonConvert.DeserializeObject<JObject>(extraParameters);

            if (
                parsedRequest.Type != JTokenType.Array
                && parsedExtraParameters.Type != JTokenType.Object
            )
            {
                return request;
            }

            if (parsedExtraParameters.Type == JTokenType.Null)
            {
                return request;
            }

            if (parsedExtraParameters.Type != JTokenType.Object)
            {
                throw new ArgumentException("ExtraParameters must be an object");
            }

            var mergeSettings = new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Union
            };

            if (parsedRequest.Type == JTokenType.Object)
            {
                parsedRequest.Merge(parsedExtraParameters, mergeSettings);
            }
            return JsonConvert.SerializeObject(parsedRequest);
        }
    }
}
