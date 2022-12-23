using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.DTOs;

namespace Infrastructure
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILoggerManager _logger;
        private User? _user;

        public AuthenticationService(
            UserManager<User> userManager, 
            IConfiguration configuration,
            ILoggerManager logger)
        {
            _userManager = userManager;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ValidateUser(UserLoginDto userLogin)
        {
            _user = await _userManager.FindByNameAsync(userLogin.UserName);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userLogin.Password));
            if (!result)
                _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong user name or password.");
            return result;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
    }
}
