using Microsoft.EntityFrameworkCore;
using myportfolio.Models;

public class UserService : IUserService 
{

private readonly DbContext dbContext ; 
public UserService(DbContext dbContext){
    this.dbContext = dbContext;
}

    public void AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public User GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateUser(int id, User user)
    {
        throw new NotImplementedException();
    }
}