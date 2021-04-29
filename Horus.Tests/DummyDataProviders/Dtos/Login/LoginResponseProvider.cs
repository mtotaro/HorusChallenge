using Horus.Core.Dtos.SignIn;
using System;
using System.Collections.Generic;
using System.Text;

namespace Horus.Tests.DummyDataProviders.Dtos.Login
{
    public class LoginResponseProvider
    {
        public static UserSignInResponse GetUserSignInResponse()
        {
            return new UserSignInResponse
            {
                authorizationToken = "9fccc300-a81a-4610-9588-e5a8c2885ce6",
                email = "user1@mail.com",
                firstname = "Jhonny",
                surname = "Lawrence"
            };
        }
    }
}
