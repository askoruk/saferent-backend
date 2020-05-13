using System.Collections.Generic;
using SafeRent.DataAccess.Models;

namespace SafeRent.BusinessLogic.Services.Interfaces
{
	public interface IKeyService
	{
		void Add(AccessKey accessKey);
		IEnumerable<AccessKey> GetUserKeys(string userId);
	}
}