using MediatR;

namespace Application.Commands
{
    public sealed record RevokeTokenCommand(string userName) : IRequest;
}
