using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace entities.DTO
{
    [Table("users")]
    public class User: DTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public ICollection<ProductComment> ProductsComments { get; set; }
        public Profile UserProfile { get; set; }
    }
}