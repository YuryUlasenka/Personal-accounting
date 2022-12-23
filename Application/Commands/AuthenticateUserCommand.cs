using MediatR;
using Shared.DTOs;

namespace Application.Commands
{
    public sealed record AuthenticateUserCommand(UserLoginDto UserLogin) : IRequest<TokenDto>;
}
