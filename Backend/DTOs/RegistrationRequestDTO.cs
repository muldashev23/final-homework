namespace Backend.DTOs;

public class RegistrationRequestDTO
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Username { get; set; }
}
