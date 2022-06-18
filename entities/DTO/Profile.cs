using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace entities.DTO
{
    [Table("profiles")]
    public class Profile: DTO
    {
        public int UserId { get; set; }
        public User User { get; set; }

        [DefaultValue(3003)]
        public int ImageId { get; set; } = 3003;
        public Image Image { get; set; }
        public ICollection<ProfileToy> ProfileToys { get; set; }
    }
}