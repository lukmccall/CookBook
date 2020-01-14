using System.Collections.Generic;
using System.Text;

namespace client_generator.Extensions
{
    public static class StringBuilderExtension
    {

        public static StringBuilder AppendLines(this StringBuilder stringBuilder, IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                stringBuilder.AppendLine(line);
            }

            return stringBuilder;
        }

    }
}
