using Microsoft.EntityFrameworkCore;
using myportfolio.Models;

public class UserService : IUserService 
{
    private readonly ApplicationDbContext dbContext; 

    public UserService(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<User> AddUser(User user)
    {
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> DeleteUser(int id)
    {
        var user = await GetUserById(id);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }
        dbContext.Remove(user);
        await dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await dbContext.Set<User>().ToListAsync();
    }

    public async Task<User> GetUserById(int id)
    {
        var user = await dbContext.Set<User>().FindAsync(id);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }
        return user;
    }

    public async Task<User> UpdateUser(int id, User user)
    {
        var userToUpdate = await GetUserById(id);
        if (userToUpdate == null)
        {
            throw new KeyNotFoundException("User not found in the database");
        }

        foreach (var property in typeof(User).GetProperties())
        {
            if (property.Name == nameof(User.Id))
            {
                continue;
            }

            var newValue = property.GetValue(user);
            if (newValue == null || newValue.ToString() == string.Empty)
            {
                continue;
            }
            property.SetValue(userToUpdate, newValue);
        }

        dbContext.Update(userToUpdate);
        await dbContext.SaveChangesAsync();
        return userToUpdate;
    }
}
