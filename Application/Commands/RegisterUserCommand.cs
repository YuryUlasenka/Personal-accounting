using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.DTOs;

namespace Application.Commands
{
    public sealed record RegisterUserCommand(UserForRegistrationDto UserForRegistration) : IRequest<IdentityResult>;
}