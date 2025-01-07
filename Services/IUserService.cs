using myportfolio.Models;

public interface IUserService
{
    Task<List<User>> GetAllUsers();
    Task<User> GetUserById(int id);
    Task<User>AddUser(User user);
    Task<User> UpdateUser(int id, User user);
    Task<User> DeleteUser(int id);
}
