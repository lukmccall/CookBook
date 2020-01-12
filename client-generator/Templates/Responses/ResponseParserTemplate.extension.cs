namespace client_generator.Templates.Responses
{
    public partial class ResponseParserTemplate : ITemplate
    {

        private readonly int _status;

        private readonly string _type;

        public ResponseParserTemplate(int status, string type)
        {
            _status = status;
            _type = type;
        }

    }
}
