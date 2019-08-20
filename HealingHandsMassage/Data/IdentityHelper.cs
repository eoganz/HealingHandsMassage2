using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealingHandsMassage.Data
{
    internal static class IdentityHelper
    {
        internal static readonly string Admin = "Admin";
        internal static readonly string Customer = "Customer";

        internal static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            RoleManager<IdentityRole> roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<IdentityUser> userManager = provider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityResult roleResult;

            foreach(string role in roles)
            {
                bool doesRoleExist = await roleManager.RoleExistsAsync(role);

                if(!doesRoleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            
                IdentityUser user = await userManager.FindByEmailAsync("jakeemettler@gmail.com");
                await userManager.AddToRoleAsync(user, "Admin");

        }

        internal static void SetIdentityConfigOptions(IdentityOptions options)
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
        }
    }
}
