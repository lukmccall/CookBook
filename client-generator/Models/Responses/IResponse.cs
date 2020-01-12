using System.Collections.Generic;
using client_generator.Models.Schemas;

namespace client_generator.Models.Responses
{
    public interface IResponse
    {

        IEnumerable<string> GetResponseType();

        ISchema GetSchemaForType(string type);

    }
}
