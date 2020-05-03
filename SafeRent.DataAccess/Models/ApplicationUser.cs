using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace SafeRent.DataAccess.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        public ICollection<ApplicationUserApartment> ApplicationUserApartments { get; set; }
        [JsonIgnore]
        public ICollection<Notification> Notifications { get; set; }
    }
}