using client_generator.Models.Schemas;

namespace client_generator.Models.Headers
{
    public class Header : IHeader
    {

        private readonly bool _allowEmptyValue;

        private readonly bool _isDeprecated;

        private readonly bool _isRequired;

        private readonly string _name;

        private readonly ISchema _schema;

        public Header(string name, ISchema schema, bool isRequired, bool isDeprecated, bool allowEmptyValue)
        {
            _isRequired = isRequired;
            _isDeprecated = isDeprecated;
            _allowEmptyValue = allowEmptyValue;
            _name = name;
            _schema = schema;
        }

        public bool IsRequired()
        {
            return _isRequired;
        }

        public bool IsDeprecated()
        {
            return _isDeprecated;
        }

        public bool AllowEmptyValue()
        {
            return _allowEmptyValue;
        }

        public string GetName()
        {
            return _name;
        }

        public ISchema GetSchema()
        {
            return _schema;
        }

    }
}
