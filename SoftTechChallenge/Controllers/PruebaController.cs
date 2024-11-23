using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SoftTechChallenge.Controllers;
[Authorize]
public class PruebaController : BaseController
{
    [HttpGet]
    public ActionResult<string> Prueba()
    {
        return Ok("Prueba");
    }
    

    [HttpGet("check-roles")]
    public ActionResult<string> CheckRolesExplicit()
    {
        var userRoles = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
    
        if (userRoles.Contains("ADMIN"))
        {
            return Ok("El usuario tiene el rol ADMIN.");
        }
    
        return Unauthorized("El usuario no tiene el rol ADMIN.");
    }


}