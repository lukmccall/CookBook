using System.Collections.Generic;
using System.Linq;
using client_generator.Extensions;
using client_generator.Models;
using client_generator.Models.Parameters;
using client_generator.Models.Schemas;

namespace client_generator.Generators
{
    class GeneratorContext : IGeneratorContext
    {

        private readonly TsGenerator _tsGenerator;

        private IEndpointContext _endpointContext;

        public GeneratorContext(TsGenerator tsGenerator)
        {
            _tsGenerator = tsGenerator;
        }

        public void AddType(string typeName, string code, IEnumerable<ISchema> relatedSchemas)
        {
            _tsGenerator.GenerateType(typeName, code, relatedSchemas);
        }

        public void AddFunction(string name, string body)
        {
            _tsGenerator.AddFunction(name, body);
        }

        public void CreateNewEndpointContext()
        {
            _endpointContext = new EndpointContext(this);
        }

        public IEndpointContext GetCurrentEndpointContext()
        {
            return _endpointContext;
        }

        private class EndpointContext : IEndpointContext
        {

            // todo: refactor this
            private readonly GeneratorContext _context;

            private readonly Dictionary<KeyValuePair<string, ParameterType>, KeyValuePair<string, string>> _parameters =
                new Dictionary<KeyValuePair<string, ParameterType>, KeyValuePair<string, string>>();

            private readonly HashSet<string> _relatedSchemas = new HashSet<string>();

            private KeyValuePair<string, string>? _body;

            private readonly List<string> _returnTypes = new List<string>();

            private readonly Dictionary<int, string> _responses = new Dictionary<int, string>();

            public EndpointContext(GeneratorContext context)
            {
                _context = context;
            }

            public void AddParameter(string name, string signatureCode, string parserCode, ParameterType type)
            {
                _parameters.Add(new KeyValuePair<string, ParameterType>(name, type),
                    new KeyValuePair<string, string>(signatureCode, parserCode));
            }

            public void AddBody(string signatureCode, string parseCode)
            {
                _body = new KeyValuePair<string, string>(signatureCode, parseCode);
            }

            public void AddResponse(int status, string parseCode)
            {
                _responses.Add(status, parseCode);
            }

            public void AddReturnType(string type)
            {
                _returnTypes.Add(type);
            }

            public string GetReturnType()
            {
                if (_returnTypes.Count > 0)
                {
                    return _returnTypes.StrJoin(" | ");
                }

                return "void";
            }

            public Dictionary<int, string> GetResponseParseCodes()
            {
                return _responses;
            }


            public void UseSchema(ISchema schema)
            {
                if (schema.GetSchemaType() == SchemaType.Object)
                {
                    _relatedSchemas.Add(schema.GetName());
                }
            }

            public IEnumerable<string> GetSignatureCode()
            {
                return _parameters.Select(pair => pair.Value.Key).Where(x => x != null).Add(_body?.Key);
            }

            public IEnumerable<string> GetParameterParsingCode()
            {
                return _parameters.Select(pair => pair.Value.Value).Where(x => x != null).Add(_body?.Value);
            }

        }

    }
}
