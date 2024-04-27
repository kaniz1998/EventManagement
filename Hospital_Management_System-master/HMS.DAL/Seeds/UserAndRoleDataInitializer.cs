using HMS.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Seeds
{
    public static class UserAndRoleDataInitializer
    {
        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    FirstName = "ADMIN",
                    LastName = "ADMIN",
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    ImageName = "ADMIN",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    PhoneNumber = "+8801743560992",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                };

                IdentityResult result = userManager.CreateAsync(user, "123456").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
            else
            {
                var user = userManager.FindByNameAsync("admin").Result;
                userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }

        private static void SeedRoles(RoleManager<ApplicationRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                ApplicationRole role = new ApplicationRole("Admin", "[{'controller':'Home','action':'index','text':'Dashboard','class':'fa fa-th','child':[]}");
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }

    }
}
