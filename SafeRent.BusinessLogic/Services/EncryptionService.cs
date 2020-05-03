using System;
using System.Text;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using SafeRent.BusinessLogic.Models;
using SafeRent.BusinessLogic.Services.Interfaces;
using SafeRent.DataAccess.Models;

namespace SafeRent.BusinessLogic.Services
{
	public class EncryptionService : IEncryptionService
	{
		private readonly INotificationService _notificationService;

		public EncryptionService(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}
		
		public string GetStringAccessKey(string data)
		{
			var secret = SecretManager.GetSecret("EncryptionSecret");
			var key = GenerateKey(data, secret);

			return FormatAccessKey(data, key);
		}

		public bool VerifyAccessKey(string accessKey)
		{
			var keyInfo = GetKeyInfo(accessKey);
			var signature = GetAccessKeySignature(accessKey);
			var secret = SecretManager.GetSecret("EncryptionSecret");

			if (keyInfo == null || signature == null) return false;
			var keyInfoObject = KeyInfoModel.ParseFromString(keyInfo);
			
			_notificationService.NotifyThatKeyUsed(keyInfoObject.Bearer);
			
			DateTime.TryParse(keyInfoObject.ExpirationDate, out var expirationDate);
			
			if (DateTime.Now > expirationDate)
			{
				_notificationService.NotifyLandlordThatKeyExpired(keyInfoObject.Issuer);
				return false;
			}
			
			var daysLeft = DateTime.Now.Subtract(expirationDate).Days;
			if (daysLeft < 5)
			{
				_notificationService.Add(new Notification
				{
					DateSend = DateTime.Now.ToShortDateString(),
					UserId = keyInfoObject.Bearer,
					Message = $"Your access key expires in {daysLeft} days."
				});
			}
			
			return signature == Convert.ToBase64String(GenerateKey(keyInfo, secret));
		}
		
		private byte[] GenerateKey(string data, string secret)
		{
			var algorithm = new HMac(new Sha256Digest());
			algorithm.Init(new KeyParameter(Encoding.UTF8.GetBytes(secret)));
			
			var key = new byte[algorithm.GetMacSize()];
			var bytes = Encoding.UTF8.GetBytes(data);

			algorithm.BlockUpdate(bytes, 0, bytes.Length);
			algorithm.DoFinal(key, 0);

			return key;
		}

		private string FormatAccessKey(string data, byte[] key)
		{
			var dataBytes = Encoding.UTF8.GetBytes(data);

			var x = Encoding.UTF8.GetString(key);
			var y = Convert.ToBase64String(key);
			return $"{Convert.ToBase64String(dataBytes)}.{Convert.ToBase64String(key)}";
		}

		private string GetKeyInfo(string accessKey)
		{
			var separatorIndex = accessKey.IndexOf('.', StringComparison.InvariantCulture);
			if (separatorIndex < 0) return null;
			
			return Encoding.UTF8.GetString(
				Convert.FromBase64String(accessKey.Substring(0, separatorIndex))
				);
		}

		private string GetAccessKeySignature(string accessKey)
		{
			var separatorIndex = accessKey.IndexOf('.', StringComparison.InvariantCulture);
			if (separatorIndex < 0) return null;

			try
			{
				return Convert.ToBase64String(Convert.FromBase64String(accessKey.Substring(separatorIndex + 1)));
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}