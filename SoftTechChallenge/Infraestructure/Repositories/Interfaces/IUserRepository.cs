using SoftTechChallenge.Infraestructure.Models;

namespace SoftTechChallenge.Infraestructure.Repositories.Interfaces;


public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserByEmailAsync(string email);
}