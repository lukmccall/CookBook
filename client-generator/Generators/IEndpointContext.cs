using System.Collections.Generic;
using client_generator.Models.Parameters;
using client_generator.Models.Schemas;

namespace client_generator.Generators
{
    public interface IEndpointContext
    {

        void AddParameter(string name, string signatureCode, string parserCode, ParameterType type);

        void UseSchema(ISchema schema);

        IEnumerable<string> GetParameterParsingCode();

        IEnumerable<string> GetSignatureCode();

    }
}
