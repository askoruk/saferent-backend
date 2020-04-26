using SafeRent.DataAccess.Data;
using SafeRent.DataAccess.Repositories.Interfaces;

namespace SafeRent.DataAccess.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AppDbContext _context;

        public NotificationRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}