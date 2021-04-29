using Horus.Core.Dtos.SignIn;
using System;
using System.Collections.Generic;
using System.Text;

namespace Horus.Tests.DummyDataProviders.Dtos.Login
{
    public static class LoginRequestProvider
    {
        public static UserSignInRequest GetLoginRequest()
        {
            return new UserSignInRequest
            {
                Email = "user2@mail.com",
                Password = "Password2"
            };
        }
    }

}
