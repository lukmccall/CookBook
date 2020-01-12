namespace client_generator.Templates.Requests
{
    public interface IRequestTemplateFactory
    {

        (ITemplate signature, ITemplate parser) CreateRequestTemplate(string schemaName, bool isRequired);

    }
}
