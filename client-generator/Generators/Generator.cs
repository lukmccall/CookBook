using System.Collections.Generic;
using System.Linq;
using client_generator.Extensions;
using client_generator.Models;
using client_generator.Models.Endpoints;
using client_generator.Models.Generators;
using client_generator.Models.Schemas;
using Type = client_generator.Models.Generators.Type;

namespace client_generator.Generators
{
    public class Generator
    {

        protected readonly IGeneratorContext GeneratorContext = new GeneratorContext();

        protected GeneratorSettings GeneratorSettings;

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

        public void ParseSchemas(IEnumerable<ISchema> schemas)
        {
            foreach (var schema in schemas)
            {
                ParseSchema(schema);
            }
        }

        public void ParseEndpoints(IEnumerable<IEndpoint> endPoints)
        {
            foreach (var endpoint in endPoints)
            {
                ParseEndpoint(endpoint);
            }
        }

        public void CreateFiles(Dictionary<string, Type> types, Dictionary<string, Function> functions)
        {
            var typeFile = new TsFile(GeneratorSettings.TypesFileName);

            var relatedSchemas = types.Select(x => x.Value.RelatedSchemas)
                .SelectMany(x => x)
                .Distinct();

            var imports = GetImportsString(typeFile, relatedSchemas).ToList();
            if (imports.Any())
            {
                typeFile.Write(imports);
                typeFile.Write("");
            }

            foreach (var (_, type) in types)
            {
                typeFile.Write(type.Code);
                typeFile.Write("");
            }

            var exports = types.Select(x => x.Key).StrJoin(", ");

            typeFile.Write("export { " + exports + " };");

            var mainFile = new TsFile(GeneratorSettings.ClientFileName);

            relatedSchemas = functions.Select(x => x.Value.RelatedSchemas)
                .SelectMany(x => x)
                .Distinct();

            imports = GetImportsString(mainFile, relatedSchemas).ToList();

            var template = GeneratorContext.GetTemplateFactory()
                .CreateClientTemplate(GeneratorSettings.ServerUrl, functions.Select(x => x.Value.Code), imports);

            mainFile.Write(template.TransformText());

            typeFile.ToSystemFile();
            mainFile.ToSystemFile();
        }

        private IEnumerable<string> GetImportsString(TsFile fromFile, IEnumerable<ISchema> schemas)
        {
            if (fromFile.FileName == GeneratorSettings.TypesFileName ||
                GeneratorSettings.SchemePlace == SchemeGeneratePlace.WithCode)
            {
                return new List<string>();
            }

            return new List<string>
            {
                "import { " + schemas.Select(x => x.GetName()).StrJoin(", ") + " } from \"./types\";"
            };
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
