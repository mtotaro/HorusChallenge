using FluentAssertions;
using FluentAssertions.Execution;
using Horus.Core;
using Horus.Core.Dtos.SignIn;
using Horus.Tests.DummyDataProviders.Dtos.Login;
using Horus.Tests.Fixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Horus.Tests.Core.Services.Implementation
{
    [Collection("Service")]
    public class LoginServiceShould : IClassFixture<LoginServiceFixture>
    {
        private readonly LoginServiceFixture _fixture;

        public LoginServiceShould(LoginServiceFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetSupplierList_SuccessfullApiCall_SupplierHasData()
        {
            //Arrange
            var loginRequest = LoginRequestProvider.GetLoginRequest();
            var loginResponse = LoginResponseProvider.GetUserSignInResponse();


            _fixture.RestClient.Setup(x =>
                x.MakeApiCall<UserSignInResponse>(Constants.ApiUrl + "UserSignIn", HttpMethod.Post, loginRequest, null))
                .ReturnsAsync(new UserSignInResponse
                {
                    authorizationToken = loginResponse.authorizationToken,
                    email = loginResponse.email,
                    firstname = loginResponse.firstname,
                    surname = loginResponse.surname
                });

            //Act
            var userProfile = await _fixture.LoginService.OnSignInAsync(loginRequest);

            //Assert
            using (new AssertionScope())
            {
                userProfile.Should().NotBeNull();
                userProfile.firstname.Should().NotBeEmpty();
                userProfile.surname.Should().NotBeEmpty();
                userProfile.authorizationToken.Should().NotBeEmpty();
                userProfile.email.Should().NotBeEmpty();

            }
        }
    }
}
