using System.Buffers;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Vipps.Models;

namespace Vipps.net.Helpers
{
    public static class VippsRequestSerializer
    {
        public static string SerializeVippsRequest(VippsRequest vippsRequest)
        {
            dynamic extraParameters = vippsRequest.ExtraParameters;
            vippsRequest.ExtraParameters = null;
            string serializedRequest = JsonSerializer.Serialize(vippsRequest, vippsRequest.GetType());
            if (extraParameters is not null)
            {
                dynamic serializedExtraParameters = JsonSerializer.Serialize(extraParameters, extraParameters.GetType());
                serializedRequest = Merge(serializedRequest, serializedExtraParameters);
            }
            return serializedRequest;
        }

        private static string Merge(string request, string extraParameters)
        {
            ArrayBufferWriter<byte> outputBuffer = new ArrayBufferWriter<byte>();

            using (JsonDocument parsedRequest = JsonDocument.Parse(request))
            using (JsonDocument parsedExtraParameters = JsonDocument.Parse(extraParameters))
            using (Utf8JsonWriter jsonWriter = new Utf8JsonWriter(outputBuffer, new JsonWriterOptions { Indented = true }))
            {
                JsonElement requestRoot = parsedRequest.RootElement;
                JsonElement extraParametersRoot = parsedExtraParameters.RootElement;

                if (requestRoot.ValueKind != JsonValueKind.Array && requestRoot.ValueKind != JsonValueKind.Object)
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

        private static void MergeObjects(Utf8JsonWriter jsonWriter, JsonElement requestRoot, JsonElement extraParametersRoot)
        {
            Debug.Assert(requestRoot.ValueKind == JsonValueKind.Object);
            Debug.Assert(extraParametersRoot.ValueKind == JsonValueKind.Object);

            jsonWriter.WriteStartObject();

            foreach (JsonProperty property in requestRoot.EnumerateObject())
            {
                if (extraParametersRoot.TryGetProperty(property.Name, out JsonElement newValue) && newValue.ValueKind != JsonValueKind.Null)
                {
                    jsonWriter.WritePropertyName(property.Name);

                    JsonElement originalValue = property.Value;
                    JsonValueKind originalValueKind = originalValue.ValueKind;

                    if (newValue.ValueKind == JsonValueKind.Object && originalValueKind == JsonValueKind.Object)
                    {
                        MergeObjects(jsonWriter, originalValue, newValue);
                    }
                    else if (newValue.ValueKind == JsonValueKind.Array && originalValueKind == JsonValueKind.Array)
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

            foreach (JsonProperty property in extraParametersRoot.EnumerateObject())
            {
                if (!requestRoot.TryGetProperty(property.Name, out _))
                {
                    property.WriteTo(jsonWriter);
                }
            }

            jsonWriter.WriteEndObject();
        }

        private static void MergeArrays(Utf8JsonWriter jsonWriter, JsonElement originalValue, JsonElement newValue)
        {
            jsonWriter.WriteStartArray();

            foreach (JsonElement element in originalValue.EnumerateArray())
            {
                element.WriteTo(jsonWriter);
            }
            foreach (JsonElement element in newValue.EnumerateArray())
            {
                element.WriteTo(jsonWriter);
            }

            jsonWriter.WriteEndArray();
        }

    }
}
