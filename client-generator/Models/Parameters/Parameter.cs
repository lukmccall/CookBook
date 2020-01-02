#nullable enable
using System.Text;
using client_generator.Generators;
using client_generator.Models.Schemas;
using client_generator.Templates.Parameters;

namespace client_generator.Models.Parameters
{
    class Parameter : TemplateHolder, IParameter
    {

        private readonly ParameterType _parameterType;

        private readonly string _name;

        private readonly bool _isRequired;

        private readonly bool _isDeprecated;

        private readonly bool _allowEmptyValue;

        private readonly ISchema _schema;

        public Parameter(string name, ParameterType parameterType, ISchema schema, bool isRequired, bool isDeprecated,
            bool allowEmptyValue)
        {
            _parameterType = parameterType;
            _name = name;
            _isRequired = isRequired;
            _isDeprecated = isDeprecated;
            _allowEmptyValue = allowEmptyValue;
            _schema = schema;
        }

        public ParameterType GetParameterType()
        {
            return _parameterType;
        }

        public string GetName()
        {
            return _name;
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

        public ISchema GetSchema()
        {
            return _schema;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Parameter parameter)
            {
                return GetParameterType() == parameter.GetParameterType() && GetName().Equals(parameter.GetName());
            }

            return false;
        }

        public override int GetHashCode()
        {
            return GetParameterType().GetHashCode() * GetName().GetHashCode();
        }

        public override bool NeedsToBeGenerated()
        {
            return true;
        }

        public override void Generate(IGeneratorContext generator)
        {
            if (_schema.NeedsToBeGenerated())
            {
                _schema.Generate(generator);
            }

            generator.GetCurrentEndpointContext()?.UseSchema(_schema);

            var req = _isRequired ? "" : " | undefined";
            generator.GetCurrentEndpointContext()
                ?.AddParameter(_name, $"{_name}: {_schema.GetName()}{req}", GetParseCode(), _parameterType);
        }

        private string GetParseCode()
        {
            return new ParameterParserTemplate(GetName(), IsRequired(), AllowEmptyValue(), GetParameterType())
                .TransformText();
        }

    }
}
