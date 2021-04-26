using Horus.Core.Dtos;
using Horus.Core.Dtos.SignIn;
using Horus.Core.Helpers.Interface;
using Horus.Core.Models;
using Horus.Core.Rest.Interfaces;
using Horus.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Horus.Core.Services.Implementation
{
    public class LoginService : ILoginService
    {
        private readonly IRestClient _restClient;
        private readonly IStorageHelper _storageHelper;

        public LoginService(IRestClient restClient, IStorageHelper storageHelper)
        {
            _restClient = restClient;
            _storageHelper = storageHelper;
        }


        public async Task<UserSignInResponse> OnSignInAsync(User userSignIn)
        {
            var userSignInRequest = new UserSignInRequest
            {
                Email = userSignIn.EmailAddress,
                Password = userSignIn.Password
            };
     
            var loginResponse = await _restClient.MakeApiCall<UserSignInResponse>(Constants.ApiUrl + "UserSignIn", HttpMethod.Post, userSignInRequest);
            return loginResponse;
        }
    }
}
