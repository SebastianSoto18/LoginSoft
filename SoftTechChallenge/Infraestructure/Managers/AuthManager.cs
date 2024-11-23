using SoftTechChallenge.Common;
using SoftTechChallenge.Infraestructure.Dtos;
using SoftTechChallenge.Infraestructure.Managers.Interfaces;
using SoftTechChallenge.Infraestructure.Repositories.Interfaces;
using SoftTechChallenge.Infraestructure.Utilities;

namespace SoftTechChallenge.Infraestructure.Managers;

public class AuthManager : IAuthManager
{
    private readonly IUserRepository _userRepository;
    private readonly TokenProvider _tokenProvider;
    
    public AuthManager(IUserRepository userRepository, TokenProvider tokenProvider)
    {
        _userRepository = userRepository;
        _tokenProvider = tokenProvider;
    }


    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);
        
        if (user == null )
            throw new Exception("User not found");
        
        if(BCryptExtensions.VerifyPassword(loginDto.Password, user.Password) == false)
            throw new Exception("Invalid Credentials");
        
        return _tokenProvider.GenerarJWT(user);
    }
}