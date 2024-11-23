using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SoftTechChallenge.Controllers;

[Route("")]
public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<string> Home()
    {
        return Ok("Welcome to SoftTechChallenge!");
    }
}