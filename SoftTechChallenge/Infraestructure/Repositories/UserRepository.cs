using Microsoft.EntityFrameworkCore;
using SoftTechChallenge.Infraestructure.Models;
using SoftTechChallenge.Infraestructure.Repositories.Interfaces;

namespace SoftTechChallenge.Infraestructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.Include(u => u.Roles).ThenInclude(r => r.Role).FirstOrDefaultAsync(u => u.Email == email);
    }
}