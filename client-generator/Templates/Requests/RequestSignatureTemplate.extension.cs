namespace client_generator.Templates.Requests
{
    public partial class RequestSignatureTemplate : ITemplate
    {

        private readonly bool _IsRequired;

        private readonly string _schemaName;

        public RequestSignatureTemplate(string schemaName, bool isRequired)
        {
            _schemaName = schemaName;
            _IsRequired = isRequired;
        }

    }
}
