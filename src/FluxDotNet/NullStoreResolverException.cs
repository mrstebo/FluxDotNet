using System;

namespace FluxDotNet
{
    public class NullStoreResolverException : Exception
    {
        public NullStoreResolverException()
            : base("Store resolver has not been configured")
        {
            
        }
    }
}
