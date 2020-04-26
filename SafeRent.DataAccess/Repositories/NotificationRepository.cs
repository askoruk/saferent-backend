using SafeRent.DataAccess.Data;
using SafeRent.DataAccess.Models;
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

        public void Add(Notification notification)
        {
            throw new System.NotImplementedException();
        }

        public void GetById(int notificationId)
        {
            throw new System.NotImplementedException();
        }
    }
}