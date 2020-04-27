using System.Collections.Generic;
using SafeRent.DataAccess.Models;

namespace SafeRent.DataAccess.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        void Add(Notification notification);
        Notification GetById(int notificationId);
        ICollection<Notification> GetAllUserNotifications(string userId);
    }
}