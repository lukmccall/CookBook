using System.Collections.Generic;
using client_generator.Deserializer.Helpers.Collectors;
using client_generator.Deserializer.Helpers.References;

namespace client_generator.OpenApi._3._0._1.Deserializer
{
    public class ReferableCollector : IReferenceCollector
    {

        private readonly ReferencesRegister _register;


        private HashSet<(string @ref, string path)> _missingReferences =
            new HashSet<(string @ref, string path)>();

        public ReferableCollector(ReferencesRegister referencesRegister)
        {
            _register = referencesRegister;
        }

        public void Visit(string path, IReferable<object> obj)
        {
            if (obj.GetObject() != null)
            {
                _register.Register(path, obj.GetObject());
                return;
            }

            _missingReferences.Add((obj.GetRef(), path));
        }

        public bool Validate()
        {
            var newMissingReferences = new HashSet<(string @ref, string path)>();
            foreach (var missingReference in _missingReferences)
            {
                if (!_register.Exists(missingReference.@ref))
                {
                    newMissingReferences.Add(missingReference);
                }
            }

            _missingReferences = newMissingReferences;
            return _missingReferences.Count == 0;
        }

        public Dictionary<string, T> GetObjectOfType<T>()
        {
            return _register.GetObjectOfType<T>();
        }

    }
}
