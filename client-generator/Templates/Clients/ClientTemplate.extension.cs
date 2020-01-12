using System.Collections.Generic;

namespace client_generator.Templates.Clients
{
    public partial class ClientTemplate : ITemplate
    {

        private readonly string _baseUrl;

        private readonly IEnumerable<string> _functions;

        private readonly IEnumerable<string> _imports;

        public ClientTemplate(string baseUrl, IEnumerable<string> functions, IEnumerable<string> imports)
        {
            _baseUrl = baseUrl;
            _functions = functions;
            _imports = imports;
        }

    }
}
