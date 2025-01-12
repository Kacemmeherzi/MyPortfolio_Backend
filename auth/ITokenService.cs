using myportfolio.Models;

public interface ITokenService
{
    Task<string> GenerateToken(User user);
}