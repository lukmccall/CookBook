using System.Collections.Generic;
using client_generator.Deserializer.Helpers.Collectors;
using client_generator.Deserializer.Helpers.References;

namespace client_generator.OpenApi._3._0._1.Deserializer
{
    public class ReferableCollector : IReferenceCollector
    {

        private readonly Dictionary<string, string> _missingReferences;

        private readonly ReferencesRegister _register;

        public ReferableCollector()
        {
            _missingReferences = new Dictionary<string, string>();
            _register = new ReferencesRegister();
        }

        public void Visit(string reference, IReferable<object> obj)
        {
            if (obj.GetObject() != null)
            {
                _register.Register(reference, obj.GetObject());
                return;
            }

            _missingReferences.Add(reference, obj.GetRef());
        }

        public bool Validate()
        {
            foreach (var (key, @ref) in _missingReferences)
            {
                if (_register.Exists(@ref))
                {
                    _missingReferences.Remove(key);
                }
            }

            return _missingReferences.Count == 0;
        }

        public Dictionary<string, T> GetObjectOfType<T>()
        {
            return _register.GetObjectOfType<T>();
        }

    }
}
