using System;
using System.Collections.Generic;
using System.Text;

namespace Horus.Core.Dtos.SignIn
{
    public class UserSignInRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
