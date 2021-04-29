using MvvmCross.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horus.Tests.DummyDataProviders.Dispacher
{
    public class DummyDispatcher : MvxSingleton<IMvxMainThreadAsyncDispatcher>, IMvxMainThreadAsyncDispatcher
    {
        public bool IsOnMainThread => true;

        public Task ExecuteOnMainThreadAsync(Action action, bool maskExceptions = true)
        {
            action?.Invoke();
            return Task.CompletedTask;
        }

        public Task ExecuteOnMainThreadAsync(Func<Task> action, bool maskExceptions = true)
        {
            return action?.Invoke();
        }
    }
}
