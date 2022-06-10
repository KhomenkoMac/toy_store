using System.ComponentModel.DataAnnotations.Schema;

namespace entities.DTO
{
    [Table("product_comments")]
    public class ProductComment: DTO
    {
        public string CommentText { get; set; }
        public int CommentRate { get; set; }
        public User User { get; set; } // owner of the comment
        public Toy Toy { get; set; }
    }
}