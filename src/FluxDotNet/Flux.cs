namespace FluxDotNet
{
    public static class Flux
    {
        public static IDispatcher Dispatcher;
        public static IStoreResolver StoreResolver;

        static Flux()
        {
            Dispatcher = new Dispatcher();
            StoreResolver = new DefaultStoreResolver();
        }
    }
}
