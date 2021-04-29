using Horus.Tests.DummyDataProviders.Dispacher;
using MvvmCross.Base;
using MvvmCross.Tests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Horus.Tests.Fixture
{
    public class ChallengeViewModelFixture : IDisposable
    {
        public ChallengeViewModelFixture()
        {
            var mvxFixture = new MvxTestFixture();
            mvxFixture.ClearAll();
            mvxFixture.Ioc.RegisterSingleton<IMvxMainThreadAsyncDispatcher>(new DummyDispatcher());
        }
        public void Dispose()
        {
        }
    }
}
