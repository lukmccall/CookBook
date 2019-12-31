using client_generator.Models.Parameters;

namespace client_generator.Templates.Parameters
{
    public partial class ParameterParserTemplate
    {

        private readonly string _name;

        private readonly bool _isRequired;

        private readonly bool _allowEmptyValue;

        private readonly ParameterType _type;

        public ParameterParserTemplate(string name, bool isRequired, bool allowEmptyValue, ParameterType type)
        {
            _name = name;
            _isRequired = isRequired;
            _allowEmptyValue = allowEmptyValue;
            _type = type;
        }

    }
}
