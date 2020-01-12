using System;
using System.Collections.Generic;

namespace client_generator.Deserializer.Helpers.Builders
{
    public class SuspendBuildsManager<T, TU>
    {

        private readonly Dictionary<string, TU> _done = new Dictionary<string, TU>();

        private readonly Action<string, T, Dictionary<string, TU>, Dictionary<string, ISuspendBuilder<TU>>>
            _initialMethod;

        private readonly Dictionary<string, ISuspendBuilder<TU>> _inProgress =
            new Dictionary<string, ISuspendBuilder<TU>>();

        private readonly int _maxIteration;

        private readonly Dictionary<string, T> _toCreate;

        public SuspendBuildsManager(Dictionary<string, T> toCreate,
            Action<string, T, Dictionary<string, TU>, Dictionary<string, ISuspendBuilder<TU>>> initialMethod,
            int maxIteration = 100)
        {
            _toCreate = toCreate;
            _initialMethod = initialMethod;
            _maxIteration = maxIteration;
        }

        public bool Build()
        {
            foreach (var (key, value) in _toCreate)
            {
                _initialMethod(key, value, _done, _inProgress);
            }

            var i = 0;
            while (_inProgress.Count != 0 && i < _maxIteration)
            {
                foreach (var (key, builder) in _inProgress)
                {
                    if (builder.CanCreate())
                    {
                        _done.Add(key, builder.Create());
                        _inProgress.Remove(key);
                    }
                    else
                    {
                        builder.Parse();
                    }
                }

                i++;
            }

            return _inProgress.Count == 0;
        }


        public Dictionary<string, TU> GetResult()
        {
            return _done;
        }

    }
}
