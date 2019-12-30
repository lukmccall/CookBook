using System.Collections.Generic;
using client_generator.Models.Endpoints;
using client_generator.Models.Headers;
using client_generator.Models.Parameters;
using client_generator.Models.Requests;
using client_generator.Models.Responses;
using client_generator.Models.Schemas;

namespace client_generator.Models
{
    public class OpenApiModel
    {

        private readonly Dictionary<string, ISchema> _schemas;

        private readonly Dictionary<string, IHeader> _headers;

        public OpenApiModel(Dictionary<string, ISchema> schemas, Dictionary<string, IHeader> headers)
        {
            _schemas = schemas;
            _headers = headers;
        }

        public class OpenApiModelBuilder
        {

            private readonly Dictionary<string, ISchema> _schemas = new Dictionary<string, ISchema>();

            private readonly Dictionary<string, IHeader> _headers = new Dictionary<string, IHeader>();

            private readonly Dictionary<string, IRequestBody> _requestBodies = new Dictionary<string, IRequestBody>();

            private readonly Dictionary<string, IResponse> _responses = new Dictionary<string, IResponse>();

            private readonly Dictionary<string, IParameter> _parameters = new Dictionary<string, IParameter>();

            private readonly List<IEndpoint> _endpoints = new List<IEndpoint>();

            public OpenApiModelBuilder AttachScheme(string path, ISchema schema)
            {
                _schemas.Add(path, schema);
                return this;
            }

            public OpenApiModelBuilder AttachScheme(Dictionary<string, ISchema> schemes)
            {
                foreach (var (path, schema) in schemes)
                {
                    _schemas.Add(path, schema);
                }

                return this;
            }

            public OpenApiModelBuilder AttachHeader(string path, IHeader header)
            {
                _headers.Add(path, header);
                return this;
            }

            public OpenApiModelBuilder AttachRequestBody(string path, IRequestBody request)
            {
                _requestBodies.Add(path, request);
                return this;
            }

            public OpenApiModelBuilder AttachResponse(string path, IResponse response)
            {
                _responses.Add(path, response);
                return this;
            }

            public OpenApiModelBuilder AttachParameter(string path, IParameter parameter)
            {
                _parameters.Add(path, parameter);
                return this;
            }

            public OpenApiModelBuilder AttachEndpoint(IEndpoint endpoint)
            {
                _endpoints.Add(endpoint);
                return this;
            }

            public ISchema GetSchemaForPath(string path)
            {
                return _schemas[path];
            }

            public IHeader GetHeaderForPath(string path)
            {
                return _headers[path];
            }

            public IRequestBody GetRequestBodyForPath(string path)
            {
                return _requestBodies[path];
            }

            public IResponse GetResponseForPath(string path)
            {
                return _responses[path];
            }

            public IParameter GetParameterForPath(string path)
            {
                return _parameters[path];
            }

            public OpenApiModel Create()
            {
                return new OpenApiModel(_schemas, _headers);
            }

        }

    }
}
