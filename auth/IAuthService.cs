using myportfolio.Models;

public interface IAuthService 
{
    Task<string> Login(UserLogin userLogin);
    Task<string> Register(User user);
}