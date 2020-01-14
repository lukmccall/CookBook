using System.Collections.Generic;
using client_generator.Generators;
using client_generator.Models.Endpoints;
using client_generator.Models.Generators;
using client_generator.Models.Schemas;
using client_generator.Templates;

namespace client_generator_tests.Helpers
{
    public class GeneratorAccessor : Generator
    {

        public GeneratorAccessor(ITemplateFactory templateFactory)
        {
            GeneratorSettings.SchemePlace = SchemeGeneratePlace.WithCode;
            GeneratorContext = new GeneratorContext(templateFactory);
        }

        public void AccessParseSchemas(IEnumerable<ISchema> schemas)
        {
            ParseSchemas(schemas);
        }


        public void AccessParseEndpoints(IEnumerable<IEndpoint> endPoints)
        {
            ParseEndpoints(endPoints);
        }

        public List<string> AccessCreateFiles(Dictionary<string, Type> types, Dictionary<string, Function> functions)
        {
            return FileStrategies[GeneratorSettings.SchemePlace].CreateFiles(types, functions);
        }

        public IGeneratorContext AccessGeneratorContext => GeneratorContext;

    }
}
