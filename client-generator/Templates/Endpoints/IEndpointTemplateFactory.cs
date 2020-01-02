using System.Collections.Generic;
using client_generator.Models.Endpoints;

namespace client_generator.Templates.Endpoints
{
    public interface IEndpointTemplateFactory
    {

        ITemplate CreateEndpointTemplate(string url, string functionName, IEnumerable<string> signature,
            IEnumerable<string> returnsTypes, IEnumerable<string> parametersParsingCode, EndpointType type,
            bool haveBody, Dictionary<int, string> responses);

    }
}
