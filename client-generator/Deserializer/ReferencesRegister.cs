using System.Collections.Generic;

namespace client_generator.Deserializer
{
    public class ReferencesRegister
    {
        private readonly Dictionary<string, object> _objectRegister;

        public ReferencesRegister()
        {
            _objectRegister = new Dictionary<string, object>();
        }

        public void Register(string reference, object obj)
        {
            _objectRegister.Add(reference, obj);
        }

        public bool Exists(string reference)
        {
            return _objectRegister.ContainsKey(reference);
        }

        public Dictionary<string, T> GetObjectOfType<T>()
        {
            var result = new Dictionary<string, T>();

            foreach (var (key, obj) in _objectRegister)
            {
                if (obj.GetType() == typeof(T))
                {
                    result[key] = (T) obj;
                }
            }

            return result;
        }
    }
}