namespace FluxDotNet
{
    public interface IStore
    {
        void EmitChange();
    }

    public abstract class Store : IStore
    {
        public IDispatcher Dispatcher { get; private set; }

        protected Store()
        {
            Dispatcher = Flux.Dispatcher;
        }

        public void EmitChange()
        {
            Dispatcher.Dispatch(new ChangePayload());
        }
    }
}
