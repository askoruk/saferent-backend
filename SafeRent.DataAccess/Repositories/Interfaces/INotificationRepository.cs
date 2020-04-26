using SafeRent.DataAccess.Models;

namespace SafeRent.DataAccess.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        void Add(Notification notification);
        void GetById(int notificationId);
    }
}