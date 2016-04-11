using FluxDotNet;
using WinFormsExample.Stores;

namespace WinFormsExample
{
    static class StoreRegistration
    {
        public static void Register()
        {
            Flux.StoreResolver.Register(new TodoStore());
        }
    }
}
