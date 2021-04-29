using Horus.Core.Helpers.Interface;
using Horus.Core.Rest.Interfaces;
using Horus.Core.Services.Implementation;
using Horus.Core.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Horus.Tests.Fixture
{
    public class LoginServiceFixture : IDisposable
    {
        public readonly Mock<IRestClient> RestClient;
        public readonly Mock<IStorageHelper> MockStorageHelper;
        public readonly ILoginService LoginService;

        public LoginServiceFixture()
        {

            RestClient = new Mock<IRestClient>();
            MockStorageHelper = new Mock<IStorageHelper>();
            LoginService = new LoginService(RestClient.Object, MockStorageHelper.Object);
        }

        public void Dispose()
        {
        }
    }
}
