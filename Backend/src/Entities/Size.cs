using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities;

[Table("Sizes")]
public class Size
{
    public int Id { get; set; }
    public int SizeNum { get; set; }
    public int Amount { get; set; }
    public int ShoesID { get; set; }
    public Shoes Shoes { get; set; }
}
