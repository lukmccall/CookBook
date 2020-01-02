namespace client_generator.Templates.Responses
{
    class ResponseTemplateFactory : IResponseTemplateFactory
    {

        public ITemplate CreateResponseParserTemplate(int status, string type)
        {
            return new ResponseParserTemplate(status, type);
        }

    }
}
