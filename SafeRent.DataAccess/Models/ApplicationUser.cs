using Microsoft.AspNetCore.Identity;

namespace SafeRent.DataAccess.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}