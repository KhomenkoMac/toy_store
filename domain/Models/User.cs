using System;
using System.Collections.Generic;

namespace toy_store.domain.Models
{
    public class User: DomainObj
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public ICollection<ProductComment> ProductsComments { get; set; }
        public Profile UserProfile { get; set; }
    }
}