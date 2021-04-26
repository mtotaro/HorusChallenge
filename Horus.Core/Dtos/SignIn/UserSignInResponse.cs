using System;
using System.Collections.Generic;
using System.Text;

namespace Horus.Core.Dtos.SignIn
{
    public class UserSignInResponse
    {
        public string email { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string authorizationToken { get; set; }
    }
}
