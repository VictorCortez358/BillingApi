using BillingApi.Models;
using BillingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BillingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return userService.GetUsers();
        }
    }
}
