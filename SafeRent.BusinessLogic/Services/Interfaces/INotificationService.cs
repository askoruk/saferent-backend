using System.Collections.Generic;
using SafeRent.DataAccess.Models;

namespace SafeRent.BusinessLogic.Services.Interfaces
{
	public interface INotificationService
	{
		void Add(Notification notification);
		Notification GetById(int notificationId);
		ICollection<Notification> GetAllUserNotifications(string userId);
	}
}