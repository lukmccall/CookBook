using System;
using System.Collections.Generic;
using client_generator.Models.Endpoints;
using client_generator.Models.Parameters;
using client_generator.Models.Schemas;
using client_generator.Templates.Clients;
using client_generator.Templates.Endpoints;
using client_generator.Templates.Parameters;
using client_generator.Templates.Requests;
using client_generator.Templates.Responses;
using client_generator.Templates.Schemes;

namespace client_generator.Templates
{
    public class TemplatesFactory : ITemplateFactory
    {

        private readonly IClientTemplateFactory _clientTemplateFactory;

        private readonly IEndpointTemplateFactory _endpointTemplateFactory;

        private readonly IParameterTemplateFactory _parameterTemplateFactory;

        private readonly IRequestTemplateFactory _requestTemplateFactory;

        private readonly IResponseTemplateFactory _responseTemplateFactory;

        private readonly IClassSchemaTemplateFactory _schemaTemplateFactory;

        public TemplatesFactory(
            IClientTemplateFactory clientTemplateFactory,
            IEndpointTemplateFactory endpointTemplateFactory,
            IParameterTemplateFactory parameterTemplateFactory,
            IRequestTemplateFactory requestTemplateFactory,
            IResponseTemplateFactory responseTemplateFactory,
            IClassSchemaTemplateFactory schemaTemplateFactory
        )
        {
            _clientTemplateFactory = clientTemplateFactory;
            _endpointTemplateFactory = endpointTemplateFactory;
            _parameterTemplateFactory = parameterTemplateFactory;
            _requestTemplateFactory = requestTemplateFactory;
            _responseTemplateFactory = responseTemplateFactory;
            _schemaTemplateFactory = schemaTemplateFactory;
        }

        public ITemplate CreateClassSchemaTemplate(string name, Dictionary<string, ISchema> properties,
            IEnumerable<string> requiredProperties)
        {
            return _schemaTemplateFactory.CreateClassSchemaTemplate(name, properties, requiredProperties);
        }


        public (ITemplate signature, ITemplate parser) CreateParameterTemplate(string name, string type,
            bool isRequired,
            bool allowEmptyValue,
            SchemaType schemaType,
            ParameterType parameterType)
        {
            return _parameterTemplateFactory.CreateParameterTemplate(name, type, isRequired, allowEmptyValue,
                schemaType, parameterType);
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

        public ITemplate CreateClientTemplate(string baseUrl, IEnumerable<string> functions,
            IEnumerable<string> imports)
        {
            return _clientTemplateFactory.CreateClientTemplate(baseUrl, functions, imports);
        }

        public (ITemplate signature, ITemplate parser) CreateRequestTemplate(string schemaName, bool isRequired)
        {
            return _requestTemplateFactory.CreateRequestTemplate(schemaName, isRequired);
        }


        public class TemplateFactoryBuilder
        {

            private IClientTemplateFactory _clientTemplateFactory;

            private IEndpointTemplateFactory _endpointTemplateFactory;

            private IParameterTemplateFactory _parameterTemplateFactory;

            private IRequestTemplateFactory _requestTemplateFactory;

            private IResponseTemplateFactory _responseTemplateFactory;

            private IClassSchemaTemplateFactory _schemaTemplateFactory;


            public TemplateFactoryBuilder SetClientTemplateFactory(IClientTemplateFactory clientTemplateFactory)
            {
                _clientTemplateFactory = clientTemplateFactory;
                return this;
            }

            public TemplateFactoryBuilder SetEndpointTemplateFactory(IEndpointTemplateFactory endpointTemplateFactory)
            {
                _endpointTemplateFactory = endpointTemplateFactory;
                return this;
            }

            public TemplateFactoryBuilder SetParameterTemplateFactory(
                IParameterTemplateFactory parameterTemplateFactory)
            {
                _parameterTemplateFactory = parameterTemplateFactory;
                return this;
            }


            public TemplateFactoryBuilder SetRequestTemplateFactory(IRequestTemplateFactory requestTemplateFactory)
            {
                _requestTemplateFactory = requestTemplateFactory;
                return this;
            }


            public TemplateFactoryBuilder SetResponseTemplateFactory(IResponseTemplateFactory responseTemplateFactory)
            {
                _responseTemplateFactory = responseTemplateFactory;
                return this;
            }

            public TemplateFactoryBuilder SetClassSchemaTemplateFactory(
                IClassSchemaTemplateFactory schemaTemplateFactory)
            {
                _schemaTemplateFactory = schemaTemplateFactory;
                return this;
            }

            public ITemplateFactory Build()
            {
                if (_clientTemplateFactory == null || _endpointTemplateFactory == null ||
                    _parameterTemplateFactory == null || _requestTemplateFactory == null ||
                    _responseTemplateFactory == null || _schemaTemplateFactory == null)
                {
                    throw new InvalidOperationException("All factories should be set.");
                }

                return new TemplatesFactory(
                    _clientTemplateFactory,
                    _endpointTemplateFactory,
                    _parameterTemplateFactory,
                    _requestTemplateFactory,
                    _responseTemplateFactory,
                    _schemaTemplateFactory
                );
            }

        }

    }
}
