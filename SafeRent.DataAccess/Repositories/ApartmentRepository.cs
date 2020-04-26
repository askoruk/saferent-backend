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
            // _context.Apartments.Attach(updatedApartment);
            _context.Apartments.Update(updatedApartment);
            _context.SaveChanges();
        }

        public Apartment GetById(int apartmentId)
        {
            return _context.Apartments.Find(apartmentId);
        }
    }
}