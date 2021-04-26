using Horus.Core.Dtos.Challenge;
using Horus.Core.Rest.Interfaces;
using Horus.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Horus.Core.Services.Implementation
{
    public class ChallengeService : IChallengeService
    {

        private readonly IRestClient _restClient;

        public ChallengeService(IRestClient restClient)
        {
            _restClient = restClient;
        }


        public async Task<IList<ChallengeResponse>> ChallengeList()
        {

            var challengeResponse = await _restClient.MakeApiCall<IList<ChallengeResponse>>(Constants.ApiUrl + "Challenges", HttpMethod.Get, null);
            return challengeResponse;
        }
}
}
