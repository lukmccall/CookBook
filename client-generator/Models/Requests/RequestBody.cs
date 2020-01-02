using System.Collections.Generic;
using client_generator.Generators;
using client_generator.Models.Schemas;
using client_generator.OpenApi._3._0._1;

namespace client_generator.Models.Requests
{
    class RequestBody : IRequestBody
    {

        private readonly bool _isRequired;

        private readonly Dictionary<string, ISchema> _schemasMap;

        public RequestBody(Dictionary<string, ISchema> schemasMap, bool isRequired)
        {
            _isRequired = isRequired;
            _schemasMap = schemasMap;
        }

        public bool IsRequired()
        {
            return _isRequired;
        }

        public IEnumerable<string> GetBodyTypes()
        {
            return _schemasMap.Keys;
        }

        public ISchema GetSchemaForType(string type)
        {
            return _schemasMap[type];
        }

    }
}
