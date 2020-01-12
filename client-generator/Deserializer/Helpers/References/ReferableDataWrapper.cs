namespace client_generator.Deserializer.Helpers.References
{
    public class ReferableDataWrapper<T> : IReferable<T>

    {

        private readonly T _parameter;

        public ReferableDataWrapper(T parameter)
        {
            _parameter = parameter;
        }

        public T GetObject()
        {
            return _parameter;
        }

        public string GetRef()
        {
            return null;
        }

    }
}
