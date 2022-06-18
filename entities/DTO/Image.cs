using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entities.DTO
{
    [Table("images")]
    public class Image : DTO
    {
        public string ImagePath { get; set; }

        public ICollection<Profile> Profile { get; set; }
        public ICollection<Toy> Toys { get; set; }
    }
}