using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SafeRent.BusinessLogic.Models;
using SafeRent.BusinessLogic.Services.Interfaces;
using SafeRent.DataAccess.Data;

namespace SafeRent.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authService;

        public AuthController(UserManager<ApplicationUser> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginModel.Password))
                return Unauthorized();

            var token = _authService.GetToken(loginModel);

            return Ok(new {token});
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_authService.IsEmailAvailable(registerModel.Email))
                return BadRequest("This email is already taken");
            
            var user = new ApplicationUser
            {
                Email = registerModel.Email,
                UserName = registerModel.Email
            };
			
            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);
			
            await _userManager.AddToRoleAsync(user, "user");
            return Ok("successfully registered");
        }

    }
}