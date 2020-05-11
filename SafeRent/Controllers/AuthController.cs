using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SafeRent.BusinessLogic.Models;
using SafeRent.BusinessLogic.Services.Interfaces;
using SafeRent.DataAccess.Models;

namespace SafeRent.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginModel.Password))
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var token = _authService.GetToken(loginModel, claims);

            return Ok(new {token});
        }

        [AllowAnonymous]
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

        [Route("userinfo")]
        [HttpGet]
        public ActionResult<object> GetUserInfo()
        {
            var user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            var userId = user.Id;
            var email = user.Email;
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var phone = user.PhoneNumber;
            var role = User.IsInRole("admin") ? "admin" : "user";
            return Ok( new { userId, email, role, firstName, lastName, phone });
        }

        [Route("test")]
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("test");
        }
    }
}