using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goceren.WebUI.Identity
{
    public static class SeedIdentity
    {
        public static async Task Seed(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            var username = configuration["Data:AdminUser:username"];
            var email = configuration["Data:AdminUser:email"];
            var password = configuration["Data:AdminUser:password"];
            var role = configuration["Data:AdminUser:role"];


            if (await userManager.FindByEmailAsync(username) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
                await roleManager.CreateAsync(new IdentityRole("user"));
                var user = new ApplicationUser()
                {
                    UserName = username,
                    Email = email,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
