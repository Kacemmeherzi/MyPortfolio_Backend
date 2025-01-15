
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using myportfolio.Models;

public static class TokenDescriptor {

private static int _expiresInHours = 1;

private static  ClaimsIdentity GetClaimsIdentity(User user)
{
    return new ClaimsIdentity(new Claim[]
    {
        new Claim(ClaimTypes.Email, user.Email)
    });}


public static SecurityTokenDescriptor GetTokenDescriptor(User user, string? key )
{
    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = GetClaimsIdentity(user),
        Expires = DateTime.UtcNow.AddHours(_expiresInHours),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature)
    };
    return tokenDescriptor;
}
}