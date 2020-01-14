using System.Collections.Generic;
using System.Linq;
using client_generator.Deserializer.Helpers.Builders;

namespace client_generator_tests.Helpers
{
    public class BuildableObject
    {

        public string Id { get; set; }

        public string[] RequiredIds { get; set; }


        public static void BuildMethod(string id, BuildableObject currentObj, Dictionary<string, string> created,
            Dictionary<string, ISuspendBuilder<string>> inProgress)
        {
            if (currentObj.RequiredIds.All(x => created.Keys.Contains(x)))
            {
                created.Add(id, currentObj.Id);
            }
            else
            {
                inProgress.Add(id, new SuspendBuilder(currentObj, created));
            }
        }

    }
}
