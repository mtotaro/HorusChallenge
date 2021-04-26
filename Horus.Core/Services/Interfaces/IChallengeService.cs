using Horus.Core.Dtos.Challenge;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horus.Core.Services.Interfaces
{
    public interface IChallengeService
    {
        Task<IList<ChallengeResponse>> ChallengeList();
    }
}
