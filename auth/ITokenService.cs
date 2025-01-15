using System.Security.Claims;
using myportfolio.Models;

public interface ITokenService
{
    Task<string> GenerateToken(User user);

    Task<ClaimsValidation> ValidateTokenClaims(ClaimsPrincipal principal);

    // ? no need to create a token signature method  deja par defaut implementer fel program.cs 
}