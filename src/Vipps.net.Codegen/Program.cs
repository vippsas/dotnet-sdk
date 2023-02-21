using NSwag;
using NSwag.CodeGeneration.CSharp;
using Vipps.net.Codegen;

internal sealed class Program
{
    private static async Task Main(string[] args)
    {
        var httpClient = new HttpClient();

        var options = new CodegenSettings(
            "http://localhost:5000/swagger/merchant-v3/swagger.json",
            "VippsCheckout",
            "Vipps.net.Models",
            "../Vipps.net/Models/CheckoutModels.cs"
        );
        Console.WriteLine($"Fetching from {options.OpenApiJsonPath}");
        var retrievedJson = await httpClient.GetStringAsync(options.OpenApiJsonPath);
        Console.WriteLine($"Retrieved from {options.OpenApiJsonPath}");
        var document = await OpenApiDocument.FromJsonAsync(retrievedJson);
        Console.WriteLine($"Generated document from {options.OpenApiJsonPath}");

        var generator = new CSharpClientGenerator(document, options.ClientGeneratorSettings);
        var code = generator.GenerateFile();
        Console.WriteLine($"Generated code from {options.OpenApiJsonPath}");
        File.WriteAllText(options.RelativeFilePath, code);
        Console.WriteLine($"Wrote file {options.RelativeFilePath}");
    }
}
