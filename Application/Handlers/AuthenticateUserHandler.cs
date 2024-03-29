﻿using System.Threading;
using System.Threading.Tasks;
using Application.Commands;
using Entities.Exceptions;
using Infrastructure.Interfaces;
using MediatR;
using Shared.DTOs;

namespace Application.Handlers
{
    internal sealed class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, TokenDto>
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticateUserHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<TokenDto> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            if(!await _authenticationService.ValidateUser(request.UserLogin))
            {
                throw new UnauthorizedException("Authentication failed. Wrong user name or password.");
            }

            var result = await _authenticationService.CreateToken(populateExp: true);

            return result;
        }
    }
}
