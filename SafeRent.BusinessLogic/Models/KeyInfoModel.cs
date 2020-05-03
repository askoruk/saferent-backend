using System;
using System.Linq;

namespace SafeRent.BusinessLogic.Models
{
	public class KeyInfoModel
	{
		public string Issuer { get; set; }
		public string Bearer { get; set; }
		public int ApartmentId { get; set; }
		public string Created { get; set; }
		public string ExpirationDate { get; set; }

		public override string ToString()
		{
			return $"{Issuer}||{Bearer}||{ApartmentId}||{Created}||{ExpirationDate}";
		}

		public static KeyInfoModel ParseFromString(string data)
		{
			var values = data.Split("||");

			return new KeyInfoModel
			{
				Issuer = values[0],
				Bearer = values[1],
				ApartmentId = Convert.ToInt32(values[2]),
				Created = values[3],
				ExpirationDate = values[4]
			};
		}
	}
}