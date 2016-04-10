using System;

namespace FluxDotNet
{
    public interface IFluxViewFor<out T> where T : Store
    {
    }

    public static class FluxViewForExtensions
    {
        public static void OnChange<T>(this IFluxViewFor<T> view, Action<T> callback)
            where T : Store
        {
            var dispatcher = Flux.Dispatcher;

            if (dispatcher == null)
                throw new NullDispatcherException();

            var store = new Lazy<T>(GetStore<T>);

            dispatcher.Register<ChangePayload>(payload => callback(store.Value));

            EmitChange(view);
        }

        public static void EmitChange<T>(this IFluxViewFor<T> view)
            where T : Store
        {
            Dispatch(view, new ChangePayload());
        }

        public static void Dispatch<TStore, TPayload>(this IFluxViewFor<TStore> view, TPayload payload)
            where TStore : Store
        {
            var dispatcher = Flux.Dispatcher;

            if (dispatcher == null)
                throw new NullDispatcherException();

            dispatcher.Dispatch(payload);
        }

        private static T GetStore<T>()
            where T : Store
        {
            if(Flux.StoreResolver == null)
                throw new NullStoreResolverException();

            return Flux.StoreResolver.GetStore<T>();
        }
    }
}
