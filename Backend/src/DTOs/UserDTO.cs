using Backend.Entities;

namespace Backend.DTOs;

public class UserDTO
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string UserName { get; set; }
    public required string Role { get; set; }
    public Cart Cart { get; set; }
}
