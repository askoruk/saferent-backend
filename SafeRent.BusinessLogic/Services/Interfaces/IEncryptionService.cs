namespace SafeRent.BusinessLogic.Services.Interfaces
{
	public interface IEncryptionService
	{
		public string GetStringAccessKey(string data);
		bool VerifyAccessKey(string accessKey);
	}
}