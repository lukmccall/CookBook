using System;
using System.Collections.Generic;

namespace client_generator.OpenApi._3._0._1.Builders
{
    public class SuspendBuildsManager<T, U>
    {
        private readonly Dictionary<string, T> _toCreate;

        private readonly Dictionary<string, ISuspendBuilder<U>> _inProgress =
            new Dictionary<string, ISuspendBuilder<U>>();

        private readonly Dictionary<string, U> _done = new Dictionary<string, U>();

        private readonly Action<string, T, Dictionary<string, U>, Dictionary<string, ISuspendBuilder<U>>>
            _initialMethod;

        private readonly int _maxIteration;

        public SuspendBuildsManager(Dictionary<string, T> toCreate,
            Action<string, T, Dictionary<string, U>, Dictionary<string, ISuspendBuilder<U>>> initialMethod,
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


        public Dictionary<string, U> GetResult()
        {
            return _done;
        }
    }
}