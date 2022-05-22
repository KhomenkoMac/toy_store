using toy_store.domain.Models.Enums;

namespace toy_store.domain.Models
{
    public class ProductComment: DomainObj
    {
        public string CommentText { get; set; }
        public Rate CommentRate { get; set; }
        public User User { get; set; } // owner of the comment
        public Toy Toy { get; set; }
    }
}