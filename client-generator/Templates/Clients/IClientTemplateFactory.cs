using System.Collections.Generic;

namespace client_generator.Templates.Clients
{
    public interface IClientTemplateFactory
    {

        ITemplate CreateClientTemplate(string baseUrl, IEnumerable<string> functions, IEnumerable<string> imports);

    }
}
