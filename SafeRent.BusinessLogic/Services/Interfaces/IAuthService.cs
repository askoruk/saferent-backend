using SafeRent.BusinessLogic.Models;

namespace SafeRent.BusinessLogic.Services.Interfaces
{
    public interface IAuthService
    {
        string GetToken(LoginModel loginModel);
        bool IsEmailAvailable(string email);
    }
}