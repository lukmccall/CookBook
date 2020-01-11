using System.Collections.Generic;
using client_generator.Models.Schemas;

namespace client_generator.Extensions
{
    public static class HashSetExtensions
    {

        public static void AddNew(this HashSet<ISchema> hashSet, ISchema newElements)
        {
            if (newElements == null)
            {
                return;
            }

            if (!hashSet.Contains(newElements))
            {
                hashSet.Add(newElements);
            }
        }

    }
}
