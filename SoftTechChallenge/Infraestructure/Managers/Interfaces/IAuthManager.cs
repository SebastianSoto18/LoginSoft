using SoftTechChallenge.Infraestructure.Dtos;

namespace SoftTechChallenge.Infraestructure.Managers.Interfaces;

public interface IAuthManager
{
    Task<string> LoginAsync(LoginDto loginDto);
}