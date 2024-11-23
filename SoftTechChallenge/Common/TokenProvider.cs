using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SoftTechChallenge.Infraestructure.Models;

namespace SoftTechChallenge.Common;

public class TokenProvider
{
    private readonly IConfiguration _configuration;

    public TokenProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerarJWT(User user)
    {
        //crear la informacion del usuario para token
        var userClaims = new[]
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Roles.FirstOrDefault().Role.Name)
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //crear detalle del token
        var jwtConfig = new JwtSecurityToken(
            claims: userClaims,
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
    }
}
