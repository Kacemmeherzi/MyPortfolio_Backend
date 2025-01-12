using myportfolio.Models;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;

    public TokenService(IConfiguration configuration, IUserService userService)
    {
        _configuration = configuration;
        _userService = userService;
    }

    public Task<string> GenerateToken(User user)
    {
        throw new NotImplementedException();
    }
}