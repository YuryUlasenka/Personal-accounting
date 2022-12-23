using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace PersonalAccountingBackend.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public TokenController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _authenticationService.RefreshToken(tokenDto);

            return Ok(tokenDtoToReturn);
        }
    }
}
