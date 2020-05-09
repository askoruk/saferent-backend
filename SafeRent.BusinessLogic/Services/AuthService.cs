using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SafeRent.BusinessLogic.Models;
using SafeRent.BusinessLogic.Services.Interfaces;
using SafeRent.DataAccess.Data;

namespace SafeRent.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _dbContext;

        public AuthService(IConfiguration configuration, AppDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public string GetToken(LoginModel loginModel, Claim[] claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration
                .GetSection("Secrets")
                .GetSection("SecretKey").Value));
                
            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(12),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool IsEmailAvailable(string email)
        {
            return !_dbContext.Users.Any(user => user.Email == email);
        }
    }
}