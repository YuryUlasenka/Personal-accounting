using System.Threading;
using System.Threading.Tasks;
using Application.Commands;
using AutoMapper;
using Entities.Models;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Handlers
{
    internal sealed class RegisterUserHandler : IRequestHandler<RegisterUserCommand, IdentityResult>
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;

        public RegisterUserHandler(IMapper mapper, IAuthenticationService authenticationService)
        {
            _mapper = mapper;
            _authenticationService = authenticationService;
        }

        public async Task<IdentityResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.UserForRegistration);

            return await _authenticationService.RegisterUser(user, request.UserForRegistration.Password);
        }
    }
}