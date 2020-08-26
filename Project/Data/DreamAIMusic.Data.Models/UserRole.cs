namespace DreamAIMusic.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public class UserRole : IdentityUserRole<string>
    {
        public Role Role { get; set; }

        public ApplicationUser User { get; set; }
    }
}
