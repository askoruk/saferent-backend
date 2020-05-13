using System.Collections.Generic;
using SafeRent.DataAccess.Models;

namespace SafeRent.DataAccess.Repositories.Interfaces
{
	public interface IKeyRepository
	{
		void Add(AccessKey accessKey);
		IEnumerable<AccessKey> GetUserKeys(string userId);
	}
}