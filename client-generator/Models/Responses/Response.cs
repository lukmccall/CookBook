using System.Collections.Generic;
using client_generator.Models.Schemas;

namespace client_generator.Models.Responses
{
    internal class Response : IResponse
    {

        private readonly Dictionary<string, ISchema> _schemasMap;

        public Response(Dictionary<string, ISchema> schemasMap)
        {
            _schemasMap = schemasMap;
        }

        public IEnumerable<string> GetResponseType()
        {
            return _schemasMap.Keys;
        }

        public ISchema GetSchemaForType(string type)
        {
            return _schemasMap.GetValueOrDefault(type, null);
        }

    }
}
