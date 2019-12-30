using System.Collections.Generic;
using client_generator.Models.Parameters;
using client_generator.Models.Requests;

namespace client_generator.Models.Endpoints
{
    class Endpoint : IEndpoint
    {

        private readonly string _operationId;

        private readonly string _path;

        private readonly EndpointType _type;

        private readonly HashSet<IParameter> _parameters;

        private readonly IRequestBody _requestBody;


        public Endpoint(string operationId, string path, EndpointType type, HashSet<IParameter> parameters,
            IRequestBody requestBody)
        {
            _operationId = operationId;
            _path = path;
            _type = type;
            _parameters = parameters;
            _requestBody = requestBody;
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

    }
}
