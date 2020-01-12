using client_generator.Models.Schemas;

namespace client_generator.Models.Headers
{
    public interface IHeader
    {

        bool IsRequired();

        bool IsDeprecated();

        bool AllowEmptyValue();

        string GetName();

        ISchema GetSchema();

    }
}
