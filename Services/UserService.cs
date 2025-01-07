using Microsoft.EntityFrameworkCore;
using myportfolio.Models;

public class UserService : IUserService 
{

private readonly DbContext dbContext ; 
public UserService(DbContext dbContext){
    this.dbContext = dbContext;
}

    public async Task<User> AddUser(User user)
    {
         dbContext.Add(user);
         await dbContext.SaveChangesAsync();
         return user;
    }

    public async Task<User> DeleteUser(int id)
    {
        User user =  await GetUserById(id);
        dbContext.Remove(GetUserById(id));
        dbContext.SaveChanges();
        return user;

    }

    public async Task<List<User>> GetAllUsers()
    {
        List<User> users = await dbContext.Set<User>().ToListAsync();
        return users;
    }

    public async Task<User> GetUserById(int id)
    { 
        try
        {
            var user = await dbContext.Set<User>().FindAsync(id);
            return user!;
        }
        catch (Exception)
        {
            throw new KeyNotFoundException("User not found");
        }
       
    }

    public async Task<User> UpdateUser(int id, User user)
    {
        try
        {
            var usertoupdate = await GetUserById(id);
        }
        catch (Exception)
        {
            throw new KeyNotFoundException("User not found");
        }

        dbContext.Entry(user).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
        return user;
    }
}