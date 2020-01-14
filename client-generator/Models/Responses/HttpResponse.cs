using System.Collections.Generic;
using client_generator.Models.Schemas;

namespace client_generator.Models.Responses
{
    public class HttpResponse : IHttpResponse
    {

        private readonly IResponse _response;

        private readonly int _status;

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
