using System;

namespace FluxDotNet
{
    public class StoreNotRegisteredException : Exception
    {
        public StoreNotRegisteredException()
            : base("Store has not been registered")
        {
        }
    }
}
