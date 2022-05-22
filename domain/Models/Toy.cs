using System.Collections.Generic;

namespace toy_store.domain.Models
{
    public class Toy: DomainObj
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
