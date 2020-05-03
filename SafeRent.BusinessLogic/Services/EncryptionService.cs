using System;
using System.Text;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using SafeRent.BusinessLogic.Services.Interfaces;

namespace SafeRent.BusinessLogic.Services
{
	public class EncryptionService : IEncryptionService
	{
		public string GetStringAccessKey(string data)
		{
			var secret = "secret";
			var key = GenerateKey(data, secret);

			return FormatAccessKey(data, key);
		}

		public bool VerifyAccessKey(string accessKey)
		{
			var keyInfo = GetKeyInfo(accessKey);
			var signature = GetAccessKeySignature(accessKey);
			var secret = "secret";
			
			return signature == Encoding.UTF8.GetString(GenerateKey(keyInfo, secret));
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
			
			return $"{Convert.ToBase64String(dataBytes)}.{Convert.ToBase64String(key)}";
		}

		private string GetKeyInfo(string accessKey)
		{
			var separatorIndex = accessKey.IndexOf('.', StringComparison.InvariantCulture);
			if (separatorIndex < 0) return null;
			
			return Encoding.UTF8.GetString(Convert.FromBase64String(accessKey.Substring(0, separatorIndex)));
		}

		private string GetAccessKeySignature(string accessKey)
		{
			var separatorIndex = accessKey.IndexOf('.', StringComparison.InvariantCulture);
			if (separatorIndex < 0) return null;
			
			return Encoding.UTF8.GetString(Convert.FromBase64String(accessKey.Substring(separatorIndex)));
		}
	}
}