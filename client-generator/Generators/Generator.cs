using System.Collections.Generic;
using System.Linq;
using client_generator.Extensions;
using client_generator.Generators.FilesStrategies;
using client_generator.Models;
using client_generator.Models.Endpoints;
using client_generator.Models.Generators;
using client_generator.Models.Schemas;
using Type = client_generator.Models.Generators.Type;

namespace client_generator.Generators
{
    public class Generator : GeneratorTemplate
    {

        protected readonly Dictionary<SchemeGeneratePlace, IGeneratorFileStrategy> FileStrategies;

        public Generator()
        {
            FileStrategies = new Dictionary<SchemeGeneratePlace, IGeneratorFileStrategy>
            {
                {SchemeGeneratePlace.SeparatedFile, new SeparateFileStrategy(GeneratorContext, GeneratorSettings)},
                {SchemeGeneratePlace.WithCode, new SingleFileStrategy(GeneratorContext, GeneratorSettings)},
                {SchemeGeneratePlace.AllSeparated, new AllSeparatedFileStrategy(GeneratorContext, GeneratorSettings)}
            };
        }
        
        protected override void ParseSchemas(IEnumerable<ISchema> schemas)
        {
            foreach (var schema in schemas)
            {
                ParseSchema(schema);
            }
        }

        protected override void ParseEndpoints(IEnumerable<IEndpoint> endPoints)
        {
            foreach (var endpoint in endPoints)
            {
                ParseEndpoint(endpoint);
            }
        }

        protected override void CreateFiles(Dictionary<string, Type> types, Dictionary<string, Function> functions)
        {
            FileStrategies[GeneratorSettings.SchemePlace].CreateFiles(types, functions);
        }

        private void ParseEndpoint(IEndpoint endpoint)
        {
            var relatedSchemas = new HashSet<ISchema>();
            var parameters = new Dictionary<string, string>();
            var responses = new Dictionary<int, string>();
            var returnTypes = new List<string>();

            foreach (var parameter in endpoint.GetParameters())
            {
                var parameterTemplates = GeneratorContext.GetTemplateFactory().CreateParameterTemplate(
                    parameter.GetName(),
                    parameter.GetSchema().GetName(),
                    parameter.IsRequired(),
                    parameter.AllowEmptyValue(),
                    parameter.GetSchema().GetSchemaType(),
                    parameter.GetParameterType()
                );

                parameters.Add(parameterTemplates.signature.TransformText(), parameterTemplates.parser.TransformText());
                relatedSchemas.AddNew(GetRelatedImportableSchema(parameter.GetSchema()));
            }

            var hasBody = false;
            if (endpoint.GetRequestBody() != null)
            {
                hasBody = true;
                var body = endpoint.GetRequestBody();
                var schema = body.GetSchemaForType("application/json"); // todo: handle other types

                var requestTemplates = GeneratorContext.GetTemplateFactory()
                    .CreateRequestTemplate(schema.GetName(), body.IsRequired());
                parameters.Add(requestTemplates.signature.TransformText(), requestTemplates.parser.TransformText());
                relatedSchemas.AddNew(GetRelatedImportableSchema(schema));
            }

            foreach (var response in endpoint.GetResponses())
            {
                var schema = response.GetSchemaForType("application/json"); // todo: handle other types; 
                if (schema != null)
                {
                    var responseParser = GeneratorContext.GetTemplateFactory()
                        .CreateResponseParserTemplate(response.GetStatus(), schema.GetName());
                    responses.Add(response.GetStatus(), responseParser.TransformText());
                    relatedSchemas.AddNew(GetRelatedImportableSchema(schema));

                    if (response.GetStatus().WasSuccessful())
                    {
                        returnTypes.Add(schema.GetName());
                    }
                }
            }

            if (returnTypes.Count == 0)
            {
                returnTypes.Add("void");
            }

            var endPointTemplate = GeneratorContext.GetTemplateFactory()
                .CreateEndpointTemplate(endpoint.GetPath(), endpoint.GetId(), parameters.Select(x => x.Key),
                    returnTypes, parameters.Select(x => x.Value), endpoint.GetEndpointType(),
                    hasBody, responses);
            GeneratorContext.AddFunction(endpoint.GetId(), endPointTemplate.TransformText(), relatedSchemas);
        }

        private static ISchema GetRelatedImportableSchema(ISchema schema)
        {
            if (schema == null)
            {
                return null;
            }

            if (schema.GetSchemaType() == SchemaType.Object)
            {
                return schema;
            }

            return schema.GetSchemaType() == SchemaType.Array
                ? GetRelatedImportableSchema(schema.GetRelatedSchemes().First())
                : null;
        }

        private void ParseSchema(ISchema schema)
        {
            if (schema.GetSchemaType() == SchemaType.Object && !GeneratorContext.TypeExists(schema.GetName()))
            {
                var template = schema.GetTemplate(GeneratorContext.GetTemplateFactory());
                GeneratorContext.AddType(schema.GetName(), template.TransformText(), schema.GetRelatedSchemes());
            }

            foreach (var innerSchema in schema.GetRelatedSchemes())
            {
                ParseSchema(innerSchema);
            }
        }

    }
}
