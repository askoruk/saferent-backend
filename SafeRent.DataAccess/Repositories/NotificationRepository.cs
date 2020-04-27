using System.Collections.Generic;
using System.Linq;
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
            _context.Notifications.Add(notification);
        }

        public Notification GetById(int notificationId)
        {
            return _context.Notifications.Find(notificationId);
        }

        public ICollection<Notification> GetAllUserNotifications(string userId)
        {
            return _context.Notifications.Where(n => n.User.Id == userId).ToList();
        }
    }
}