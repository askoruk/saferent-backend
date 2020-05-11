using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SafeRent.DataAccess.Data;
using SafeRent.DataAccess.Models;
using SafeRent.DataAccess.Repositories.Interfaces;

namespace SafeRent.DataAccess.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly AppDbContext _context;

        public ApartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            _context.SaveChanges();

            int id = apartment.Id;
        }

        public void Delete(int apartmentId)
        {
            var apartment = _context.Apartments.Find(apartmentId);
            if (apartment == null) return;
            
            _context.Apartments.Remove(apartment);
            _context.SaveChanges();
        }

        public void Update(Apartment updatedApartment)
        {
            _context.Apartments.Update(updatedApartment);
            _context.SaveChanges();
        }

        public Apartment GetById(int apartmentId)
        {
            return _context.Apartments.Find(apartmentId);
        }

        public ICollection<Apartment> GetAllApartments()
        {
            return _context.Apartments.ToList();
        }

        public void AddUserToApartment(string userId, int apartmentId)
        {
            var user = _context.Users.Find(userId);
            var apartment = _context.Apartments.Find(apartmentId);

            if (user == null || apartment == null) return;

            _context.Add(new ApplicationUserApartment
            {
                ApplicationUser = user,
                Apartment = apartment,
                EndOfRental = DateTime.Now.ToString(CultureInfo.InvariantCulture)
            });
            _context.SaveChanges();
        }

        public List<Apartment> GetApartmentsForUser(string userId)
        {
            return _context.Apartments
                .Include(a => a.ApplicationUserApartments)
                .Where(a => a.ApplicationUserApartments.Any(x => x.ApplicationUserId == userId))
                .ToList();
        }

        public object GetApartmentOwner(string userId, int apartmentId)
        {
            var user = _context.Users
                .Include(x => x.ApplicationUserApartments)
                .FirstOrDefault(x => x.Id != userId && x.ApplicationUserApartments.Any(a => a.ApartmentId == apartmentId));

            return user != null ? new {user.Id, user.FirstName, user.LastName, user.Email, user.PhoneNumber} : null;
        }

        public List<AccessKey> GetUserKeys(string userId)
        {
            return _context.AccessKeys.Where(x => x.BearerId == userId).ToList();
        }

    }
}