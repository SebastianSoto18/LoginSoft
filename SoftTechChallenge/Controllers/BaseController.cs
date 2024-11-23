using Microsoft.AspNetCore.Mvc;

namespace SoftTechChallenge.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class BaseController : ControllerBase { }