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
                dynamic serializedExtraParameters = JsonConvert.SerializeObject(extraParameters);

                vippsRequest.ExtraParameters = null;
                string serializedRequest = JsonConvert.SerializeObject(
                    vippsRequest,
                    vippsRequest.GetType(),
                    new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        Converters = new[] { new Newtonsoft.Json.Converters.StringEnumConverter() }
                    }
                );
                vippsRequest.ExtraParameters = extraParameters;

                return Merge(serializedRequest, serializedExtraParameters);
            }
            else
            {
                return JsonConvert.SerializeObject(vippsRequest);
            }
        }

        public static T DeserializeVippsResponse<T>(string vippsResponse)
            where T : class
        {
            try
            {
                var deserializedTyped = JsonConvert.DeserializeObject<T>(vippsResponse);
                if (deserializedTyped is null)
                {
                    throw new Exceptions.VippsTechnicalException(
                        $"Response could not be deserialized to {nameof(T)}"
                    );
                }
                if (deserializedTyped is VippsResponse)
                {
                    (deserializedTyped as VippsResponse).RawResponse = vippsResponse;
                }
                return deserializedTyped;
            }
            catch (Exceptions.VippsBaseException)
            {
                throw;
            }
            catch (System.Exception ex)
            {
                throw new Exceptions.VippsTechnicalException(
                    $"Error deserializing response of type {nameof(T)}",
                    ex
                );
            }
        }

        private static string Merge(string request, string extraParameters)
        {
            var parsedRequest = JsonConvert.DeserializeObject<JObject>(request);
            var parsedExtraParameters = JsonConvert.DeserializeObject<JObject>(extraParameters);

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
