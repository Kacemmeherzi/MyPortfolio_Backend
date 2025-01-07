using myportfolio.Models;

public interface IUserService
{
    List<User> GetAllUsers();
    User GetUserById(int id);
    User AddUser(User user);
    User UpdateUser(int id, User user);
    User DeleteUser(int id);
}
