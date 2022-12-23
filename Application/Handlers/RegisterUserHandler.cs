using System.Threading;
using System.Threading.Tasks;
using Application.Commands;
using AutoMapper;
using Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Handlers
{
    internal sealed class RegisterUserHandler : IRequestHandler<RegisterUserCommand, IdentityResult>
    {
        private const string BaseUserRole = "User";

        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public RegisterUserHandler(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IdentityResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.UserForRegistration);

            var result = await _userManager.CreateAsync(user, request.UserForRegistration.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, BaseUserRole);
            }

            return result;
        }
    }
}