using System.Collections.Generic;
using SafeRent.BusinessLogic.Services.Interfaces;
using SafeRent.DataAccess.Models;
using SafeRent.DataAccess.Repositories.Interfaces;

namespace SafeRent.BusinessLogic.Services
{
	public class NotificationService : INotificationService
	{
		private readonly INotificationRepository _repository;

		public NotificationService(INotificationRepository repository)
		{
			_repository = repository;
		}
		
		public void Add(Notification notification)
		{
			_repository.Add(notification);
		}

		public Notification GetById(int notificationId)
		{
			return _repository.GetById(notificationId);
		}

		public ICollection<Notification> GetAllUserNotifications(string userId)
		{
			return _repository.GetAllUserNotifications(userId);
		}
	}
}