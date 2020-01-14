using client_generator.Models;
using client_generator.Models.Parameters;
using client_generator.Models.Schemas;

namespace client_generator.Templates.Parameters
{
    public partial class ParameterParserTemplate : ITemplate
    {

        private readonly bool _allowEmptyValue;

        private readonly bool _isRequired;

        private readonly string _name;

        private readonly SchemaType _schemaType;

        private readonly ParameterType _type;

        public ParameterParserTemplate(string name, bool isRequired, bool allowEmptyValue, SchemaType schemaType,
            ParameterType type)
        {
            _name = name;
            _isRequired = isRequired;
            _allowEmptyValue = allowEmptyValue;
            _schemaType = schemaType;
            _type = type;
        }

    }
}
