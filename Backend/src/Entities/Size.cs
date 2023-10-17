using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Entities;

[Table("Sizes")]
public class Size
{
    public int Id { get; set; }
    public required int SizeNum { get; set; }
    public required int Amount { get; set; }
    public int ShoesID { get; set; }
    public required Shoes Shoes { get; set; }
}
