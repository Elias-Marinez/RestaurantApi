
using Microsoft.AspNetCore.Identity;
using Restaurant.Core.Application.Enums;
using Restaurant.Infrastructure.Identity.Entities;

namespace Restaurant.Infrastructure.Identity.Seeds
{
    public class DefaultAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser defaultUser = new()
            {
                UserName = "administratoruser",
                Email = "administratoruser@email.com",
                FirstName = "John",
                LastName = "Doe",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Pa$$word123");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Administrator.ToString());
                }
            }
        }
    }
}
