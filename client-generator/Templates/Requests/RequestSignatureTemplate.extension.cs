namespace client_generator.Templates.Requests
{
    public partial class RequestSignatureTemplate : ITemplate
    {

        private readonly string _schemaName;

        private readonly bool _IsRequired;

        public RequestSignatureTemplate(string schemaName, bool isRequired)
        {
            _schemaName = schemaName;
            _IsRequired = isRequired;
        }

    }
}
