namespace SoftTechChallenge.Infraestructure.Utilities;

public class BCryptExtensions
{
    public static bool VerifyPassword(string password, string hash)
        => BCrypt.Net.BCrypt.Verify(password, hash);
}