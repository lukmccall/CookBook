namespace client_generator.Templates.Responses
{
    public interface IResponseTemplateFactory
    {

        ITemplate CreateResponseParserTemplate(int status, string type);

    }
}
