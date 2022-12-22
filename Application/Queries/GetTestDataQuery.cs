using System.Collections.Generic;
using MediatR;
using Shared.DTOs;

namespace Application.Queries
{
    public sealed record GetTestDataQuery : IRequest<IEnumerable<TestDataDto>>;
}
