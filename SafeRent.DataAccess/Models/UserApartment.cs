using System;

namespace SafeRent.DataAccess.Models
{
    public class UserApartment
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Guid ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}