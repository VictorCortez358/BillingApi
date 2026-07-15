using System.ComponentModel.DataAnnotations;

namespace BillingApi.Models;

public class User
{
    [Key] public int Id { get; set; }
    [Required] [StringLength(100)] public string Name { get; set; } = string.Empty;
    [Required] [StringLength(100)] public string Email { get; set; } = string.Empty;
    [Required] [StringLength(255)] public string Password { get; set; } = string.Empty;
    [Required] [StringLength(30)] public string Role { get; set; } = string.Empty;
}