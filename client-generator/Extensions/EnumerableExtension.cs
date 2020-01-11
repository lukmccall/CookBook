using System.Collections.Generic;

namespace client_generator.Extensions
{
    public static class EnumerableExtension
    {

        public static IEnumerable<T> Add<T>(this IEnumerable<T> e, T value)
        {
            foreach (var cur in e)
            {
                yield return cur;
            }

            if (value != null)
            {
                yield return value;
            }
        }

        public static string StrJoin(this IEnumerable<string> e, string separator)
        {
            return string.Join(separator, e);
        }

    }
}
