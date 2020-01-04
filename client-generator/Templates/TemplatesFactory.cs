using System.Collections.Generic;
using client_generator.Models.Endpoints;
using client_generator.Models.Parameters;
using client_generator.Models.Schemas;
using client_generator.Templates.Clients;
using client_generator.Templates.Endpoints;
using client_generator.Templates.Parameters;
using client_generator.Templates.Responses;
using client_generator.Templates.Schemes;

namespace client_generator.Templates
{
    public class TemplatesFactory : ITemplateFactory
    {

        private readonly IClassSchemaTemplateFactory _schemaTemplateFactory = new ClassSchemaTemplateFactory();

        private readonly IParameterTemplateFactory _parameterTemplateFactory = new ParameterTemplateFactory();

        private readonly IResponseTemplateFactory _responseTemplateFactory = new ResponseTemplateFactory();

        private readonly IEndpointTemplateFactory _endpointTemplateFactory = new EndpointTemplateFactory();

        private readonly IClientTemplateFactory _clientTemplateFactory = new ClientTemplateFactory();

        public ITemplate CreateClassSchemaTemplate(string name, Dictionary<string, ISchema> properties,
            IEnumerable<string> requiredProperties)
        {
            return _schemaTemplateFactory.CreateClassSchemaTemplate(name, properties, requiredProperties);
        }


        public (ITemplate signature, ITemplate parser) CreateParameterTemplate(string name, string type,
            bool isRequired,
            bool allowEmptyValue, ParameterType parameterType)
        {
            return _parameterTemplateFactory.CreateParameterTemplate(name, type, isRequired, allowEmptyValue,
                parameterType);
        }

        public ITemplate CreateResponseParserTemplate(int status, string type)
        {
            return _responseTemplateFactory.CreateResponseParserTemplate(status, type);
        }

        public ITemplate CreateEndpointTemplate(string url, string functionName, IEnumerable<string> signature,
            IEnumerable<string> returnsTypes,
            IEnumerable<string> parametersParsingCode, EndpointType type, bool haveBody,
            Dictionary<int, string> responses)
        {
            return _endpointTemplateFactory.CreateEndpointTemplate(url, functionName, signature, returnsTypes,
                parametersParsingCode, type, haveBody,
                responses);
        }

        public ITemplate CreateClientTemplate(string baseUrl, IEnumerable<string> functions, IEnumerable<string> imports)
        {
            return _clientTemplateFactory.CreateClientTemplate(baseUrl, functions, imports);
        }

    }
}
