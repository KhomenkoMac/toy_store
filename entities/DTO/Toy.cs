using entities.DTO.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entities.DTO
{
    [Table("toys")]
    public class Toy: DTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Rate { get; set; }
        public string Description { get; set; }
        public Subject Subject { get; set; }
        public ICollection<ProductComment> ProductComment { get; set; } // toy comment
        public ICollection<Image> Images { get; set; } // images of toy 
    }
}
