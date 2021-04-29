using Horus.Core.Dtos.SignIn;
using Horus.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horus.Core.Services.Interfaces
{
    public interface ILoginService
    {
        Task<UserSignInResponse> OnSignInAsync(UserSignInRequest userSignIn);
    }
}
