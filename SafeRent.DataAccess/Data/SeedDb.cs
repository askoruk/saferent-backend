using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using SafeRent.DataAccess.Models;

namespace SafeRent.DataAccess.Data
{
    public class SeedDb
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<AppDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            
            context.Database.EnsureCreated();
            if (context.Users.Any()) return;

            var userRole = new IdentityRole {Name = "User"};
            roleManager.CreateAsync(userRole).GetAwaiter().GetResult();
            
            var adminRole = new IdentityRole {Name = "Admin"};
            roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
            
            var landlordRole = new IdentityRole {Name = "Landlord"};
            roleManager.CreateAsync(landlordRole).GetAwaiter().GetResult();
            
            var user = new ApplicationUser()
            {
                Email = "user@gmail.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "user"
            };

            var admin = new ApplicationUser()
            {
                Email = "admin@gmail.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "admin"
            };

            var landlord = new ApplicationUser()
            {
                Email = "landlord@gmail.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "Landlord"
            };

            userManager.CreateAsync(user, "00000000").GetAwaiter().GetResult();
            userManager.AddToRoleAsync(user, "User").GetAwaiter().GetResult();

            userManager.CreateAsync(admin, "00000000").GetAwaiter().GetResult();
            userManager.AddToRoleAsync(admin, "Admin").GetAwaiter().GetResult();
            
            userManager.CreateAsync(landlord, "00000000").GetAwaiter().GetResult();
            userManager.AddToRoleAsync(landlord, "Landlord").GetAwaiter().GetResult();
        }
    }
}