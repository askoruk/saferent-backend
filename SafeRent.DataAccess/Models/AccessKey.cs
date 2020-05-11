namespace SafeRent.DataAccess.Models
{
	public class AccessKey
	{
		public int Id { get; set; }
		public string AccessKeyValue { get; set; }
		public string BearerId { get; set; }
		public string Created { get; set; }
		public string IssuerId { get; set; }
		public int ApartmentId { get; set; }
		public string ExpirationDate { get; set; }
	}
}
