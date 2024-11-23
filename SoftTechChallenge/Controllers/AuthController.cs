using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftTechChallenge.Infraestructure.Dtos;
using SoftTechChallenge.Infraestructure.Managers.Interfaces;

namespace SoftTechChallenge.Controllers;


public class AuthController : BaseController
{
    private readonly IAuthManager _authManager;
    
    public AuthController(IAuthManager authManager)
    {
        _authManager = authManager;
    }
    
    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType(typeof(string),(int)HttpStatusCode.OK)]
    public async Task<ActionResult<string>> Login([FromBody] LoginDto loginDto)
    {
        return Ok(await _authManager.LoginAsync(loginDto));
    }
}