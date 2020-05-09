using SafeRent.BusinessLogic.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace SafeRent.BusinessLogic.Services.Interfaces
{
    public interface IAuthService
    {
        string GetToken(LoginModel loginModel, Claim[] claims);
        bool IsEmailAvailable(string email);
    }
}