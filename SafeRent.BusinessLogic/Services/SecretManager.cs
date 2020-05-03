using System;
using System.IO;
using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Newtonsoft.Json;
using SafeRent.BusinessLogic.Models;

namespace SafeRent.BusinessLogic.Services
{
	public static class SecretManager
	{
        public static string GetSecret(string secretName)
        {
            var region = "eu-west-2";
            var secret = "";

            var memoryStream = new MemoryStream();

            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            var request = new GetSecretValueRequest();
            request.SecretId = secretName;
            request.VersionStage = "AWSCURRENT"; // VersionStage defaults to AWSCURRENT if unspecified.

            GetSecretValueResponse response = null;

            response = client.GetSecretValueAsync(request).Result;

            if (response.SecretString != null)
            {
                secret = response.SecretString;
            }
            else
            {
                memoryStream = response.SecretBinary;
                var reader = new StreamReader(memoryStream);
                var decodedBinarySecret =
                    System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(reader.ReadToEnd()));
            }

            var plainSecret = JsonConvert.DeserializeObject<SecretModel>(secret);
            return plainSecret.access_key_secret;
        }
    }
}