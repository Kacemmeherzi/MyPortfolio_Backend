using myportfolio.Models;

public class AuthService : IAuthService
{
private readonly ITokenService _tokenService; 
private readonly IUserService _userService;
public AuthService(ITokenService tokenService, IUserService userService){
    _tokenService = tokenService;
    _userService = userService;
}
    public async Task<string> Login(UserLogin userLogin)
    {
        try {
            var user = await _userService.FindByEmail(userLogin.Email);
            if (user.Password == userLogin.Password)
            {
                return await _tokenService.GenerateToken(user);
            }
            throw new Exception("Invalid password");
        } catch (Exception) {
            throw new Exception("User not found");
        }
    }

    public Task<string> Register(User user)
    {
        throw new NotImplementedException();
    }
}