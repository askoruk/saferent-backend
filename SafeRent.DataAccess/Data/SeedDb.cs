using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
namespace SafeRent.DataAccess.Data
{
    public class SeedDb
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<AppDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();
            if (context.Users.Any()) return;
            var user = new ApplicationUser()
            {
                Email = "ali@gmail.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "Ali"
            };
            userManager.CreateAsync(user, "Ali@123");
        }
    }
}