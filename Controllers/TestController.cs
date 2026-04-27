using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DayNotes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok("Você está autenticado agora se divirta!🔥 ");
    }
}