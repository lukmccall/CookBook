using System.Collections.Generic;
using client_generator.Extensions;
using client_generator.Generators;
using client_generator.Models.Requests;
using client_generator.Models.Schemas;

namespace client_generator.Models.Responses
{
    class HttpResponse : TemplateHolder, IHttpResponse
    {

        private readonly int _status;

        private readonly IResponse _response;

        public HttpResponse(int status, IResponse response)
        {
            _status = status;
            _response = response;
        }

        public int GetStatus()
        {
            return _status;
        }

        public IEnumerable<string> GetResponseType()
        {
            return _response.GetResponseType();
        }

        public ISchema GetSchemaForType(string type)
        {
            return _response.GetSchemaForType(type);
        }

        public override bool NeedsToBeGenerated()
        {
            return true;
        }

        public override void Generate(IGeneratorContext generator)
        {
            var schema = _response.GetSchemaForType("application/json");
            if (schema != null)
            {
                if (schema.NeedsToBeGenerated())
                {
                    schema.Generate(generator);
                }

                generator.GetCurrentEndpointContext()?.UseSchema(schema);
                generator.GetCurrentEndpointContext()?.AddResponse(_status,
                    $"let _data{_status} = {schema.GetName()}.fromResponse(await _response.json());");
                if (_status.WasSuccessful())
                {
                    generator.GetCurrentEndpointContext()?.AddReturnType(schema.GetName());
                }
            }
            else
            {
                generator.GetCurrentEndpointContext()?.AddResponse(_status,
                    $"let _data{_status} = null;");
            }
        }

    }
}
