using System.Collections.Generic;
using client_generator.Models.Parameters;
using client_generator.Models.Schemas;

namespace client_generator.Generators
{
    public interface IEndpointContext
    {

        void AddParameter(string name, string signatureCode, string parserCode, ParameterType type);

        void AddBody(string signatureCode, string parseCode);

        void AddResponse(int status, string parseCode);

        void AddReturnType(string type);

        string GetReturnType();

        Dictionary<int, string> GetResponseParseCodes();
        
        void UseSchema(ISchema schema);

        IEnumerable<string> GetParameterParsingCode();

        IEnumerable<string> GetSignatureCode();

    }
}
