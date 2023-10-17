using System.ComponentModel.DataAnnotations;

namespace Backend;

public class UserUpdateDTO
{
    [Required]
    [EmailAddress(ErrorMessage = "Provide Email")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Password field is required")]
    [StringLength(32, MinimumLength = 8)]
    public required string Password { get; set; }

    [Required(ErrorMessage = "Password field is required")]
    [StringLength(32, MinimumLength = 8)]
    public required string NewPassword { get; set; }

    [Required(ErrorMessage = "Password field is required")]
    [StringLength(32, MinimumLength = 8)]
    public required string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Username field is required")]
    public required string Username { get; set; }
    public required string Role { get; set; }
}
