using System;

namespace FluxDotNet
{
    public class NullStoreException : Exception
    {
        public NullStoreException()
            : base("Store has not been registered")
        {
        }
    }
}
