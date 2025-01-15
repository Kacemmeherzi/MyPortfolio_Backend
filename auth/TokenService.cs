using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using myportfolio.Models;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService; 

    public TokenService(IConfiguration configuration , IUserService userService)
    {
        _configuration = configuration;
        _userService = userService;   
    }
   
    private string? getSecret()
    {
        var secret =  _configuration.GetSection("Jwt:SecretKey").Value;
        if (string.IsNullOrEmpty(secret))
        {
            throw new Exception("Secret is not set");
        }
        return secret;
    }
    public  Task<string> GenerateToken(User user)
    {
          var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(getSecret()!);
            var tokenDescriptor = TokenDescriptor.GetTokenDescriptor(user, getSecret());
            var token =   tokenHandler.CreateToken(tokenDescriptor);
            var tokenString =   tokenHandler.WriteToken(token);
            return Task.FromResult(tokenString) ;    }


 public   async Task<ClaimsValidation> ValidateTokenClaims(ClaimsPrincipal principal)
    
    {
       try
        {
            
            var user =  await   _userService.FindByEmail(principal.FindFirst(ClaimTypes.Email)!.Value);
            var  cv =  new ClaimsValidation
                {
                IsValid = user != null,
                ValidTo = principal.FindFirst(JwtRegisteredClaimNames.Exp)?.Value,
                };
                return cv ; 
        }
        catch   (Exception e ) 
        {
            throw new Exception(e.Message) ;
        }
    }

    
}

