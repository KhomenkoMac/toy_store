using System.ComponentModel.DataAnnotations.Schema;

namespace entities.DTO
{
    [Table("ProfileToy")]
    public class ProfileToy : DTO 
    {
        [Column("ProfilesId")]
        public int ProfileId { get; set; }

        [Column("ToysId")]
        public int ToyId { get; set; }

        public Profile Profile { get; set; }
        public Toy Toy { get; set; }
    }
}
