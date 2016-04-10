using System;

namespace FluxDotNet
{
    public class NullDispatcherException : Exception
    {
        public NullDispatcherException()
            : base("Dispatcher has not been registered")
        {
        }
    }
}
