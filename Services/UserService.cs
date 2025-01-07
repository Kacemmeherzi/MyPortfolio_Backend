using System.Net;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myportfolio.Models;

public class UserService : IUserService 
{

private readonly DbContext dbContext ; 
public UserService(DbContext dbContext){
    this.dbContext = dbContext;
}

    public User AddUser(User user)
    {
        dbContext.Add(user);
        dbContext.SaveChanges();
        return user;}

    public User DeleteUser(int id)
    {
        User user = GetUserById(id);
        dbContext.Remove(GetUserById(id));
        dbContext.SaveChanges();
        return user;

    }

    public List<User> GetAllUsers()
    {
        List<User>users =  dbContext.Set<User>().ToList();
        return users;
    }

    public User GetUserById(int id)
    {
        var user = dbContext.Set<User>().Find(id);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        return user;
    }

    public User UpdateUser(int id, User user)
    {
        var userToUpdate = GetUserById(id);
        foreach (var prop in user.GetType().GetProperties())
        {
            var value = prop.GetValue(user);
            if (value != null)
            {
                prop.SetValue(userToUpdate, value);
            }
        }

         dbContext.SaveChanges();
        return userToUpdate;}
}