using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
    public class UserInitializer
    {
        private const string AdminRoleName = "admin";
        private const string AdminUserEmail = "admin@example.com";
        private const string AdminUserPassword = "Admin1!";
        
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await CreateRole(roleManager, AdminRoleName);
            await CreateUser(userManager, AdminUserEmail, AdminUserPassword, AdminRoleName);
          
        }
        private static async Task CreateUser(UserManager<User> userManager, string userEmail, string userPassword, string roleName)
        {
            if (await userManager.FindByNameAsync(userEmail) == null)
            {
            
                var admin = new User { Email = userEmail, UserName = userEmail, FirstName = "Glebich", MiddleName = "Sergeevich", LastName = "Solomin" };
                var result = await userManager.CreateAsync(admin, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, roleName);
                }
            }
        }
        private static async Task CreateRole(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }
}
