using Microsoft.AspNetCore.Mvc;
using WebApiExample.Domain.Configuration;

namespace WebApiExample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController(ILogger<HealthController> logger) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        logger.LogInformation("health check: pong");
        return Ok("pong");
    }
}