namespace Backend.DTOs;

public class LoginResponseDTO
{
    public required int Id { get; set; }
    public required string Username { get; set; }
    public required string Token { get; set; }
    public required bool IsAdmin { get; set; }
}
