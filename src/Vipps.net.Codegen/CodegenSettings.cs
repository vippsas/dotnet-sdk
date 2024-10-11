using NSwag.CodeGeneration.CSharp;

namespace Vipps.net.Codegen
{
    internal sealed class CodegenSettings
    {
        internal string OpenApiUrl { get; init; }
        internal string RelativeFilePath { get; init; }
        internal CSharpClientGeneratorSettings ClientGeneratorSettings { get; init; }

        internal CodegenSettings(
            string openApiJsonPath,
            string className,
            string baseNamespace,
            string relativeFilePath
        )
        {
            OpenApiUrl = openApiJsonPath;
            RelativeFilePath = relativeFilePath;
            ClientGeneratorSettings = new CSharpClientGeneratorSettings
            {
                ClassName = className,
                GenerateClientClasses = false,
                GeneratePrepareRequestAndProcessResponseAsAsyncMethods = false,
                CSharpGeneratorSettings =
                {
                    Namespace = baseNamespace,
                    TypeAccessModifier = "public",
                    GenerateDataAnnotations = true,
                    GenerateDefaultValues = true,
                },
                GenerateExceptionClasses = false,
                GenerateBaseUrlProperty = false,
                GenerateUpdateJsonSerializerSettingsMethod = false,
                GenerateDtoTypes = true,
                GenerateOptionalParameters = true,
            };
        }
    }
}
