using System.Collections.Generic;
using client_generator.Generators;
using client_generator.Models.Parameters;
using client_generator.Models.Requests;
using client_generator.Models.Responses;
using client_generator.Templates.Endpoints;

namespace client_generator.Models.Endpoints
{
    class Endpoint : TemplateHolder, IEndpoint
    {

        private readonly string _operationId;

        private readonly string _path;

        private readonly EndpointType _type;

        private readonly HashSet<IParameter> _parameters;

        private readonly IRequestBody _requestBody;

        private readonly IEnumerable<IHttpResponse> _responses;

        private bool _needsToBeGenerated = true;

        public Endpoint(string operationId, string path, EndpointType type, HashSet<IParameter> parameters,
            IRequestBody requestBody, IEnumerable<IHttpResponse> responses)
        {
            _operationId = operationId;
            _path = path;
            _type = type;
            _parameters = parameters;
            _requestBody = requestBody;
            _responses = responses;
        }

        public string GetId()
        {
            return _operationId;
        }

        public string GetPath()
        {
            return _path;
        }

        public EndpointType GetEndpointType()
        {
            return _type;
        }

        public IEnumerable<IParameter> GetParameters()
        {
            return _parameters;
        }

        public IRequestBody GetRequestBody()
        {
            return _requestBody;
        }

        public IEnumerable<IHttpResponse> GetResponses()
        {
            return _responses;
        }

        public override bool NeedsToBeGenerated()
        {
            return _needsToBeGenerated;
        }

        public override void Generate(IGeneratorContext generator)
        {
            generator.CreateNewEndpointContext();
            foreach (var param in _parameters ?? new HashSet<IParameter>())
            {
                if (param.NeedsToBeGenerated())
                {
                    param.Generate(generator);
                }
            }

            _requestBody?.Generate(generator);

            if (_responses != null)
            {
                foreach (var response in _responses)
                {
                    response.Generate(generator);
                }
            }

            var currentEndpointContext = generator.GetCurrentEndpointContext();

            var functionBody = new FunctionEndpointTemplate(_path, _operationId,
                currentEndpointContext.GetSignatureCode(), currentEndpointContext.GetParameterParsingCode(), _type,
                _requestBody != null, currentEndpointContext.GetResponseParseCodes(),
                currentEndpointContext.GetReturnType()).TransformText();

            generator.AddFunction(GetId(), functionBody);
            _needsToBeGenerated = false;
        }

    }
}
