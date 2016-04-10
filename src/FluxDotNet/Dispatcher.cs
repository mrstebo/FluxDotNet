using System;
using System.Collections.Generic;
using System.Linq;

namespace FluxDotNet
{
    public interface IDispatcher
    {
        void Register<T>(Action<T> callback);
        void Dispatch<T>(T payload);
    }

    public class Dispatcher : IDispatcher
    {
        private readonly IDictionary<Type, IList<object>> _callbacks = new Dictionary<Type, IList<object>>();

        public void Register<T>(Action<T> callback)
        {
            var key = typeof(T);

            if (!_callbacks.ContainsKey(key))
                _callbacks.Add(key, new List<object>());

            _callbacks[key].Add(callback);
        }

        public void Dispatch<T>(T payload)
        {
            var key = typeof(T);

            if (!_callbacks.ContainsKey(key))
                return;

            _callbacks[key]
                .OfType<Action<T>>()
                .ToList()
                .ForEach(callback => callback(payload));
        }
    }
}
