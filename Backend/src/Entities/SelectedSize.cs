using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities;

[Table("SelcetedSizes")]
public class SelectedSize
{
    public int Id { get; set; }
    public required int SelectedShoesId { get; set; }
    public required int SizeNum { get; set; }
    public required int ShoesIdForSize { get; set; }
    public int CartId { get; set; }
    public Cart Cart { get; set; }
}
