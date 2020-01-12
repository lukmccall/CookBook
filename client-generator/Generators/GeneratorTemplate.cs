using System.Collections.Generic;
using client_generator.Models;
using client_generator.Models.Endpoints;
using client_generator.Models.Generators;
using client_generator.Models.Schemas;

namespace client_generator.Generators
{
    public abstract class GeneratorTemplate
    {

        protected readonly IGeneratorContext GeneratorContext = new GeneratorContext();

        protected GeneratorSettings GeneratorSettings = new GeneratorSettings();

        public void SetSettings(GeneratorSettings generatorSettings)
        {
            GeneratorSettings = generatorSettings;
        }

        public void Generate(OpenApiModel openApiModel)
        {
            ParseSchemas(openApiModel.Schemas);
            ParseEndpoints(openApiModel.Endpoints);
            CreateFiles(GeneratorContext.GetTypesToGenerate(), GeneratorContext.GetFunctionsToGenerate());
        }

        protected abstract void ParseSchemas(IEnumerable<ISchema> schemas);

        protected abstract void ParseEndpoints(IEnumerable<IEndpoint> endPoints);

        protected abstract void CreateFiles(Dictionary<string, Type> types, Dictionary<string, Function> functions);

    }
}