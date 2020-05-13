using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SafeRent.BusinessLogic.Models;
using SafeRent.BusinessLogic.Services.Interfaces;
using SafeRent.DataAccess.Models;

namespace SafeRent.Controllers
{
	[Route("[controller]")]
	public class KeyController : Controller
	{
		private readonly IEncryptionService _encryptionService;
		private readonly IKeyService _keyService;

		public KeyController(IEncryptionService encryptionService, IKeyService keyService)
		{
			_encryptionService = encryptionService;
			_keyService = keyService;
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
		
		[Route("getuserkeys/{userId}")]
		[HttpGet]
		public ActionResult<List<AccessKey>> GetUserKeys(string userId)
		{
			return _keyService.GetUserKeys(userId).ToList();
		}

		[HttpPost]
		public IActionResult Post([FromBody]AccessKey accessKey)
		{
			if (!ModelState.IsValid) return BadRequest();
			_keyService.Add(accessKey);
			return Ok();
		}
	}
}