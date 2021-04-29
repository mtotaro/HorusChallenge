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
    public class ChallengeServiceFixture : IDisposable
    {
        public readonly Mock<IRestClient> RestClient;
        public readonly Mock<IStorageHelper> MockStorageHelper;
        private readonly IChallengeService ChallengeService;

        public ChallengeServiceFixture()
        {

            RestClient = new Mock<IRestClient>();
            MockStorageHelper = new Mock<IStorageHelper>();
            ChallengeService = new ChallengeService(RestClient.Object);
        }

        public void Dispose()
        {
        }
    }
}
