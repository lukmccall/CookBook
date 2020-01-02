using client_generator.Templates.Clients;
using client_generator.Templates.Endpoints;
using client_generator.Templates.Parameters;
using client_generator.Templates.Responses;
using client_generator.Templates.Schemes;

namespace client_generator.Templates
{
    public interface ITemplateFactory : IClassSchemaTemplateFactory, IParameterTemplateFactory,
        IResponseTemplateFactory, IEndpointTemplateFactory, IClientTemplateFactory
    {

    }
}
