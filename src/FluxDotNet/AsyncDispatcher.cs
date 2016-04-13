using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FluxDotNet
{
    public interface IAsyncDispatcher
    {
        SynchronizationContext SynchronizationContext { get; set; }
    }

    public class AsyncDispatcher : Dispatcher, IAsyncDispatcher
    {
        public SynchronizationContext SynchronizationContext { get; set; }

        public AsyncDispatcher()
        {
            SynchronizationContext = AsyncOperationManager.SynchronizationContext;
        }

        public new void Dispatch<T>(T payload)
        {
            var callbacks = GetCallbacks<T>()
                .ToList();

            if (payload is ChangePayload)
                callbacks.ForEach(callback => SynchronizationContext.Post(x => callback((T) x), payload));
            else
                callbacks.ForEach(callback => Task.Factory.StartNew(() => callback(payload)));
        }
    }
}
