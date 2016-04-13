namespace FluxDotNet
{
    public class Flux
    {
        private static IDispatcher _dispatcher;
        private static IStoreResolver _storeResolver;

        public static IDispatcher Dispatcher
        {
            get { return _dispatcher ?? (_dispatcher = new Dispatcher()); }
            set { _dispatcher = value; }
        }

        public static IStoreResolver StoreResolver
        {
            get { return _storeResolver ?? (_storeResolver = new DefaultStoreResolver()); }
            set { _storeResolver = value; }
        }
    }
}
