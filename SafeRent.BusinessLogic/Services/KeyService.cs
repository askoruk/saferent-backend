using System.Collections.Generic;
using SafeRent.BusinessLogic.Services.Interfaces;
using SafeRent.DataAccess.Models;
using SafeRent.DataAccess.Repositories.Interfaces;

namespace SafeRent.BusinessLogic.Services
{
	public class KeyService : IKeyService
	{
		private readonly IKeyRepository _repository;

		public KeyService(IKeyRepository repository)
		{
			_repository = repository;
		}

		public void Add(AccessKey accessKey)
		{
			_repository.Add(accessKey);
		}

		public IEnumerable<AccessKey> GetUserKeys(string userId)
		{
			return _repository.GetUserKeys(userId);
		}
	}
}