namespace toy_store.domain.Models
{
    public class Image : DomainObj
    {
        public string ImagePath { get; set; }
        public Profile Profile { get; set; }
        public Toy Toy { get; set; }
    }
}