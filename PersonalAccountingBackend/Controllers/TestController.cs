using System.Threading.Tasks;
using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace PersonalAccountingBackend.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IPublisher _publisher;

        public TestController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;
        }

        [HttpGet]
        public async Task<IActionResult> GetTestData()
        {
            var data = await _sender.Send(new GetTestDataQuery());

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> PostData()
        {
            var dto = new TestDataForCreateDto
            {
                Id = 99,
                Data = "test"
            };

            await _publisher.Publish(new CreateTestDataNotification(dto));

            return NoContent();
        }
    }
}
