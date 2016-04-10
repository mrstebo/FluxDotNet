namespace FluxDotNet
{
    public interface IStore
    {
        void EmitChange();
    }

    public abstract class Store : IStore
    {
        public IDispatcher Dispatcher { get; private set; }

        protected Store(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
        }

        public void EmitChange()
        {
            Dispatcher.Dispatch(new ChangePayload());
        }
    }
}
