using Microsoft.AspNetCore.Mvc;

namespace PersonalAccountingBackend.Controllers
{
    [Route("/api/healthcheck")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        public HealthCheckController()
        {
        }

        [HttpGet]
        public IActionResult CheckHealth() 
        {
            return Ok(new { Text = "healthy" });
        }
    }
}
