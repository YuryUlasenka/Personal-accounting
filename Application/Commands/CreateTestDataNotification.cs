using MediatR;
using Shared.DTOs;

namespace Application.Commands
{
    public sealed record CreateTestDataNotification(TestDataForCreateDto dataDto) : INotification;
}