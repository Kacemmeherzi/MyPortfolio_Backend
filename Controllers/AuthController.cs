using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService authService ; 
public AuthController(IAuthService authService)
{
    this.authService = authService ; 
}
  

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody]UserLogin userLogin)
    {

        Console.WriteLine(userLogin.Email) ; 
        var token =  await authService.Login(userLogin);
        if (token != null)
        {
            return Ok(token);
        }
        

        return Unauthorized();
    }
}

