using System.Collections.Generic;
using client_generator.Generators;
using client_generator.Models.Parameters;
using client_generator.Models.Requests;
using client_generator.Models.Responses;

namespace client_generator.Models.Endpoints
{
    public interface IEndpoint : IGenerable
    {

        string GetId();

        string GetPath();

        EndpointType GetEndpointType();

        IEnumerable<IParameter> GetParameters();

        IRequestBody GetRequestBody();

        IEnumerable<IHttpResponse> GetResponses();

    }
}
