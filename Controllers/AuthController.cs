using Microsoft.AspNetCore.Mvc;


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

       //  Console.WriteLine(userLogin.Email) ; 
        LoginResponse loginResponse =  await authService.Login(userLogin);
            if (loginResponse.Succes){
                return Ok(loginResponse);
            }
            return Unauthorized(loginResponse);        
        

    }
}

