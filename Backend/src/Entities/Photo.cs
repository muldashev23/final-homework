using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities;

[Table("Photos")]
public class Photo
{
    public int Id { get; set; }
    public required string Url { get; set; }
    public required bool IsMain { get; set; }
    public string PublicId { get; set; }
    public int ShoesID { get; set; }
    public required Shoes Shoes { get; set; }
}
