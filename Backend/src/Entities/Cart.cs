using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required ICollection<Shoes> Shoes { get; set; }
        public required AppUser User { get; set; }
        public int UserId { get; set; }
    }
}
