using System.Collections.Generic;
using client_generator.Models.Endpoints;

namespace client_generator.Templates.Endpoints
{
    public partial class FunctionEndpointTemplate : ITemplate
    {

        private readonly string _functionName;

        private readonly bool _haveBody;

        private readonly IEnumerable<string> _parameterParsingCodes;

        private readonly Dictionary<int, string> _responses;

        private readonly IEnumerable<string> _returnTypes;

        private readonly IEnumerable<string> _signature;

        private readonly EndpointType _type;

        private readonly string _url;

        public FunctionEndpointTemplate(string url, string functionName, IEnumerable<string> signature,
            IEnumerable<string> returnsTypes,
            IEnumerable<string> parametersParsingCode, EndpointType type, bool haveBody,
            Dictionary<int, string> responses)
        {
            _functionName = functionName;
            _signature = signature;
            _url = url;
            _parameterParsingCodes = parametersParsingCode;
            _type = type;
            _haveBody = haveBody;
            _responses = responses;
            _returnTypes = returnsTypes;
        }

    }
}
