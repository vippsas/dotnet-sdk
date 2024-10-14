using Newtonsoft.Json;

namespace Vipps.net.Helpers
{
    internal static class VippsRequestSerializer
    {
        private static readonly JsonSerializerSettings _jsonSerializerSettings =
            new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Include,
                Converters = new[] { new Newtonsoft.Json.Converters.StringEnumConverter() },
            };

        internal static string SerializeVippsRequest<T>(T vippsRequest)
            where T : class
        {
            string serializedRequest = JsonConvert.SerializeObject(
                vippsRequest,
                vippsRequest.GetType(),
                _jsonSerializerSettings
            );
            return serializedRequest;
        }

        internal static T DeserializeVippsResponse<T>(string vippsResponse)
            where T : class
        {
            try
            {
                var deserializedTyped = JsonConvert.DeserializeObject<T>(
                    vippsResponse,
                    _jsonSerializerSettings
                );
                return deserializedTyped is null
                    ? throw new Exceptions.VippsTechnicalException(
                        $"Response could not be deserialized to {nameof(T)}"
                    )
                    : deserializedTyped;
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
    }
}
