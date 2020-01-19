using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.Extensions
{
    public static class IEnumerableExtension
    {

        public static IEnumerable<T> ObjectDistinct<T, V>(this IEnumerable<T> query,
            Func<T, V> f)
        {
            return query.GroupBy(f).Select(x => x.First());
        }

    }
}
