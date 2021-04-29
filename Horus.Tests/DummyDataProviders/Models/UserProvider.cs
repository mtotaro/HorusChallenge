using Horus.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Horus.Tests.DummyDataProviders.Models
{
    public static class UserProvider
    {
        public static User GetUserProfile()
        {
            return new User
            {
                EmailAddress = "user1@mail.com",
                Password = "Password1"
            };
        }
    }
}
