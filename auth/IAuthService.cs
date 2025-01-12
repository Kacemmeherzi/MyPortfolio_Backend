using myportfolio.Models;

public interface IAuthService 
{
    Task<LoginResponse> Login(UserLogin userLogin);
    Task<string> Register(User user);
}