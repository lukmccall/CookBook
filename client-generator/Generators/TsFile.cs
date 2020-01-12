using System.Collections.Generic;
using System.IO;
using System.Text;

namespace client_generator.Generators
{
    public class TsFile
    {

        public string FileName { get; }

        private StringBuilder _stringBuilder = new StringBuilder();

        public TsFile(string fileName)
        {
            FileName = fileName;
        }

        public void Write(string content)
        {
            _stringBuilder.AppendLine(content);
        }

        public void Write(IEnumerable<string> content)
        {
            foreach (var line in content)
            {
                _stringBuilder.AppendLine(line);
            }
        }

        public string ToSystemFile()
        {
            var path = Path.Join(Directory.GetCurrentDirectory(), $"{FileName}.ts");
            File.WriteAllText(path, _stringBuilder.ToString());
            return path;
        }

    }
}
