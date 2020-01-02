using System.Collections.Generic;
using client_generator.Extensions;
using client_generator.Generators;
using client_generator.Models.Requests;
using client_generator.Models.Schemas;

namespace client_generator.Models.Responses
{
    class HttpResponse : IHttpResponse
    {

        private readonly int _status;

        private readonly IResponse _response;

        public HttpResponse(int status, IResponse response)
        {
            _status = status;
            _response = response;
        }

        public int GetStatus()
        {
            return _status;
        }

        public IEnumerable<string> GetResponseType()
        {
            return _response.GetResponseType();
        }

        public ISchema GetSchemaForType(string type)
        {
            return _response.GetSchemaForType(type);
        }

    }
}
