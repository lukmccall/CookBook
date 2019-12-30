using System.Collections.Generic;
using client_generator.Models.Parameters;
using client_generator.Models.Requests;

namespace client_generator.Models.Endpoints
{
    public interface IEndpoint
    {

        string GetId();

        string GetPath();

        EndpointType GetEndpointType();

        IEnumerable<IParameter> GetParameters();

        IRequestBody GetRequestBody();

    }
}
