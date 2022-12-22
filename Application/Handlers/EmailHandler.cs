using System.Threading;
using System.Threading.Tasks;
using Application.Commands;
using Contracts;
using MediatR;

namespace Application.Handlers
{
    public sealed class EmailHandler : INotificationHandler<CreateTestDataNotification>
    {
        private readonly ILoggerManager _logger;

        public EmailHandler(ILoggerManager logger)
        {
            _logger = logger;
        }

        public async Task Handle(CreateTestDataNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogWarn("Send email action");
        }
    }
}