namespace DreamAIMusic.Services.Contracts.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Data.Models;
    using Microsoft.AspNetCore.Identity;

    public interface IIdentityService
    {
        string GenerateJwtToken(string userId, string userName, string sicret);

        IdentityUserRole<string> SetUserRole(ApplicationUser user);
    }
}
