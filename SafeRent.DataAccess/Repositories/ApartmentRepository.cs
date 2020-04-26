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
            throw new System.NotImplementedException();
        }

        public void Delete(int apartmentId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int apartmentId, Apartment updatedApartment)
        {
            throw new System.NotImplementedException();
        }

        public Apartment GetById(int apartmentId)
        {
            throw new System.NotImplementedException();
        }
    }
}