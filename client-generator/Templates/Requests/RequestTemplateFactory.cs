namespace client_generator.Templates.Requests
{
    internal class RequestTemplateFactory : IRequestTemplateFactory
    {

        public (ITemplate signature, ITemplate parser) CreateRequestTemplate(string schemaName, bool isRequired)
        {
            return (new RequestSignatureTemplate(schemaName, isRequired), new RequestParserTemplate());
        }

    }
}
