using System;

namespace SafeRent.DataAccess.Models
{
    public class Apartment
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Address { get; set; }
        public bool AnimalsAllowed { get; set; }
        public int RentalDays { get; set; }
        public bool AvailableForRent { get; set; }
    }
}