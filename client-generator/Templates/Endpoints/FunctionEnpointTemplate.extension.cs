using System.Collections;
using System.Collections.Generic;
using client_generator.Models.Endpoints;

namespace client_generator.Templates.Endpoints
{
    public partial class FunctionEndpointTemplate : ITemplate
    {

        private readonly string _operationId;


        private readonly IEnumerable<string> _signature;

        private readonly string _url;

        private readonly IEnumerable<string> _parameterParsingCodes;

        private readonly EndpointType _type;

        private readonly bool _haveBody;

        private readonly Dictionary<int, string> _responses;

        private readonly string _returnType;

        public FunctionEndpointTemplate(string url,
            string operationId, IEnumerable<string> signature,
            IEnumerable<string> parameterParsingCodes, EndpointType type, bool haveBody, Dictionary<int, string> responses, string returnType)
        {
            _operationId = operationId;
            _signature = signature;
            _url = url;
            _parameterParsingCodes = parameterParsingCodes;
            _type = type;
            _haveBody = haveBody;
            _responses = responses;
            _returnType = returnType;
        }

    }
}
