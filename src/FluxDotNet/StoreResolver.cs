using System;
using System.Collections.Generic;

namespace FluxDotNet
{
    public interface IStoreResolver
    {
        void Register<T>(T store) where T : Store;

        T GetStore<T>() where T : Store;
    }

    public class DefaultStoreResolver : IStoreResolver
    {
        private readonly IDictionary<Type, Store> _stores = new Dictionary<Type, Store>();

        public void Register<T>(T store) where T : Store
        {
            var key = typeof(T);

            if (!_stores.ContainsKey(key))
                _stores.Add(key, null);

            _stores[key] = store;
        }

        public T GetStore<T>() where T : Store
        {
            var key = typeof(T);

            if (!_stores.ContainsKey(key))
                throw new StoreNotRegisteredException();

            return (T)_stores[key];
        }
    }
}
