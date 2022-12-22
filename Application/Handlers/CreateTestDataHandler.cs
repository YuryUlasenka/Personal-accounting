using System.Threading;
using System.Threading.Tasks;
using Application.Commands;
using Contracts;
using MediatR;

namespace Application.Handlers
{
    internal sealed class CreateTestDataHandler : INotificationHandler<CreateTestDataNotification>
    {
        private readonly ILoggerManager _logger;

        public CreateTestDataHandler(ILoggerManager logger)
        {
            _logger = logger;
        }

        public async Task Handle(CreateTestDataNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInfo("Created new test data");
            //return new TestDataDto
            //{
            //    Id = 99,
            //    Data = "New record"
            //};
        }
    }
}
