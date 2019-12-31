using System.Collections;
using System.Collections.Generic;

namespace client_generator.Templates.Endpoints
{
    public partial class FunctionEndpointTemplate : ITemplate
    {

        private readonly string _operationId;


        private readonly IEnumerable<string> _signature;

        private readonly string _url;

        private readonly IEnumerable<string> _parameterParsingCodes;

        public FunctionEndpointTemplate(string url,
            string operationId, IEnumerable<string> signature,
            IEnumerable<string> parameterParsingCodes)
        {
            _operationId = operationId;
            _signature = signature;
            _url = url;
            _parameterParsingCodes = parameterParsingCodes;
        }

    }
}
