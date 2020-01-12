using client_generator.Models;
using client_generator.Models.Parameters;

namespace client_generator.Templates.Parameters
{
    public class ParameterTemplateFactory : IParameterTemplateFactory
    {

        public (ITemplate signature, ITemplate parser) CreateParameterTemplate(string name, string type,
            bool isRequired,
            bool allowEmptyValue,
            SchemaType schemaType,
            ParameterType parameterType)
        {
            return (new ParameterSignatureTemplate(name, type, isRequired),
                new ParameterParserTemplate(name, isRequired, allowEmptyValue, schemaType, parameterType));
        }

    }
}
