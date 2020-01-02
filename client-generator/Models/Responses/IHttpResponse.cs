using client_generator.Generators;

namespace client_generator.Models.Responses
{
    public interface IHttpResponse : IResponse, IGenerable
    {

        int GetStatus();

    }
}
