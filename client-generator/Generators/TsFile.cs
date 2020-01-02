using System.Collections.Generic;
using System.Linq;
using System.Text;
using client_generator.Extensions;

namespace client_generator.Generators
{
    public class TsFile
    {

        private readonly Dictionary<string, string> _imports;

        private readonly HashSet<string> _exports;

        protected readonly StringBuilder Content;

        public TsFile()
        {
            _exports = new HashSet<string>();
            _imports = new Dictionary<string, string>();
            Content = new StringBuilder();
        }

        public void Write(string s)
        {
            Content.AppendLine(s);
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

        protected IEnumerable<string> GetImportStrings()
        {
            var imports = new List<string>();
            foreach (var group in _imports.GroupBy(pair => pair.Key))
            {
                var file = group.Key;
                var types = group.Select(x => x.Value).StrJoin(", ");
                var sb = new StringBuilder();
                sb.Append("import { ")
                    .Append(types)
                    .Append(" } from ")
                    .AppendLine($"./\"{file}\";");
                imports.Add(sb.ToString());
            }

            return imports;
        }

        protected string GetExportString()
        {
            var exports = _exports.StrJoin(", ");
            return new StringBuilder()
                .Append("export { ")
                .Append(exports)
                .AppendLine(" };")
                .ToString();
        }

        public virtual string GetFileContent()
        {
            var content = new StringBuilder();
            foreach (var importString in GetImportStrings())
            {
                content.AppendLine(importString);
            }

            content.AppendLine("");
            content.AppendLine(Content.ToString());
            content.AppendLine("");
            content.AppendLine(GetExportString());

            return content.ToString();
        }

    }
}
