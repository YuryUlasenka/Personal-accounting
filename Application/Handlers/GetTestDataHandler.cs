using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries;
using MediatR;
using Shared.DTOs;

namespace Application.Handlers
{
    internal sealed class GetTestDataHandler : IRequestHandler<GetTestDataQuery, IEnumerable<TestDataDto>>
    {
        public async Task<IEnumerable<TestDataDto>> Handle(GetTestDataQuery request, CancellationToken cancellationToken)
        {
            var dtos = new List<TestDataDto>
            {
                new TestDataDto
                {
                    Id = 1,
                    Data = "abracadabra"
                },
                new TestDataDto
                {
                    Id = 2,
                    Data = "olololo"
                }
            };

            return dtos.AsEnumerable();
        }
    }
}
