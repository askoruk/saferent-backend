using System;

namespace SafeRent.DataAccess.Models
{
    public class ApplicationUserApartment
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}