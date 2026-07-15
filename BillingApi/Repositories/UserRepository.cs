using BillingApi.Data;
using BillingApi.Models;

namespace BillingApi.Repositories;

public class UserRepository(BillingContext context) : IUserRepository
{
    public void RegisterUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    public User? GetUserByEmail(string email)
    {
        var user = context.Users.FirstOrDefault(u => u.Email == email);
        return user;
    }

    public IEnumerable<User> GetUsers()
    {
        var users = context.Users.ToList();
        return users;
    }
}