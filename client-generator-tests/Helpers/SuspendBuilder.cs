using System.Collections.Generic;
using System.Linq;
using client_generator.Deserializer.Helpers.Builders;

namespace client_generator_tests.Helpers
{
    public class SuspendBuilder : ISuspendBuilder<string>
    {

        private readonly BuildableObject _buildableObject;

        private readonly Dictionary<string, string> _created;

        public SuspendBuilder(BuildableObject buildableObject, Dictionary<string, string> created)
        {
            _buildableObject = buildableObject;
            _created = created;
        }

        public void Parse()
        {
        }

        public bool CanCreate()
        {
            return _buildableObject.RequiredIds.All(x => _created.Keys.Contains(x));
        }

        public string Create()
        {
            return _buildableObject.Id;
        }

    }
}
