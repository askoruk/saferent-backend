using System.Collections.Generic;
using System.Linq;
using SafeRent.DataAccess.Data;
using SafeRent.DataAccess.Models;
using SafeRent.DataAccess.Repositories.Interfaces;

namespace SafeRent.DataAccess.Repositories
{
	public class KeyRepository : IKeyRepository
	{
		private readonly AppDbContext _context;

		public KeyRepository(AppDbContext context)
		{
			_context = context;
		}
		
		public void Add(AccessKey accessKey)
		{
			_context.AccessKeys.Add(accessKey);
			_context.SaveChanges();
		}

		public IEnumerable<AccessKey> GetUserKeys(string userId)
		{
			return _context.AccessKeys.Where(x => x.BearerId == userId).ToList();
		}
	}
}