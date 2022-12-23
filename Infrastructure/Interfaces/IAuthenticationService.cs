using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Shared.DTOs;

namespace Infrastructure.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserLoginDto userLogin);
        Task<string> CreateToken();
    }
}
