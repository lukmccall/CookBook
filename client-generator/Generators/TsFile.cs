using System.Collections.Generic;
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

        public void ToSystemFile()
        {
            System.IO.File.WriteAllText($"{FileName}.ts", _stringBuilder.ToString());
        }

    }
}
