using System.Collections.Generic;

namespace client_generator.Templates.Clients
{
    class ClientTemplateFactory : IClientTemplateFactory
    {

        public ITemplate CreateClientTemplate(string baseUrl, IEnumerable<string> functions, IEnumerable<string> imports)
        {
            return new ClientTemplate(baseUrl, functions, imports);
        }

    }
}
