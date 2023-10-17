using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Backend.Entities;

public class AppUser
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public required string UserName { get; set; }

    [Required]
    public required string Email { get; set; }

    [Required]
    public required byte[] PasswordHash { get; set; }

    [Required]
    public required byte[] PasswordSalt { get; set; }

    [Required]
    public required string Role { get; set; }

    [JsonIgnore]
    public Cart Cart { get; set; }
}
