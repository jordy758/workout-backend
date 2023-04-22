using Microsoft.AspNetCore.Mvc;

namespace Workout.Api.Controllers;

[Route("menus")]
public class MenusController : ApiController
{
    [HttpGet]
    public IActionResult ListDinners()
    {
        return Ok(new[] { "Dinner 1", "Dinner 2" });
    }
}