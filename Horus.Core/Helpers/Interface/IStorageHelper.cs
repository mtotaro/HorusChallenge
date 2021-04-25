using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horus.Core.Helpers.Interface
{
    public interface IStorageHelper
    {
        Task SetAccessToken(string token);

        Task<string> GetAccessToken();
    }
}
