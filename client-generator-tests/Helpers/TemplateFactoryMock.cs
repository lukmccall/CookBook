using System.Collections.Generic;
using client_generator.Models;
using client_generator.Models.Endpoints;
using client_generator.Models.Parameters;
using client_generator.Models.Schemas;
using client_generator.Templates;

namespace client_generator_tests.Helpers
{
    public class TemplateFactoryMock : ITemplateFactory
    {

        public ITemplate CreateClassSchemaTemplate(string name, Dictionary<string, ISchema> properties,
            IEnumerable<string> requiredProperties)
        {
            return new Template(name);
        }

        public (ITemplate signature, ITemplate parser) CreateParameterTemplate(string name, string type,
            bool isRequired,
            bool allowEmptyValue, SchemaType schemaType, ParameterType parameterType)
        {
            return (new Template(name), new Template(name));
        }

        public ITemplate CreateResponseParserTemplate(int status, string type)
        {
            return new Template(status.ToString());
        }

        public ITemplate CreateEndpointTemplate(string url, string functionName, IEnumerable<string> signature,
            IEnumerable<string> returnsTypes,
            IEnumerable<string> parametersParsingCode, EndpointType type, bool haveBody,
            Dictionary<int, string> responses)
        {
            return new Template(url);
        }

        public ITemplate CreateClientTemplate(string baseUrl, IEnumerable<string> functions,
            IEnumerable<string> imports)
        {
            return new Template(baseUrl);
        }

        public (ITemplate signature, ITemplate parser) CreateRequestTemplate(string schemaName, bool isRequired)
        {
            return (new Template(schemaName), new Template(schemaName));
        }

        private class Template : ITemplate
        {

            private readonly string _text;

            public Template(string text)
            {
                _text = text;
            }

            public string TransformText()
            {
                return _text;
            }

        }

    }
}
