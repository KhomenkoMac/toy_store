using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entities.DTO
{
    [Table("profiles")]
    public class Profile: DTO
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ImageId { get; set; }
        public Image Image { get; set; }

        public ICollection<Toy> Toys { get; set; }
    }
}