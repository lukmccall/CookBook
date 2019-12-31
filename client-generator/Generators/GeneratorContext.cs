using System.Collections.Generic;
using System.Linq;
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

            private readonly GeneratorContext _context;

            private readonly Dictionary<KeyValuePair<string, ParameterType>, KeyValuePair<string, string>> _parameters =
                new Dictionary<KeyValuePair<string, ParameterType>, KeyValuePair<string, string>>();

            private readonly HashSet<string> _relatedSchemas = new HashSet<string>();

            public EndpointContext(GeneratorContext context)
            {
                _context = context;
            }

            public void AddParameter(string name, string signatureCode, string parserCode, ParameterType type)
            {
                _parameters.Add(new KeyValuePair<string, ParameterType>(name, type),
                    new KeyValuePair<string, string>(signatureCode, parserCode));
            }

            public void UseSchema(ISchema schema)
            {
                if (schema.GetSchemaType() == SchemaType.Object)
                {
                    _relatedSchemas.Add(schema.GetName());
                }
            }

            public IEnumerable<string> GetParameterParsingCode()
            {
                return _parameters.Select(pair => pair.Value.Value).Where(x => x != null);
            }

            public IEnumerable<string> GetSignatureCode()
            {
                return _parameters.Select(pair => pair.Value.Key).Where(x => x != null);
            }

        }

    }
}
