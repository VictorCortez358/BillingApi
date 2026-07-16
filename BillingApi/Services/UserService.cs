using BillingApi.Models;
using BillingApi.Repositories;

namespace BillingApi.Services;

public class UserService(IUserRepository repository) : IUserService
{
    public void RegisterUser(User user,  string password)
    {
        var userExist = repository.GetUserByEmail(user.Email);
        if (userExist != null)
        {
            throw new ArgumentException("The email exist");
        }

        var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
        user.Password = hashPassword;
        repository.RegisterUser(user);
    }

    public User? GetUserByEmail(string email)
    {
        var userExist = repository.GetUserByEmail(email);
        return userExist ?? throw new ArgumentException("User doesn't exist");
    }

    public IEnumerable<User> GetUsers()
    {
        var users = repository.GetUsers();
        return users;
    }

    public bool VerifyCredentials(string email, string password)
    {
        var userExist = repository.GetUserByEmail(email);
        return userExist == null ? throw new ArgumentException("User doesn't exist") : BCrypt.Net.BCrypt.Verify(password, userExist.Password);
    }
}