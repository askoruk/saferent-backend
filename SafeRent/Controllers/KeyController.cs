using System;
using Microsoft.AspNetCore.Mvc;
using SafeRent.BusinessLogic.Models;
using SafeRent.BusinessLogic.Services;
using SafeRent.BusinessLogic.Services.Interfaces;

namespace SafeRent.Controllers
{
	[Route("[controller]")]
	public class KeyController : Controller
	{
		private readonly IEncryptionService _encryptionService;

		public KeyController(IEncryptionService encryptionService)
		{
			_encryptionService = encryptionService;
		}

		[Route("getkey")]
		[HttpPost]
		public IActionResult GetAccessKey([FromBody]KeyInfoModel model)
		{
			try
			{
				var stringData = model.ToString();
				return Ok(_encryptionService.GetStringAccessKey(stringData));
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[Route("verify")]
		[HttpPost]
		public ActionResult<bool> VerifyAccessKey([FromForm]string accessKey)
		{
			return _encryptionService.VerifyAccessKey(accessKey);
		}

	}
}