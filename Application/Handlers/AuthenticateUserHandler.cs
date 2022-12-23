using System.Threading;
using System.Threading.Tasks;
using Application.Commands;
using Entities.Exceptions;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Handlers
{
    internal sealed class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, string>
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticateUserHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<string> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            if(!await _authenticationService.ValidateUser(request.UserLogin))
            {
                throw new UnauthorizedException("Authentication failed. Wrong user name or password.");
            }

            var result = await _authenticationService.CreateToken();

            return result;
        }
    }
}
