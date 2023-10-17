using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required List<Shoes> Shoes { get; set; }
        public int UserId { get; set; }
        public required AppUser User { get; set; }
        public required List<SelectedSize> SelectedSizes { get; set; } = new();
    }
}
