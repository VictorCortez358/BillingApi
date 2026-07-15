using BillingApi.Models;

namespace BillingApi.Repositories;

public interface IUserRepository
{
    void RegisterUser(User user);
    User? GetUserByEmail(string email);
    
    IEnumerable<User> GetUsers();
}