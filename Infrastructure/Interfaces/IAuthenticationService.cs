using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Shared.DTOs;

namespace Infrastructure.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(User user, string password);

        Task<bool> ValidateUser(UserLoginDto userLogin);

        Task<TokenDto> CreateToken(bool populateExp);

        Task<TokenDto> RefreshToken(TokenDto tokenDto);
    }
}
