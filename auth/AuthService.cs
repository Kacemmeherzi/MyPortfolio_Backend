using myportfolio.Models;

public class AuthService : IAuthService
{
private readonly ITokenService _tokenService; 
private readonly IUserService _userService;
public AuthService(ITokenService tokenService, IUserService userService){
    _tokenService = tokenService;
    _userService = userService;
}
    public async Task<LoginResponse> Login(UserLogin userLogin)
    {
        try {
            User user = await _userService.FindByEmail(userLogin.Email);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (user.Password == userLogin.Password)
            {
                var token =  await _tokenService.GenerateToken(user) ; 
                return new LoginResponse
                {
                    message = "Login successful",
                    Token = token,
                    User = user,
                    Succes = true
                };
            } else {
                return new LoginResponse
                {
                    message = "Email or Password is invalid",Succes=false  };}
            
        } catch (Exception ex) {
            throw new Exception($"Login failed: {ex.Message}");
        }
    }

    public Task<string> Register(User user)
    {
        throw new NotImplementedException();
    }
}