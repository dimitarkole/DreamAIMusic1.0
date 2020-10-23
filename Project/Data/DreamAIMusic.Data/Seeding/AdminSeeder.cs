namespace DreamAIMusic.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using DreamAIMusic.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using static DreamAIMusic.Common.GlobalConstants;

    public class AdminSeeder : ISeeder
    {
        public const string Username = "rootadmin";
        public const string Password = "rootpass";

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var userFromDb = await userManager.FindByNameAsync(Username);

            if (userFromDb != null)
            {
                return;
            }

            var user = new ApplicationUser
            {
                UserName = Username,
                FirstName = "Root",
                LastName = "Root",
                Email = "root@gmail.com",
                EmailConfirmed = true,
            };

            await userManager.CreateAsync(user, Password);
            await userManager.AddToRoleAsync(user, Roles.AdministratorRoleName);
        }
    }
}
