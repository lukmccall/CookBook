using client_generator.Models;
using client_generator.Models.Parameters;
using client_generator.Models.Schemas;

namespace client_generator.Templates.Parameters
{
    public interface IParameterTemplateFactory
    {

        (ITemplate signature, ITemplate parser) CreateParameterTemplate(string name, string type, bool isRequired,
            bool allowEmptyValue, SchemaType schemaType, ParameterType parameterType);

    }
}
