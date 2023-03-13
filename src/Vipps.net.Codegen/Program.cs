using System.Dynamic;
using Newtonsoft.Json;
using NSwag;
using NSwag.CodeGeneration.CSharp;
using Vipps.net.Codegen;

internal sealed class Program
{
    private static async Task Main(string[] args)
    {
        var httpClient = new HttpClient();
        var epaymentOptions = new CodegenSettings(
            "https://vippsas.github.io/vipps-developer-docs/redocusaurus/epayment-swagger-id.yaml",
            "VippsEpayment",
            "Vipps.net.Models.Epayment",
            "../Vipps.net/Models/EpaymentModels.cs"
        );
        await GenerateCode(httpClient, epaymentOptions);

        var checkoutOptions = new CodegenSettings(
            "https://vippsas.github.io/vipps-developer-docs/redocusaurus/checkout-swagger-id.yaml",
            "VippsCheckout",
            "Vipps.net.Models.Checkout",
            "../Vipps.net/Models/CheckoutModels.cs"
        );
        await GenerateCode(httpClient, checkoutOptions);
    }

    private static async Task GenerateCode(HttpClient httpClient, CodegenSettings options)
    {
        Console.WriteLine($"Fetching from {options.OpenApiUrl}");
        var retrievedText = await httpClient.GetStringAsync(options.OpenApiUrl);
        Console.WriteLine($"Retrieved from {options.OpenApiUrl}");
        var retrievedJson = options.OpenApiUrl.ToLower().EndsWith(".yaml")
            ? ConvertToJson(retrievedText)
            : EnrichJson(retrievedText);
        var document = await OpenApiDocument.FromJsonAsync(retrievedJson);
        Console.WriteLine(
            $"Generated document from {options.OpenApiUrl}: Title: {document.Info.Title}, Version: {document.Info.Version}."
        );

        var generator = new CSharpClientGenerator(document, options.ClientGeneratorSettings);
        var code = generator.GenerateFile();
        Console.WriteLine($"Generated code from {options.OpenApiUrl}");
        File.WriteAllText(options.RelativeFilePath, code);
        Console.WriteLine($"Wrote file {options.RelativeFilePath}");
    }

    private static string ConvertToJson(string yaml)
    {
        var deserializer = new YamlDotNet.Serialization.Deserializer();
        dynamic deserializedObject = deserializer.Deserialize<ExpandoObject>(yaml);
        string json = JsonConvert.SerializeObject(deserializedObject);
        return json;
    }

    private static string EnrichJson(string jsonInput)
    {
        dynamic deserializedObject = JsonConvert.DeserializeObject<ExpandoObject>(jsonInput);
        string json = JsonConvert.SerializeObject(deserializedObject);
        return json;
    }
}
