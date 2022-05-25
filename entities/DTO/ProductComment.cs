using System.ComponentModel.DataAnnotations.Schema;
using toy_store.domain.Models.Enums;

namespace entities.DTO
{
    [Table("product_comments")]
    public class ProductComment: DTO
    {
        public string CommentText { get; set; }
        public Rate CommentRate { get; set; }
        public User User { get; set; } // owner of the comment
        public Toy Toy { get; set; }
    }
}