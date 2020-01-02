using System.Collections.Generic;
using client_generator.Generators;
using client_generator.Models.Schemas;
using client_generator.OpenApi._3._0._1;

namespace client_generator.Models.Requests
{
    class RequestBody : TemplateHolder, IRequestBody
    {

        private readonly bool _isRequired;

        private readonly Dictionary<string, ISchema> _schemasMap;

        public RequestBody(Dictionary<string, ISchema> schemasMap, bool isRequired)
        {
            _isRequired = isRequired;
            _schemasMap = schemasMap;
        }

        public bool IsRequired()
        {
            return _isRequired;
        }

        public IEnumerable<string> GetBodyTypes()
        {
            return _schemasMap.Keys;
        }

        public ISchema GetSchemaForType(string type)
        {
            return _schemasMap[type];
        }

        public override bool NeedsToBeGenerated()
        {
            return true;
        }

        public override void Generate(IGeneratorContext generator)
        {
            // todo: handle other types
            if (_schemasMap.ContainsKey("application/json"))
            {
                var schema = _schemasMap["application/json"];
                if (schema.NeedsToBeGenerated())
                {
                    schema.Generate(generator);
                }

                var req = _isRequired ? "" : " | undefined";
                generator.GetCurrentEndpointContext().UseSchema(schema);
                generator.GetCurrentEndpointContext()
                    .AddBody($"body: {schema.GetName()}{req}", "let _body = JSON.stringify(body);\n");
            }
        }

    }
}
