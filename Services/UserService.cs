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
        dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> FindByEmail(string email)
    {
        try {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            return user;
        } catch (Exception) {
            throw new Exception("User not found");
        }
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await dbContext.Users.ToListAsync();
    }

    public async Task<User> GetUserById(int id)
    {
        var user = await dbContext.Users.FindAsync(id);
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

        dbContext.Users.Update(userToUpdate);
        await dbContext.SaveChangesAsync();
        return userToUpdate;
    }
}
