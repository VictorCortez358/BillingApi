using System.ComponentModel.DataAnnotations;

namespace BillingApi.Models.Dtos;

public class RegisterDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress] // Valid the email is a correct format
    [StringLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 6)] // Minimum 6 characters
    public string Password { get; set; } = string.Empty;

    [Required]
    [StringLength(30)]
    public string Role { get; set; } = "Seller"; // Default value
}