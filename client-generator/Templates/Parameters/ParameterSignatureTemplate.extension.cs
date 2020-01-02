namespace client_generator.Templates.Parameters
{
    public partial class ParameterSignatureTemplate : ITemplate
    {

        private readonly string _name;

        private readonly bool _isRequired;

        private readonly string _type;

        public ParameterSignatureTemplate(string name, string type, bool isRequired)
        {
            _name = name;
            _type = type;
            _isRequired = isRequired;
        }

    }
}
