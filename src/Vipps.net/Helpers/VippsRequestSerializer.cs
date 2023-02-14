using System.Buffers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Vipps.Models;

namespace Vipps.net.Helpers
{
    public static class VippsRequestSerializer
    {
        public static string SerializeVippsRequest(VippsRequest vippsRequest)
        {
            var serializedRequest = JsonSerializer.Serialize(vippsRequest, vippsRequest.GetType());
            if (vippsRequest.ExtraParameters is not null)
            {
                dynamic serializedExtraParameters = JsonSerializer.Serialize(
                    vippsRequest.ExtraParameters,
                    vippsRequest.ExtraParameters.GetType()
                );
                serializedRequest = Merge(serializedRequest, serializedExtraParameters);
            }
            return serializedRequest;
        }

        public static T DeserializeVippsResponse<T>(string vippsResponse) where T : VippsResponse
        {
            var deserializedTyped = JsonSerializer.Deserialize<T>(vippsResponse);
            if (deserializedTyped is null)
            {
                throw new ArgumentException(
                    "Response could not be deserialized to {type}",
                    nameof(T)
                );
            }
            var deserializedRaw = JsonSerializer.Deserialize<JsonObject>(vippsResponse);
            if (deserializedRaw is null)
            {
                throw new ArgumentException(
                    "Response could not be deserialized to {type}",
                    nameof(JsonObject)
                );
            }
            deserializedTyped.RawResponse = deserializedRaw;
            return deserializedTyped;
        }

        private static string Merge(string request, string extraParameters)
        {
            var outputBuffer = new ArrayBufferWriter<byte>();

            using (var parsedRequest = JsonDocument.Parse(request))
            using (var parsedExtraParameters = JsonDocument.Parse(extraParameters))
            using (
                var jsonWriter = new Utf8JsonWriter(
                    outputBuffer,
                    new JsonWriterOptions { Indented = true }
                )
            )
            {
                var requestRoot = parsedRequest.RootElement;
                var extraParametersRoot = parsedExtraParameters.RootElement;

                if (
                    requestRoot.ValueKind != JsonValueKind.Array
                    && requestRoot.ValueKind != JsonValueKind.Object
                )
                {
                    return request;
                }

                if (extraParametersRoot.ValueKind == JsonValueKind.Null)
                {
                    return request;
                }

                if (extraParametersRoot.ValueKind != JsonValueKind.Object)
                {
                    throw new ArgumentException("ExtraParameters must be an object");
                }

                if (requestRoot.ValueKind == JsonValueKind.Object)
                {
                    MergeObjects(jsonWriter, requestRoot, extraParametersRoot);
                }
            }

            return Encoding.UTF8.GetString(outputBuffer.WrittenSpan);
        }

        private static void MergeObjects(
            Utf8JsonWriter jsonWriter,
            JsonElement requestRoot,
            JsonElement extraParametersRoot
        )
        {
            jsonWriter.WriteStartObject();

            foreach (var property in requestRoot.EnumerateObject())
            {
                if (
                    extraParametersRoot.TryGetProperty(property.Name, out var newValue)
                    && newValue.ValueKind != JsonValueKind.Null
                )
                {
                    jsonWriter.WritePropertyName(property.Name);

                    var originalValue = property.Value;
                    var originalValueKind = originalValue.ValueKind;

                    if (
                        newValue.ValueKind == JsonValueKind.Object
                        && originalValueKind == JsonValueKind.Object
                    )
                    {
                        MergeObjects(jsonWriter, originalValue, newValue);
                    }
                    else if (
                        newValue.ValueKind == JsonValueKind.Array
                        && originalValueKind == JsonValueKind.Array
                    )
                    {
                        MergeArrays(jsonWriter, originalValue, newValue);
                    }
                    else
                    {
                        newValue.WriteTo(jsonWriter);
                    }
                }
                else
                {
                    property.WriteTo(jsonWriter);
                }
            }

            foreach (var property in extraParametersRoot.EnumerateObject())
            {
                if (!requestRoot.TryGetProperty(property.Name, out _))
                {
                    property.WriteTo(jsonWriter);
                }
            }

            jsonWriter.WriteEndObject();
        }

        private static void MergeArrays(
            Utf8JsonWriter jsonWriter,
            JsonElement originalValue,
            JsonElement newValue
        )
        {
            jsonWriter.WriteStartArray();

            foreach (var element in originalValue.EnumerateArray())
            {
                element.WriteTo(jsonWriter);
            }
            foreach (var element in newValue.EnumerateArray())
            {
                element.WriteTo(jsonWriter);
            }

            jsonWriter.WriteEndArray();
        }
    }
}
