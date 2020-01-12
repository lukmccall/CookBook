namespace client_generator.Templates.TsFiles
{
    public partial class MainFile
    {

        private readonly string _baseUrl;

        private readonly string _content;

        private readonly string _exports;

        private readonly string _imports;

        public MainFile(string baseUrl, string content, string imports, string exports)
        {
            _baseUrl = baseUrl;
            _content = content;
            _imports = imports;
            _exports = exports;
        }

    }
}
