using System.Collections.Generic;

namespace toy_store.domain.Models
{
    public class Subject: DomainObj
    {
        public string Name { get; set; }
        public ICollection<Toy> Toys { get; set; }
    }
}
