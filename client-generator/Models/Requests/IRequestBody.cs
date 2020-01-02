using System.Collections.Generic;
using client_generator.Generators;
using client_generator.Models.Schemas;

namespace client_generator.Models.Requests
{
    public interface IRequestBody
    {

        bool IsRequired();

        IEnumerable<string> GetBodyTypes();

        ISchema GetSchemaForType(string type);

    }
}
