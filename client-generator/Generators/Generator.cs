using System.Collections.Generic;
using System.Linq;
using client_generator.Extensions;
using client_generator.Models;
using client_generator.Models.Endpoints;
using client_generator.Models.Schemas;

namespace client_generator.Generators
{
    public class Generator
    {

        protected readonly IGeneratorContext GeneratorContext = new GeneratorContext();

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

        void CreateFiles(IEnumerable<TsFile> files)
        {
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
                    parameter.GetName(), parameter.GetSchema().GetName(),
                    parameter.IsRequired(), parameter.AllowEmptyValue(), parameter.GetParameterType());

                parameters.Add(parameterTemplates.signature.TransformText(), parameterTemplates.parser.TransformText());
                relatedSchemas.AddNew(GetRelatedImportableSchema(parameter.GetSchema()));
            }

            // todo: refactor this 
            var hasBody = false;
            if (endpoint.GetRequestBody() != null)
            {
                hasBody = true;
                var body = endpoint.GetRequestBody();
                var schema = body.GetSchemaForType("application/json"); // todo: handle other types

                var req = body.IsRequired() ? "" : " | undefined";
                parameters.Add($"body: {schema.GetName()}{req}", "let _body = JSON.stringify(body);\n");
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

        private ISchema GetRelatedImportableSchema(ISchema schema)
        {
            if (schema == null)
            {
                return null;
            }

            if (schema.GetSchemaType() == SchemaType.Object)
            {
                return schema;
            }

            if (schema.GetSchemaType() == SchemaType.Array)
            {
                return GetRelatedImportableSchema(schema.GetRelatedSchemes().First());
            }

            return null;
        }

        void ParseSchema(ISchema schema)
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
