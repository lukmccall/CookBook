using client_generator.Generators;
using client_generator.Models.Schemas;

namespace client_generator.Models.Parameters
{
    public interface IParameter : IGenerable
    {

        ParameterType GetParameterType();

        string GetName();

        bool IsRequired();

        bool IsDeprecated();

        bool AllowEmptyValue();

        ISchema GetSchema();

    }
}
