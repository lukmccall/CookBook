using System.Collections.Generic;
using client_generator.Models.Endpoints;

namespace client_generator.Templates.Endpoints
{
    internal class EndpointTemplateFactory : IEndpointTemplateFactory
    {

        public ITemplate CreateEndpointTemplate(string url, string functionName, IEnumerable<string> signature,
            IEnumerable<string> returnsTypes,
            IEnumerable<string> parametersParsingCode, EndpointType type, bool haveBody,
            Dictionary<int, string> responses)
        {
            return new FunctionEndpointTemplate(url, functionName, signature, returnsTypes, parametersParsingCode, type,
                haveBody, responses);
        }

    }
}
