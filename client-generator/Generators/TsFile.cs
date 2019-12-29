using System.Collections.Generic;
using System.Text;

namespace client_generator.Generators
{
    public class TsFile
    {

        private readonly Dictionary<string, string> _imports;

        private readonly HashSet<string> _exports;

        private readonly StringBuilder _content;

        public TsFile()
        {
            _exports = new HashSet<string>();
            _imports = new Dictionary<string, string>();
            _content = new StringBuilder();
        }

        public void Write(string s)
        {
            _content.AppendLine(s);
        }

        public void Write(IEnumerable<string> sl)
        {
            foreach (var s in sl)
            {
                Write(s);
            }
        }

        public void Import(string import, string file)
        {
            if (!_imports.ContainsKey(file))
            {
                _imports.Add(file, import);
            }
        }

        public void Export(string export)
        {
            _exports.Add(export);
        }

    }
}
