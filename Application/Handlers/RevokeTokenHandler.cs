using System.Threading;
using System.Threading.Tasks;
using Application.Commands;
using Entities.Exceptions;
using MediatR;
using Repository.Interfaces;

namespace Application.Handlers
{
    internal sealed class RevokeTokenHandler : IRequestHandler<RevokeTokenCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public RevokeTokenHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _repositoryManager.UserRepository.GetUserByUserName(request.userName, true);
            if (user == null)
            {
                throw new BadRequestException("Invalid client request. Wrong value in userName");
            }

            user.RefreshToken = null;

            _repositoryManager.Save();

            return Unit.Value;
        }
    }
}
