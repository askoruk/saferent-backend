using SafeRent.DataAccess.Data;
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
    }
}