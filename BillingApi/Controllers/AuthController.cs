using BillingApi.Models;
using BillingApi.Models.Dtos;
using BillingApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserService userService) : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] RegisterDto dto)
        {
            try
            {
                // create the entity user with the dto data 
                var newUser = new User
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    Role = dto.Role,
                };
                
                userService.RegisterUser(newUser, dto.Password);
                return Ok(new { mensaje = "User registered successfully" });
                
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
        
    }
}
