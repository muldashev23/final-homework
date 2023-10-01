using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Entities;

public class Shoes
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Brand { get; set; }

    [Required]
    public required float Price { get; set; }

    [Required]
    public required int Amount { get; set; }

    [Required]
    public required bool IsForMan { get; set; }

    [Required]
    public required int Available { get; set; }

    [JsonIgnore]
    public ICollection<Cart> Carts { get; set; }

    public List<Photo> Photos { get; set; } = new();
    public List<Size> Sizes { get; set; } = new();
}
