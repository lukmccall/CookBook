using System.Text;

namespace client_generator.Generators
{
    class MainTsFile : TsFile
    {

        public override string GetFileContent()
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
