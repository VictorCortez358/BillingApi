using BillingApi.Models;

namespace BillingApi.Services;

public interface IUserService
{
    void RegisterUser(User user,  string password);
    User? GetUserByEmail(string email);
    
    IEnumerable<User> GetUsers();
}