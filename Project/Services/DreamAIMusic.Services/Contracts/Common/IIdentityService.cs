using System;
using System.Collections.Generic;
using System.Text;

namespace DreamAIMusic.Services.Contracts.Common
{
    public interface IIdentityService
    {
        string GenerateJwtToken(string userId, string userName, string sicret);
    }
}
