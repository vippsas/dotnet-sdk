using NSwag.CodeGeneration.CSharp;

namespace Vipps.net.Codegen
{
    internal sealed class CodegenSettings
    {
        internal string OpenApiJsonPath { get; init; }
        internal string RelativeFilePath { get; init; }
        internal CSharpClientGeneratorSettings ClientGeneratorSettings { get; init; }

        internal CodegenSettings(
            string openApiJsonPath,
            string className,
            string baseNamespace,
            string relativeFilePath
        )
        {
            OpenApiJsonPath = openApiJsonPath;
            RelativeFilePath = relativeFilePath;
            ClientGeneratorSettings = new CSharpClientGeneratorSettings
            {
                ClassName = className,
                CSharpGeneratorSettings = { Namespace = baseNamespace }
            };
        }
    }
}
