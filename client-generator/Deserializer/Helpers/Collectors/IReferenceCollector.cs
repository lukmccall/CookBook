using System.Collections.Generic;
using client_generator.Deserializer.Helpers.References;

namespace client_generator.Deserializer.Helpers.Collectors
{
    public interface IReferenceCollector
    {

        void Visit(string reference, IReferable<object> obj);

        bool Validate();

        Dictionary<string, T> GetObjectOfType<T>();

    }
}
